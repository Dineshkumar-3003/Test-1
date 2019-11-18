using CaliberHomes.GenericClasses;
using OpenQA.Selenium.Chrome;
using System;
using CaliberHomes.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using AventStack.ExtentReports;
using System.Configuration;

namespace CaliberHomes.TestCases
{
    public class HomeCase
    {
        public static void HomeTC()
        {
            AutomationUtils.Utils.CreateFileOrFolder("Case1");
            AppDriver.test = AppDriver.extent.CreateTest(" Home Page Validation");
            AppDriver.test.Log(Status.Info, " Test Execution Started");

            try
            {
                AppDriver.driver = new ChromeDriver();
                AppDriver.driver.Manage().Window.Maximize();

                //url To launch the application
                AppDriver.driver.Url = "https://calibercraftcmspoc.northcentralus.cloudapp.azure.com/";

                Home hpage = new Home();

                IJavaScriptExecutor js = (IJavaScriptExecutor)AppDriver.driver;
                //js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

                if (hpage.Banner != null)
                {
                    Console.WriteLine("Banner Element is Exist");
                }

                if (hpage.Purchasebtn != null)
                {
                    Console.WriteLine("Purchase Button Element is Exist in Banner");
                }

                if (hpage.Refinancebtn != null)
                {
                    Console.WriteLine("Refinance Button Element is Exist in Banner");
                }

                IWebElement eTemp = AppDriver.driver.FindElement(By.XPath("//*[@id='calculator']/div/div/div/h2"));
                js.ExecuteScript("arguments[0].scrollIntoView();", eTemp);

                bool status1 = eTemp.Displayed;

                if (status1 == true)
                {
                    Console.WriteLine("Estimate your monthly payment Text Element is Exist");
                }

                Thread.Sleep(1000);

                hpage.HomeValue.Clear();
                hpage.HomeValue.SendKeys("600,000");

                hpage.DownPayment.Clear();
                hpage.DownPayment.SendKeys("50,000");

                hpage.LoanLength.Clear();
                hpage.LoanLength.SendKeys("15");

                hpage.InterestRate.Clear();
                hpage.InterestRate.SendKeys("12");

                hpage.AnnualTaxes.Clear();
                hpage.AnnualTaxes.SendKeys("4000");

                hpage.HomeInsurance.Clear();
                hpage.HomeInsurance.SendKeys("1000");

                Thread.Sleep(1500);

                if (hpage.Analysis != null)
                {
                    Console.WriteLine("Analysis Clicked Successfully");
                }

                hpage.Analysis.Click();
                Thread.Sleep(1000);
                hpage.EducationCarousel1.Click();
                hpage.EducationCarousel.Click();

                Thread.Sleep(1500);
                IWebElement Contact = AppDriver.driver.FindElement(By.XPath("//*[@id='main']/section[6]/div/div[1]"));
                js.ExecuteScript("arguments[0].scrollIntoView();", Contact);

                bool status = hpage.Send.Displayed;

                if (status == true)
                {
                    Console.WriteLine("Send button Element is Exist");
                }

                hpage.HelpText.Click();
                hpage.HelpText.SendKeys("Test");
                hpage.Name.SendKeys("Ram");
                hpage.Mobile.SendKeys("123456785");
                hpage.Email.SendKeys("ABC@gmail.com");
                hpage.Zipcode.SendKeys("650101");

                //hpage.Send.Click();      

                if (hpage.UpArrow != null)
                {
                    Console.WriteLine("UpArrow icon Element is Exist");
                }

                //hpage.UpArrow.Click();
                Thread.Sleep(7000);

                if (hpage.Send.Displayed)
                {
                    AppDriver.test.Log(Status.Pass, "Home Page Validated Successfully");
                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + "Case1" + "\\step2.png", ScreenshotImageFormat.Png);
                    AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + "Case1" + "\\step2.png").Build());
                    AppDriver.test.Log(Status.Info, " Test Execution Completed");

                }
                else
                {
                    AppDriver.test.Log(Status.Fail, "Home Page Validated Successfully");
                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + "Case1" + "\\step2.png", ScreenshotImageFormat.Png);
                    AppDriver.test.Fail("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + "Case1" + "\\step2.png").Build());
                    AppDriver.test.Log(Status.Info, " Test Execution not Completed");

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

