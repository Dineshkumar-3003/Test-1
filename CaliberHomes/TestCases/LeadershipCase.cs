using AventStack.ExtentReports;
using CaliberHomes.GenericClasses;
using CaliberHomes.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;


namespace CaliberHomes.TestCases
{
    class LeadershipCase
    {
        public static void LeadershipTC()
        {

            AutomationUtils.Utils.CreateFileOrFolder("Case1");
            AppDriver.test = AppDriver.extent.CreateTest(" Leadership Page Validation");
            AppDriver.test.Log(Status.Info, " Test Execution Started");
            try
            {

                AppDriver.driver = new ChromeDriver();
                AppDriver.driver.Manage().Window.Maximize();

                //url To launch the application
                AppDriver.driver.Url = "https://calibercraftcmspoc.northcentralus.cloudapp.azure.com/leadership";

                LeadershipCase leadership = new LeadershipCase();

                //Locate webelement section
                IWebElement eSection = AppDriver.driver.FindElement(By.XPath("//*[@id='main']/section[2]/section"));

                IList<IWebElement> eRows = eSection.FindElements(By.CssSelector(".row"));
                foreach (IWebElement eRow in eRows)
                {
                    IList<IWebElement> eMembers = eRow.FindElements(By.CssSelector(".box"));
                    foreach (IWebElement eMember in eMembers)
                    {
                        String sImageName = null;
                        String sMemeberName = null;
                        IWebElement eExpand = null;
                        IWebElement eImage = null;
                        eImage = eMember.FindElement(By.TagName("img"));
                        sMemeberName = eMember.FindElement(By.CssSelector(".leadership-content")).FindElement(By.TagName("h3")).Text;
                        eExpand = eMember.FindElement(By.CssSelector(".leadership-content")).FindElement(By.TagName("i"));
                        if (eImage.Displayed)
                        {
                            sImageName = eImage.GetAttribute("src");
                            if (!(sImageName.Equals(null)) || !(sImageName.Equals("")))
                            {
                                Console.WriteLine("Image Available for " + sMemeberName);
                            }
                            else
                            {
                                Console.WriteLine("Image not Available for " + sMemeberName);
                            }

                        }
                        else
                        {
                            Console.WriteLine("Image not displayed");
                        }


                        if (eExpand.Displayed)
                        {
                            AppDriver.test.Log(Status.Pass, "Expand Button Clicked Successfully");
                            AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                            AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + "Case1" + "\\step3.png", ScreenshotImageFormat.Png);
                            AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + "Case1" + "\\step3.png").Build());

                        }
                        else
                        {
                            AppDriver.test.Log(Status.Fail, "Expand Button Clicked Successfully");
                            AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                            AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + "Case1" + "\\step3.png", ScreenshotImageFormat.Png);
                            AppDriver.test.Fail("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + "Case1" + "\\step3.png").Build());

                        }
                        Thread.Sleep(1000);
                        eExpand.Click();
                    }
                }
            }
            catch (Exception e)
            {
                AppDriver.driver.Quit();
                AppDriver.driver.Dispose();
                AppDriver.test.Log(Status.Fail, "Step End: Test Execution stopped due to error. " + e.Message);
            }
        
        }
    }
}