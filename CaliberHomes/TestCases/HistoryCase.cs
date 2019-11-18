using CaliberHomes.GenericClasses;
using CaliberHomes.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using AventStack.ExtentReports;
using System.Configuration;

namespace CaliberHomes.TestCases
{
    class HistoryCase
    {
            
        public static void HistoryTC()
        {
            AutomationUtils.Utils.CreateFileOrFolder("Case1");
            AppDriver.test = AppDriver.extent.CreateTest(" History Page Validation");
            AppDriver.test.Log(Status.Info, " Test Execution Started");
            try
            {
                AppDriver.driver = new ChromeDriver();
                AppDriver.driver.Manage().Window.Maximize();

                //url To launch the application
                AppDriver.driver.Url = "https://calibercraftcmspoc.northcentralus.cloudapp.azure.com/history";

                History HistoryPage = new History();

                //Locate webelement section
                IWebElement eTextSection = AppDriver.driver.FindElement(By.XPath("//*[@id='main']/section[2]/div/div/div/ul"));

                IList<IWebElement> eTextRows = eTextSection.FindElements(By.TagName("li"));
                Console.WriteLine("Number of years:" + eTextRows.Count);
                foreach (IWebElement eRow in eTextRows)
                {

                    String sTextName = null;
                    IWebElement eTimeline = null;
                    eTimeline = eRow;
                    sTextName = eRow.Text;
                    if (eTimeline.Displayed)
                    {
                        Console.WriteLine("Timeline Available for " + sTextName);

                    }
                    else
                    {
                        Console.WriteLine("Timeline not displayed");
                    }

                }

                //Locate webelement section
                IWebElement eSection = AppDriver.driver.FindElement(By.XPath("//*[@id='main']/section[3]/div/div"));
                IList<IWebElement> eHeadings = eSection.FindElements(By.CssSelector(".box"));
                Console.WriteLine(eHeadings.Count);
                int iHeadingsCount = eHeadings.Count;

                for (int i = 1; i <= iHeadingsCount; i++)
                {
                    IWebElement eSectionTemp = AppDriver.driver.FindElement(By.XPath("//*[@id='main']/section[3]/div/div"));
                    IList<IWebElement> eHeadingsTemp = eSectionTemp.FindElements(By.CssSelector(".box"));
                    int iTempNumber = 0;
                    foreach (IWebElement eHeading in eHeadingsTemp)
                    {
                        iTempNumber = iTempNumber + 1;
                        if (iTempNumber == i)
                        {
                            String sImageName = null;
                            String sHeadingName = null;
                            String ebtnName = null;
                            IWebElement ebtnClick = null;
                            IWebElement eImage = null;
                            eImage = eHeading.FindElement(By.TagName("img"));
                            sHeadingName = eHeading.FindElement(By.CssSelector(".col-md-9")).FindElement(By.TagName("h3")).Text;
                            ebtnName = eHeading.FindElement(By.CssSelector(".col-md-9")).FindElement(By.TagName("a")).Text;
                            ebtnClick = eHeading.FindElement(By.CssSelector(".col-md-9")).FindElement(By.TagName("a"));
                            if (eImage.Displayed)
                            {
                                sImageName = eImage.GetAttribute("src");
                                if (!(sImageName.Equals(null)) || !(sImageName.Equals("")))
                                {
                                    Console.WriteLine("Image Available for " + sHeadingName);
                                }
                                else
                                {
                                    Console.WriteLine("Image not Available for " + sHeadingName);
                                }

                            }
                            else
                            {
                                Console.WriteLine("Image not displayed");
                            }

                            if (ebtnClick.Displayed)
                            {
                                Console.WriteLine(ebtnName + "Button displayed");

                            }

                            else
                            {
                                Console.WriteLine("Button not displayed");
                            }

                            
                            if (ebtnClick.Displayed)
                            {
                                AppDriver.test.Log(Status.Pass, ebtnName + "Button displayed and Clicked");
                                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + "Case1" + "\\step1.png", ScreenshotImageFormat.Png);
                                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + "Case1" + "\\step1.png").Build());
                                
                            }
                            else
                            {
                                AppDriver.test.Log(Status.Fail, ebtnName + "Button not displayed");
                                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + "Case1" + "\\step1.png", ScreenshotImageFormat.Png);
                                AppDriver.test.Fail("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + "Case1" + "\\step1.png").Build());
                                
                            }

                            ebtnClick.Click();
                            Console.WriteLine(ebtnName + "Button Clicked");
                            Thread.Sleep(1000);                           

                        }

                    }

                }

            }
            catch(Exception e)
            {
                AppDriver.driver.Quit();
                AppDriver.driver.Dispose();
                AppDriver.test.Log(Status.Fail, "Step End: Test Execution stopped due to error. " + e.Message);
            }
            //AppDriver.driver.Close();
        }
       
    }
}




