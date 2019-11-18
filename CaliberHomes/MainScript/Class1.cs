using System;
using CaliberHomes.TestCases;
using NUnit.Framework;
using System.Configuration;
using CaliberHomes.GenericClasses;


namespace CaliberHomes
{
    public class Class1
    {
        [SetUp]
        public void Initializer()
        {
            ExtendReports.Extent_Test(ConfigurationManager.AppSettings["ReportsPath"] + "Test Execution_Report.html");
        }
        [Test]
        public void CaliberHomes()
        {
            HomeCase.HomeTC();
            LeadershipCase.LeadershipTC();
            HistoryCase.HistoryTC();
        }      
        [TearDown]
        public void CloseBrowser()
        {
            AppDriver.extent.Flush();
        }

    }
}
