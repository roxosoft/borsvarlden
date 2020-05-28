using System;
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
                        dbMS.FinwireNews.Add(
                            new FinwireNews()
                            {
                                IsConvertedFromMySql = true,
                                NewsText = p.Post.Post.PostContent,
                                Title = p.Post.Post.PostTitle,
                                Date = p.Post.Post.PostDate,
                                ImageRelativeUrl = p.Meta.MetaValue.ToNewImageFilePath(),
                                Slug = p.Post.Post.PostName
                            });
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
