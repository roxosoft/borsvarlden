using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace borsvarlden.Tests.UnitTests.Helpers
{
    static class RestConnector
    {
        public static string GetData(string url, string method, string postData)
        {
            var data = Encoding.ASCII.GetBytes(postData);
            var request = WebRequest.Create(url);
            request.Method = method;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString =  new StreamReader(response?.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }
}
