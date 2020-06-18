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

        private static string _uploadsPath =
            Path.GetFullPath($@"{Directory.GetCurrentDirectory()}\..\..\..\..\borsvarlden\wwwroot\assets\uploads");
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
            var classificatedImage = _imageFilesAvailable.FirstOrDefault(x=> x.Contains(inputPath.Substring(inputPath.LastIndexOf('/') + 1)));

            if (classificatedImage == null)
                Console.WriteLine(inputPath);

            classificatedImage = classificatedImage?.Substring(classificatedImage.IndexOf("wwwroot") + 8).Replace('\\', '/');

            if (classificatedImage == null)
            {
                var uploadedImage = $@"{_uploadsPath}\{inputPath.Replace("/","\\")}";

                if (File.Exists(uploadedImage))
                {
                    var urlUse = $"assets/uploads/{inputPath}";
                    return urlUse;
                }
            }

            return classificatedImage;
        }
    }
}
