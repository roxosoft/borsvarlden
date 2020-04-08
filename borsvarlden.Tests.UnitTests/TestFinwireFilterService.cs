using System;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using borsvarlden.Db;
using borsvarlden.Services.Entities;
using borsvarlden.Services.Finwire;

namespace borsvarlden.Tests.UnitTests
{
    [TestFixture]
    class TestFinwireFilterService
    {
        private FinwireFilterService _finwireFilterService = new FinwireFilterService(SetUp.ApplicationContext);

        [SetUp]
        public void Setup()
        {
         
        }

        [TestCaseSource("CountIsFilterPassedTest")]
        public void TestIsPassed (Tuple<bool, FinWireData> inputData)
        {
            Assert.AreEqual(inputData.Item1, _finwireFilterService.IsFilterPassed(inputData.Item2));
        }

        public static IEnumerable<Tuple<bool,FinWireData>> CountIsFilterPassedTest
        {
            get { yield return new Tuple<bool, FinWireData>(false, new FinWireData() {Title = "foo"}); }
        }

        public static IEnumerator<List<string>> CountIsSocialTagsPassedTest
        {
            get {  yield return new List<string>{""};} 
        }

        [TestCase("Dagens aktierekommendationer i översikt", true)]
        [TestCase("Dagens aktierekommendationer I översikt", true)]
        [TestCase("Stocks in Play", true)]
        [TestCase("Stockholm Bullets", true)]
        [TestCase("foo", false)]
        public void TestFilterTagWhiteList(string tag, bool expectedResult)
        {
            Assert.AreEqual(expectedResult,_finwireFilterService.IsTitleWhiteListPassed(tag) );
        }

        [TestCase("(uppdatering)", true)]
        [TestCase("(uppdaterad)", true)]
        [TestCase("(Oms)", true)]
        [TestCase("(forts)", true)]
        [TestCase("(omsändning)", true)]
        [TestCase("(r)", true)]
        [TestCase("(rättelse)", true)]
        [TestCase("foo", false)]
        public void TestFilterTagBlackListNotPassed(string tag, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, _finwireFilterService.IsTagBlackFilterNotPassed(tag));
        }
    }
}
