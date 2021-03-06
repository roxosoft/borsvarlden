﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using borsvarlden.Extensions;

namespace borsvarlden.Tests.UnitTests.Tests.TestExtensions
{
    class TestHtmlExtensions
    {
        [TestCase("BÖRS<br/>Handlas exklusive utdelning<br/>Heimstaden  för preferensaktien  (utd 5,00 kr), Lundin Petroleum  (utd 0,37 USD), Saltängen Property  (utd 2,45 kr)<br/><br/>Börshandel<br/>Tokyobörsen stängd<br/><br/>MAKRO<br/>01:30 Sydkorea PMI industri<br/>02:00 Irland PMI industri<br/>02:30 Filippinerna PMI industri<br/>02:30 Malaysia PMI industri<br/>02:30 Taiwan PMI industri<br/>02:30 Thailand PMI industri<br/>02:30 Vietnam PMI industri<br/>02:45 Kina PMI Caixin industri<br/>02:45 Kina PMI Caixin industri<br/>06:00 Indien PMI industri<br/>07:00 Estland detaljhandelsförsäljning<br/>08:30 Sverige PMI industri<br/>09:00 Nederländerna PMI industri<br/>09:00 Polen PMI industri<br/>09:00 Sverige månadsförsäljning av bilar och prognos 2020 från Bil Sweden<br/>09:15 Spanien PMI industri<br/>09:30 Sverige hushållens skuldsättning<br/>09:30 Tjeckien PMI industri<br/>09:45 Italien PMI industri<br/>09:50 Frankrike PMI industri reviderad<br/>09:55 Tyskland PMI industri reviderad<br/>10:00 EMU PMI industri reviderad<br/>10:30 Storbritannien PMI industri<br/>11:00 Danmark PMI industri<br/>13:00 USA ansökan om bolån<br/>14:00 Brasilien PMI industri<br/>14:30 USA antalet nya arbetslösa, veckostatistik<br/>15:30 Kanada PMI industri<br/>15:45 USA PMI industri reviderad<br/>15:45 USA Bloomberg Consumer Comfort<br/>16:30 Mexiko PMI industri<br/>17:00 Global PMI industri JP Morgan<br/>Japan helgdag",
                  "BÖRS<br/>Handlas exklusive utdelning<br/>Heimstaden  för preferensaktien  (utd 5,00 kr), Lundin Petroleum  (utd 0,37 USD), Saltängen Property  (utd 2,45 kr)")]

        [TestCase("USA:s president Donald Trump höll på eftermiddagen svensk tid presskonferens med anledning av nattens iranska raketattacker mot amerikanska militärbaser i Irak.<br/><br/>Donald Trump inledde med att Iran aldrig kommer att tillåtas att ha kärnvapen så länge som han är president.<br/><br/>Han sa också bland annat att:<br/><br/>- Inga amerikanska soldater skadades i nattens attacker.<br/><br/>- USA kommer att införa ytterligare sanktioner mot Iran.<br/><br/>- USA kommer be Nato att bli mer involverade i Mellanöstern.<br/><br/>- USA och Iran borde samarbeta i kampen mot ISIS.<br/><br/>Donald Trump berörde också kärnavtalet som Iran har med flera länder.<br/><br/>Donald Trump avslutade med att USA är redo att omfamna fred med alla som vill ha det.",
            "USA:s president Donald Trump höll på eftermiddagen svensk tid presskonferens med anledning av nattens iranska raketattacker mot amerikanska militärbaser i Irak.")]

        public void TestFistParagraph(string inputString, string expectedString)
        {
            var res = inputString.FistParagraph();
            Assert.AreEqual(expectedString, res);
        }

        [TestCase("<![CDATA[<span class=\"generated_text\">Totala antalet aktiva olje- och gasriggar i USA sjönk under senaste rapportveckan. Det visar veckosiffror från Houstonbaserade oljeservicebolaget Baker Hughes.<br><br>Det totala antalet olja- och gasriggar uppgick till 301 stycken, vilket kan jämföras med  föregående vecka då antalet var 318 stycken.<br><br>Oljeriggarna var 222 stycken, att jämföra med veckan innan då antalet var 237. Antalet gasriggar uppgick till 77 stycken (79).<br></span><br><table><tbody><tr><td>USA</td><td>v22</td><td>v21</td></tr><tr><td>Totalt antal riggar</td><td>301</td><td>318</td></tr><tr><td>Antal oljeriggar</td><td>222</td><td>237</td></tr><tr><td>Antal gasriggar</td><td>77</td><td>79</td></tr></tbody></table>]]>",
            "Totala antalet aktiva olje- och gasriggar i USA sjönk under senaste rapportveckan. Det visar veckosiffror från Houstonbaserade oljeservicebolaget Baker Hughes.<br><br>Det totala antalet olja- och gasriggar uppgick till 301 stycken, vilket kan jämföras med  föregående vecka då antalet var 318 stycken.<br><br>Oljeriggarna var 222 stycken, att jämföra med veckan innan då antalet var 237. Antalet gasriggar uppgick till 77 stycken (79).<br><br><table><tbody><tr><td>USA</td><td>v22</td><td>v21</td></tr><tr><td>Totalt antal riggar</td><td>301</td><td>318</td></tr><tr><td>Antal oljeriggar</td><td>222</td><td>237</td></tr><tr><td>Antal gasriggar</td><td>77</td><td>79</td></tr></tbody></table>")]

        [TestCase("<![CDATA[Fastighetsbolaget Genova Property har avtalat om att förvärva samhällsfastigheten Flogsta 47:1 i Ekeby, Uppsala till ett underliggande fastighetsvärde om 350 miljoner kronor. Säljare är fastighetsbolaget SBB. Det framgår av ett pressmeddelande. <br><br>Fastigheten har en uthyrbar area på 16 500 kvadratmeter och den årliga hyresintäkten är 26 miljoner kronor. Tillträde är planerat till 30 oktober 2020. Genovas förvärv finansieras med en kombination av lån och egna medel.]]>",
                   "Fastighetsbolaget Genova Property har avtalat om att förvärva samhällsfastigheten Flogsta 47:1 i Ekeby, Uppsala till ett underliggande fastighetsvärde om 350 miljoner kronor. Säljare är fastighetsbolaget SBB. Det framgår av ett pressmeddelande. <br><br>Fastigheten har en uthyrbar area på 16 500 kvadratmeter och den årliga hyresintäkten är 26 miljoner kronor. Tillträde är planerat till 30 oktober 2020. Genovas förvärv finansieras med en kombination av lån och egna medel.")]
        public void TestParseHtmlText(string input, string expected)
        {
            var output = input.ParseHtmlText();
            Assert.AreEqual(expected, output);
        }

        [TestCase("Totala antalet aktiva olje- och gasriggar i USA sjönk under senaste rapportveckan. Det visar veckosiffror från Houstonbaserade oljeservicebolaget Baker Hughes.<br><br>Det totala antalet olja- och gasriggar uppgick till 301 stycken, vilket kan jämföras med  föregående vecka då antalet var 318 stycken.<br><br>Oljeriggarna var 222 stycken, att jämföra med veckan innan då antalet var 237. Antalet gasriggar uppgick till 77 stycken (79).<br><br><table><tbody><tr><td>USA</td><td>v22</td><td>v21</td></tr><tr><td>Totalt antal riggar</td><td>301</td><td>318</td></tr><tr><td>Antal oljeriggar</td><td>222</td><td>237</td></tr><tr><td>Antal gasriggar</td><td>77</td><td>79</td></tr></tbody></table>")]
        public void TestSplitSubtitleAndNews(string input)
        {
            (string sunbtitle, string htmltext) = input.SplitSubtitleAndNews();
        }
    }
}
