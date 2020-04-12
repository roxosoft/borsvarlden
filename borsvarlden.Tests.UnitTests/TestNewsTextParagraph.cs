using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using borsvarlden.Services.Finwire;
using borsvarlden.Tests.UnitTests.Helpers;

namespace borsvarlden.Tests.UnitTests
{
    public class TestNewsTextNewLine
    {
        [TestCase(1)]
        public void TestParseAllFiles(int dummy)
        {
            var pathBase = $@"{UnitTestConfig.TestDataPath}\FinwireFiles";
            string st = "";

            var patterns = new List<string>()
            {
                "\n",
                "\n\n",
                "\n\n",
                "<br>",
                "<BR>",
                "<br><br>",
                "<br><br><br>",
                "<p>"
            };
            var occurenceInFiles = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 1; i <= 8; i++)
            {
                //there is no data
                if (i == 4 || i == 5)
                    continue;

                var path = $@"{pathBase}\{i.ToString("D2")}";

                Dictionary<string, int> patternOccurence = new Dictionary<string, int>();
                patterns.ForEach(pattern => patternOccurence[pattern] = 0);

                foreach (var file in Directory.GetFiles(path))
                {
                    var text = UnitTestHelper.ParseNewsFile(path).HtmlText.Trim();
                    if (text.Contains("\n\n"))
                        System.Threading.Thread.Sleep(0);
                    //if (t.Contains("<p>"))
                    //  System.Threading.Thread.Sleep(100);
                    //if (t.Contains("</p"))
                    //  System.Threading.Thread.Sleep(100);

                    occurenceInFiles[file] = new Dictionary<string, int>();
                    patterns.ForEach(x => occurenceInFiles[file][x] = 0);


                    foreach (var keyValuePair in patternOccurence)
                    {
                      // patternOccurence[keyValuePair.Key] = text.Count(x => x == keyValuePair.Key);
                      //patternOccurence[keyValuePair.]
                       var count =  Regex.Matches(text, keyValuePair.Key).Count;
                       occurenceInFiles[file][keyValuePair.Key] = count;
                    }
                }

                foreach (var kvp in occurenceInFiles)
                {
                    st += $"{kvp.Key}\n";
                    foreach (var kvp2 in kvp.Value)
                    {
                        //var pat = kvp2.Key.Contains(@"\") ? $@"\{kvp2.Key}" : kvp2.Key;
                        var pat = kvp2.Key.Replace("\n", @"\n");
                        st += $"[{pat}] => {kvp2.Value}\n";
                      
                    }
                    st += "===================================\n";
                }
            }

            var r = occurenceInFiles.ToList();
            var m = r.Where(x => x.Value["<br><br>"] >= 3).ToList();
            var m1 = r.Where(x => x.Value["<BR>"] > 0).ToList();
            // var r = occurenceInFiles.ToList().Where(x => x.Value.ToList().Where(x=>x.Key==""));
        }

        /* private class PatterOccurence
         {
             public string Pattern { get; set; }
             public int Count { get; set; }
         }
         */
    }
}
