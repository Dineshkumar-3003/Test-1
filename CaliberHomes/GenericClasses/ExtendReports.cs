using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Net;

namespace CaliberHomes.GenericClasses
{
    public class ExtendReports
{
        public static void Extent_Test(string htmlFilepath)
        {
            //Html Report Initialization
            AppDriver.htmlReporter = new ExtentHtmlReporter(htmlFilepath);
            AppDriver.htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            AppDriver.extent = new ExtentReports();
            AppDriver.extent.AttachReporter(AppDriver.htmlReporter);
            string hostname = Dns.GetHostName();
            OperatingSystem OS = Environment.OSVersion;
            AppDriver.extent.AddSystemInfo("Operating System", OS.ToString());
            AppDriver.extent.AddSystemInfo("HostName", hostname);
           //AppDriver.extent.AddSystemInfo("Browser", AppDriver.driver.GetType().ToString());
            AppDriver.extent.AddSystemInfo("Browser", "IE");
    }

    public static bool IsElementPresent(By by)
    {
        try
        {
            AppDriver.driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
}

