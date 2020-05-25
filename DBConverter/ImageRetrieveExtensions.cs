using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DBConverter
{
    public static class ImageRetrieveExtensions
    {
        private static string _imagesPath = Path.GetFullPath($@"{Directory.GetCurrentDirectory()}\..\..\..\..\borsvarlden\wwwroot\assets\images\finauto");
        private static List<string> _imageFilesAvailable = new List<string>();

        static ImageRetrieveExtensions()
        {
            new List<string>
            {
                $@"{_imagesPath}\company",
                $@"{_imagesPath}\socialtag",
                $@"{_imagesPath}\other"

            }.ForEach(x =>
                {
                    Directory.GetDirectories(x)
                        .ToList()
                        .ForEach(y => _imageFilesAvailable.AddRange(Directory.GetFiles(y).ToList()));
                }
            );
        }

        public static string ToNewImageFilePath(this string inputPath)
        {
            var r = _imageFilesAvailable.FirstOrDefault(x=> x.Contains(inputPath.Substring(inputPath.LastIndexOf('/') + 1)));

            if (r == null)
                Console.WriteLine(inputPath);

            r = r?.Substring(r.IndexOf("wwwroot") + 8).Replace('\\', '/');

            return r;
        }
    }
}
