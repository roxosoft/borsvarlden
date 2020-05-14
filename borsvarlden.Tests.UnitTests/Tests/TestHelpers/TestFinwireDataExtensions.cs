using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using borsvarlden.Extensions;
using borsvarlden.Services.Finwire;

namespace borsvarlden.Tests.UnitTests.Tests.TestHelpers
{
    class TestFinwireDataExtensions
    {
        
        [TestCase("USA:s president Donald Trump höll på eftermiddagen svensk tid presskonferens med anledning av nattens iranska raketattacker mot amerikanska militärbaser i Irak.<br/><br/>Donald Trump inledde med att Iran aldrig kommer att tillåtas att ha kärnvapen så länge som han är president.<br/><br/>Han sa också bland annat att:<br/><br/>- Inga amerikanska soldater skadades i nattens attacker.<br/><br/>- USA kommer att införa ytterligare sanktioner mot Iran.<br/><br/>- USA kommer be Nato att bli mer involverade i Mellanöstern.<br/><br/>- USA och Iran borde samarbeta i kampen mot ISIS.<br/><br/>Donald Trump berörde också kärnavtalet som Iran har med flera länder.<br/><br/>Donald Trump avslutade med att USA är redo att omfamna fred med alla som vill ha det."
                 ,"USA:s president Donald Trump höll på eftermiddagen svensk tid presskonferens med anledning av nattens iranska raketattacker mot amerikanska militärbaser i Irak."
                 ,"Donald Trump inledde med att Iran aldrig kommer att tillåtas att ha kärnvapen så länge som han är president.<br/><br/>Han sa också bland annat att:<br/><br/>- Inga amerikanska soldater skadades i nattens attacker.<br/><br/>- USA kommer att införa ytterligare sanktioner mot Iran.<br/><br/>- USA kommer be Nato att bli mer involverade i Mellanöstern.<br/><br/>- USA och Iran borde samarbeta i kampen mot ISIS.<br/><br/>Donald Trump berörde också kärnavtalet som Iran har med flera länder.<br/><br/>Donald Trump avslutade med att USA är redo att omfamna fred med alla som vill ha det.")]

        [TestCase("Bengt Jöndell har den 7 januari köpt 5 000 aktier i forskningsbolaget Cantargia där han är finanschef. Aktierna köptes till kursen 18,70 kronor per aktie, en affär på 93 500 kronor. Affären gjordes på Nasdaq Stockholm. Det framgår av Finansinspektionens insynsregister."
                 ,"Bengt Jöndell har den 7 januari köpt 5 000 aktier i forskningsbolaget Cantargia där han är finanschef. Aktierna köptes till kursen 18,70 kronor per aktie, en affär på 93 500 kronor. Affären gjordes på Nasdaq Stockholm. Det framgår av Finansinspektionens insynsregister."
                 ,"Bengt Jöndell har den 7 januari köpt 5 000 aktier i forskningsbolaget Cantargia där han är finanschef. Aktierna köptes till kursen 18,70 kronor per aktie, en affär på 93 500 kronor. Affären gjordes på Nasdaq Stockholm. Det framgår av Finansinspektionens insynsregister.")]
        public void Test(string inpuNewsText, string expectedSubtitle, string expectedNewsText)
        {
            var data = new FinWireData {NewsText = inpuNewsText}.BuildSubtitle();
            Assert.AreEqual(expectedSubtitle, data.SubTitle);
            Assert.AreEqual(expectedNewsText, data.NewsText);
        }
    }
}
