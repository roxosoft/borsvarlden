﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DBConverter.borsvarlden_MSSql;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Microsoft.EntityFrameworkCore.Rel

namespace DBConverter.borsvarlden
{
    class Program
    {
        static void Main(string[] args)
        {
            var nullGmtIds = new List<long>
            {
                557,
                3463,
                5086,
                5645,
                10363,
                12198,
                38563,
                43441,
                55406,
                56152,
                60251,
                64150
            };

            //SaveUploadedImagesToDisk();

            using (var db = new borsvarldenContext())
            using (var dbMS = new borsvarlden_MSSql.borsvarldenContext())
            {
                db.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());

                var term = db.WpTermRelationships
                    .Join(db.WpTermTaxonomy.Where(p => p.Taxonomy == "article_socialtag" || p.Taxonomy == "article_company"),
                        x => x.TermTaxonomyId, y => y.TermTaxonomyId,
                        (x, y) => new {WpTermRelationships = x, WpTermTaxonomy = y})
                    .Join(db.WpTerms,
                        x => x.WpTermTaxonomy.TermId, y => y.TermId,
                        (x, y) => new {WpTermTaxonomy = x, WpTerms = y})
                    .Join(db.WpPosts.Where(u => !nullGmtIds.Contains(u.Id)), 
                        x => x.WpTermTaxonomy.WpTermRelationships.ObjectId,
                        y => y.Id,
                        (x, y) => new {WpTermRelationships = x, WpPosts=y})
                    .AsNoTracking()
                    .ToList();

                var r = db.WpPosts
                    .Where(x => !nullGmtIds.Contains(x.Id) && x.PostType == "article" && x.PostStatus == "publish" /*&& x.Id == 64340*/)
                    .Join(db.WpPostmeta.Where(a => a.MetaKey == "_thumbnail_id"),
                        post => post.Id, meta => meta.PostId,
                        (post, meta) => new {Post = post, Meta = meta})
                    .AsNoTracking()
                    .ToList();

                var files =   db.WpPostmeta.Where(b => b.MetaKey == "_wp_attached_file").AsNoTracking().ToList();

                r.Join(files,
                        x => Convert.ToInt32(x.Meta.MetaValue),
                        y => y.PostId,
                        (x, y) => new {Post = x, Meta = y})
                    .ToList()
                    .ForEach(p =>
                    {
                        var r1 = term.FindAll(x => x.WpPosts.Id == p.Post.Post.Id);
                        var socialTagsAdded = new List<FinwireSocialTags>();
                        var companiesAdded = new List<FinwireCompanies>();

                       r1.ForEach(x =>
                       {
                           if (x.WpTermRelationships.WpTermTaxonomy.WpTermTaxonomy.Taxonomy == "article_socialtag")
                           {
                               var socialTag =  new FinwireSocialTags {Tag = x.WpTermRelationships.WpTerms.Name};
                               socialTagsAdded.Add(socialTag);
                           }
                           else if (x.WpTermRelationships.WpTermTaxonomy.WpTermTaxonomy.Taxonomy == "article_company")
                           {
                               var company = new FinwireCompanies {Company = x.WpTermRelationships.WpTerms.Name};
                               companiesAdded.Add(company);
                           }
                       });

                       var newsEntityAdded = new FinwireNews()
                       {
                           IsConvertedFromMySql = true,
                           NewsText = p.Post.Post.PostContent,
                           Title = p.Post.Post.PostTitle,
                           Date = p.Post.Post.PostDate,
                           ImageRelativeUrl = p.Meta.MetaValue.ToNewImageFilePath(),
                           Slug = p.Post.Post.PostName
                       };

                       dbMS.FinwireNews.Add(newsEntityAdded);
                       //todo make generic method in helper etc, find better solution using EF Core
                       socialTagsAdded?.ForEach(x =>
                           {
                               dbMS.FinwireNew2FirnwireSocialTag.Add(new FinwireNew2FirnwireSocialTag
                               {
                                   FinwireNew = newsEntityAdded,
                                   FinwireSocialTag = dbMS.FinwireSocialTags.FirstOrDefault(y => y.Tag == x.Tag) 
                                                      ?? dbMS.Add(new FinwireSocialTags { Tag=x.Tag}).Entity
                               });
                           }
                       );

                       companiesAdded?.ForEach(x =>
                           dbMS.FinwireNew2FinwireCompany.Add(new FinwireNew2FinwireCompany
                               {
                                   FinwireNew = newsEntityAdded,
                                   FinwareCompany = dbMS.FinwireCompanies.FirstOrDefault(y => y.Company == x.Company)
                                                    ?? dbMS.Add(new FinwireCompanies {Company = x.Company}).Entity
                               })
                           );
                    });
                dbMS.SaveChanges();
            }
        }

        private static void SaveUploadedImagesToDisk()
        {
            var dirToDownload = Path.GetFullPath($@"{Directory.GetCurrentDirectory()}\..\..\..\..\borsvarlden\wwwroot\assets\images\finauto\other\general");
            var pathListFiles = Path.GetFullPath($@"{Directory.GetCurrentDirectory()}\..\..\..\UploadedImages.txt");
            File.ReadAllLines(pathListFiles)
                .ToList()
                .ForEach(x => ImageSaver.Save(x, dirToDownload));
        }
    }
}