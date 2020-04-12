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

        public static string GetRandomImageFromDir(string directoryWithImages)
        {
             return Directory
                .GetFiles(directoryWithImages)
                .Select(x => x.ToLower())
                .Where(x => x.Contains(".jpg") || x.Contains(".jpeg") || x.Contains(".png") || x.Contains(".gif"))
                .ToList()
                .GetRandomElement();
        }

       
    }
}
