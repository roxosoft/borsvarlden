using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DBConverter.borsvarlden_MSSql;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DBConverter.Extensions;

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
            var dtStarted = DateTime.Now;

            using (var db = new borsvarldenContext())
            using (var dbMS = new borsvarlden_MSSql.borsvarldenContext())
            {
                //  SaveUploadedImagesNew(db);
                Console.WriteLine($"{DateTime.Now.ToString()} ================= Begin     ====================");
                //db.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
               // DbContextOptionsBuilder.EnableSensitiveDataLogging(true);

                var uploadedImages = db.WpPosts.Where(x => x.PostType == "attachment").ToList();
                var guids = db.WpPostmeta.Where(x => x.MetaKey == "article_finwire_guid").ToList();

                var metaAuthorsArticle = db.WpPostmeta
                    .Where(x => x.MetaKey == "article_sponsored_company" || x.MetaKey == "article_aktuellt_deadline" ||
                                x.MetaKey == "article_prio_deadline" || x.MetaKey == "article_prio_position"||
                                x.MetaKey == "article_sponsored").ToList();

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

                var allSocialTags = term.FindAll(x =>
                        x.WpTermRelationships.WpTermTaxonomy.WpTermTaxonomy.Taxonomy == "article_socialtag")
                    .Select(x=> x.WpTermRelationships.WpTerms.Name)
                    .Distinct()
                    .Select(x => new FinwireSocialTags {Tag = x});
                
                dbMS.FinwireSocialTags.AddRange(allSocialTags);

                var allCompanies = term.FindAll(x =>
                        x.WpTermRelationships.WpTermTaxonomy.WpTermTaxonomy.Taxonomy == "article_company")
                    .Select(x => x.WpTermRelationships.WpTerms.Name)
                    .Distinct()
                    .Select(x => new FinwireCompanies{  Company = x });

                dbMS.FinwireCompanies.AddRange(allCompanies);

                dbMS.SaveChanges();
                    

                var posts = db.WpPosts
                    .Where(x => !nullGmtIds.Contains(x.Id) && x.PostType == "article" && x.PostStatus == "publish")
                     //.Where(x=>x.Id ==66289) //FOR DIAGNOTICS
                    .Join(db.WpPostmeta.Where(a => a.MetaKey == "_thumbnail_id"),
                        post => post.Id, meta => meta.PostId,
                        (post, meta) => new {Post = post, Meta = meta})
                   // .Take(1000) //FOR DIAGNOTICS
                    .AsNoTracking()
                    .ToList();

                var files =   db.WpPostmeta.Where(b => b.MetaKey == "_wp_attached_file").AsNoTracking().ToList();
                var articleLabels = db.WpPostmeta.Where(b => b.MetaKey == "article_label").AsNoTracking().ToList();

               Console.WriteLine($"{DateTime.Now.ToString()} ================= Main transformation     ====================");

               var listPosts = posts.Join(files,
                        x => Convert.ToInt32(x.Meta.MetaValue),
                        y => y.PostId,
                        (x, y) => new {Post = x, Meta = y})
                    .ToList();

              


               var total = listPosts.Count;
               int i = 0;
              //  db.ChangeTracker.AutoDetectChangesEnabled = false;

               listPosts.ForEach(p =>
                    {
                        var r1 = term.FindAll(x => x.WpPosts.Id == p.Post.Post.Id);
                        var socialTagsAdded = new List<string>();
                        var companiesAdded = new List<string>();

                        r1.ForEach(x =>
                       {
                           if (x.WpTermRelationships.WpTermTaxonomy.WpTermTaxonomy.Taxonomy == "article_socialtag")
                           {
                               var socialTag =  new FinwireSocialTags {Tag = x.WpTermRelationships.WpTerms.Name};
                               socialTagsAdded.Add(socialTag.Tag);
                           }
                           else if (x.WpTermRelationships.WpTermTaxonomy.WpTermTaxonomy.Taxonomy == "article_company")
                           {
                               var company = new FinwireCompanies {Company = x.WpTermRelationships.WpTerms.Name};
                               companiesAdded.Add(company.Company);
                           }
                       });

                        /* var finwireXmlNewsAdded =  dbMS.FinwireXmlNews.Add(new FinwireXmlNews
                         {
                             DateTime = DateTime.Now,
                             //FileContent =  .RoughXml,
                             FileName = p.Post.Post.Guid
                         });*/

                        var customMainImage = uploadedImages.FirstOrDefault(x => x.PostParent == p.Post.Post.Id);
                      
                        var newsEntityAdded = new FinwireNews()
                       {
                           IsConvertedFromMySql = true,
                           NewsText = p.Post.Post.PostContent.ChangeImagePathInPost(),
                           Date = p.Post.Post.PostDate,
                           ImageRelativeUrl =  customMainImage != null ?  customMainImage.Guid.ChangeImagePathForTitle() : 
                               p.Meta.MetaValue.ToNewImageFilePath(),
                           Slug = p.Post.Post.PostName,
                           FinautoPassed = true,
                           ImageLabel = articleLabels.FirstOrDefault(x => x.PostId == p.Post.Post.Id)?.MetaValue,
                           Guid = guids.FirstOrDefault(x => x.PostId == p.Post.Post.Id)?.MetaValue
                        };

                        if (newsEntityAdded.Guid != null)
                        {
                            newsEntityAdded.IsFinwireNews = true;
                            newsEntityAdded.FinautoPassed = true;
                        }

                        (newsEntityAdded.Title, newsEntityAdded.Subtitle) =
                            p.Post.Post.PostTitle.SplitSubtitleAndNews();

                        var authorArticlesData = metaAuthorsArticle.Where(x => x.PostId == p.Post.Post.Id).ToList();

                        if (authorArticlesData.Count > 0)
                        {
                            newsEntityAdded.IsBorsvarldenArticle = true;
                            newsEntityAdded.PrioDeadLine = Convert.ToDateTime(authorArticlesData.FirstOrDefault(x => x.MetaKey == "article_prio_deadline")?.MetaValue);
                            newsEntityAdded.ActualDeadLine = Convert.ToDateTime(authorArticlesData.FirstOrDefault(x => x.MetaKey == "article_aktuellt_deadline")?.MetaValue);
                            newsEntityAdded.Order = Convert.ToInt32(authorArticlesData.FirstOrDefault(x => x.MetaKey == "article_prio_position")?.MetaValue);
                            newsEntityAdded.CompanyName = authorArticlesData.FirstOrDefault(x => x.MetaKey == "article_sponsored_company")?.MetaValue;

                            if (newsEntityAdded.CompanyName != null)
                                newsEntityAdded.IsAdvertising = true;
                        }

                        dbMS.FinwireNews.Add(newsEntityAdded);
                       //todo make generic method in helper etc, find better solution using EF Core
                       socialTagsAdded?.Distinct().ToList().ForEach(x =>
                           {
                              /* var socialTag = dbMS.FinwireSocialTags.FirstOrDefault(y => y.Tag == x.Tag);
                               if (socialTag == null)
                               {
                                   socialTag = dbMS.FinwireSocialTags.Add(new FinwireSocialTags { Tag = x.Tag}).Entity;
                                   //socialTag = dbMS.Add(new FinwireSocialTags {Tag = x.Tag}).Entity;
                                     db.SaveChanges();
                               }
                             
                               var socialTagID = dbMS.FinwireSocialTags.Where(y => y.Tag == x.Tag)?.FirstOrDefault().Id;*/
                               dbMS.FinwireNew2FirnwireSocialTag.Add(new FinwireNew2FirnwireSocialTag
                               {
                                   FinwireNew = newsEntityAdded,
                                   FinwireSocialTagId = (dbMS.FinwireSocialTags.Where(y => y.Tag == x)?.FirstOrDefault().Id).Value
                               });
                           }
                       );

                       companiesAdded?.Distinct().ToList().ForEach(x =>
                           {
                               /* var company = dbMS.Add(new FinwireCompanies {Company = x.Company}).Entity;

                              if (company == null)
                               {
                                   company = dbMS.Add(new FinwireCompanies {Company = x.Company}).Entity;
                                   db.SaveChanges();

                               }*/

                               dbMS.FinwireNew2FinwireCompany.Add(new FinwireNew2FinwireCompany
                               {
                                   FinwireNew = newsEntityAdded,
                                   FinwareCompanyId = (dbMS.FinwireCompanies.Where(y => y.Company == x)?.FirstOrDefault().Id).Value
                           });
                           }
                       );

                       i++;
                      
                       Console.WriteLine($"{Math.Round((DateTime.Now - dtStarted).TotalMinutes)} {i} / {total} - {Math.Round((double)i / total * 100)}%");
                       
                    });
                Console.WriteLine($"{DateTime.Now.ToString()} ================= Finish main transformation     ====================");
                dbMS.SaveChanges();
              //  Console.WriteLine($"{DateTime.Now.ToString()} ================= SAVED DATA. FINISHED     ====================");
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

        private static void SaveUploadedImagesNew(borsvarldenContext db)
        {
            //var filesAlreadySaved =
            //  File.ReadAllLines(Path.GetFullPath($@"{Directory.GetCurrentDirectory()}\..\..\..\UploadedImages.txt"));
            var dirRootToDownload = Path.GetFullPath($@"{Directory.GetCurrentDirectory()}\..\..\..\..\borsvarlden\wwwroot\assets\uploads");
             db.WpPostmeta.Where(x => x.MetaKey == "_wp_attached_file")
                .Select(x => x.MetaValue)
                .ToList()
                .ForEach(x =>
                    {
                        var subPath = x.Replace("/", "\\");
                        var dir = $@"{dirRootToDownload}\{subPath.Substring(0, subPath.LastIndexOf('\\'))}";

                        if (!Directory.Exists(dir))
                            Directory.CreateDirectory(dir);

                        var file = $@"{dirRootToDownload}\{subPath}";

                        if (!File.Exists(file))
                            ImageSaver.Save(x, dir);
                    }

                );
        }
    }
}
