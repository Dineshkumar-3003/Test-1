using CaliberHomes.GenericClasses;
using CaliberHomes.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaliberHomes.TestCases
{
    class LeadershipCase
    {
        public static void LeadershipTC()
        {

            AppDriver.driver = new ChromeDriver();
            //AppDriver.driver = new FirefoxDriver();
            //AppDriver.driver = new InternetExplorerDriver();
            AppDriver.driver.Manage().Window.Maximize();

            //url To launch the application
            AppDriver.driver.Url = "https://calibercraftcmspoc.northcentralus.cloudapp.azure.com/leadership";
                    
            //Locate webelement section
            IWebElement eSection = AppDriver.driver.FindElement(By.XPath("//*[@id='main']/section[2]/section"));

            IList<IWebElement> eRows = eSection.FindElements(By.CssSelector(".row"));
            //Console.WriteLine("Number of rows:"+eRows.Count);
            foreach (IWebElement eRow in eRows)
            {
                IList<IWebElement> eMembers = eRow.FindElements(By.CssSelector(".box"));
                //Console.WriteLine("Number of members:" + eMembers.Count);
                foreach (IWebElement eMember in eMembers)
                {
                    String sImageName = null;
                    String sMemeberName = null;
                    IWebElement eExpand = null;
                    IWebElement eImage = null;
                    eImage = eMember.FindElement(By.TagName("img"));
                    sMemeberName = eMember.FindElement(By.CssSelector(".leadership-content")).FindElement(By.TagName("h3")).Text;
                    eExpand = eMember.FindElement(By.CssSelector(".leadership-content")).FindElement(By.TagName("i"));
                    //Console.WriteLine("Name:" + sMemeberName);
                    if (eImage.Displayed)
                    {
                        sImageName = eImage.GetAttribute("src");
                        if (!(sImageName.Equals(null)) || !(sImageName.Equals("")))
                        {
                            Console.WriteLine("Image Available for "+ sMemeberName);
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
                    Thread.Sleep(1000);
                    eExpand.Click();
                    //Console.WriteLine("Clicked on expand");



                }
            }

            //LeadershipPO leadership = new LeadershipPO();
            //leadership.expand.Click();
            //AppDriver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //IJavaScriptExecutor js = (IJavaScriptExecutor)AppDriver.driver;
            //IWebElement expand = AppDriver.driver.FindElement(By.XPath("(//span[@class='partial'])[1]"));
            //js.ExecuteScript("arguments[0].scrollIntoView();", expand);

            //ITakesScreenshot screenshotDriver = AppDriver.driver as ITakesScreenshot;
            //Screenshot screenshot = screenshotDriver.GetScreenshot();
            //screenshot.SaveAsFile(@"C:\Users\viswak.j\Desktop\CHL\test.png", ScreenshotImageFormat.Png);

            //Thread.Sleep(3000);

            //leadership.collapse.Click();
            //AppDriver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //IWebElement collapse = AppDriver.driver.FindElement(By.XPath("//li[@class='breadcrumb-item active']"));
            //js.ExecuteScript("arguments[0].scrollIntoView();", collapse);


            //IList<IWebElement> selectElements = AppDriver.driver.FindElements(By.XPath("(//span[@class='btn-read-more']//i)"));
            //selectElements.Count();
            //var displayedSelectElements = selectElements.Where(se => se.Displayed);
            //foreach(IWebElement eleExpand in selectElements)
            //{
            //    Thread.Sleep(1000);
            //    eleExpand.Click();

            //}

            //IList<IWebElement> images = AppDriver.driver.FindElements(By.XPath("(//div[@class='box']//img)"));

            //foreach (IWebElement listofimages in images)
            //{
            //    bool status = listofimages.Displayed;

            //    if (status = true)
            //    {
            //        Console.WriteLine("Image Available for ");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Image Not Available for ");
            //    }

            //    //ITakesScreenshot screenshotDriver1 = AppDriver.driver as ITakesScreenshot;
            //    //Screenshot screenshot1 = screenshotDriver.GetScreenshot();
            //    //screenshot.SaveAsFile(@"C:\Users\viswak.j\Desktop\CHL\Image.png", ScreenshotImageFormat.Png);

            //}

            //for (int i = 1; i < 5; i++)
            //{
            //    bool status =
            //    AppDriver.driver.FindElement(By.XPath("(//div[@class='box']//img[" + i + "]")).Displayed;
            //    //AppDriver.driver.FindElement(By.XPath("(//div[@class='leadership-content']//h3)[" + i + "]"));
            //    if (status = true)
            //    {
            //        Console.WriteLine("Image Available");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Image Not Available");
            //    }
            //}




        }
    }
}