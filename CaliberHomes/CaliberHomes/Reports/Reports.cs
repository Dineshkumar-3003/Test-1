using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Net;
using CaliberHomes.GenericClasses;

namespace CaliberHomes.Reports
{
    public class Reports
    {
        public static void Extent_Test(string htmlFilepath)
        {
            //Html Report Initialization
            AppDriver.htmlReporter = new ExtentHtmlReporter(htmlFilepath);
            AppDriver.htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            AppDriver.extent = new ExtentReports();
            AppDriver.extent.AttachReporter(AppDriver.htmlReporter);
            string hostname = Dns.GetHostName();
            OperatingSystem OS = Environment.OSVersion;
            AppDriver.extent.AddSystemInfo("Operating System", OS.ToString());
            AppDriver.extent.AddSystemInfo("HostName", hostname);
            //AppDriver.extent.AddSystemInfo("Browser", AppDriver.driver.GetType().ToString());
            AppDriver.extent.AddSystemInfo("Browser", "IE");
        }
    }
}



