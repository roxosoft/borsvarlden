using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;

namespace DBConverter
{
    public static class ImageSaver
    {
        public static void Save(string urlfragment, string dirToSave)
        {
            var url = $@"https://borsvarlden.com/wp-content/uploads/{urlfragment}";
            var w = new WebClient();
            var filename = $@"{dirToSave}\{urlfragment.Substring(urlfragment.LastIndexOf('/') + 1)}";
            try
            {
                w.DownloadFile(url, filename);
            }
            catch
            {
                Console.WriteLine(url);
            }
        }
    }
}
