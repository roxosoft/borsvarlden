using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using borsvarlden.Extensions;

namespace borsvarlden.Helpers
{
    public static class FileHelper
    {
        public static List<string> GetSubdirectories(string directoryPath)
        {
            return Directory
                .GetDirectories(directoryPath)
                .Select(x => Path.GetFileName(x))
                .ToList();
        }

        public static ImageData GetRandomImageFromDir(string directoryWithImages)
        {
            var image = Directory
                .GetFiles(directoryWithImages)
                .Select(x => x.ToLower())
                .Where(x => x.Contains(".jpg") || x.Contains(".jpeg") || x.Contains(".png") || x.Contains(".gif"))
                .ToList()
                .GetRandomElement();

            var ind = image.LastIndexOf(".");
            var dlt = image.Length - ind;
            var txtFile = image.Remove(ind, dlt);
            txtFile = $"{txtFile}.txt";
            var imageSource = "";

            if (File.Exists(txtFile))
                imageSource = File.ReadAllText(txtFile);

            return new ImageData
            {
                ImageAbsoluteUrl = image,
                ImageSource = imageSource
            };
        }

    }
}
