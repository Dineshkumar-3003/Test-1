using CaliberHomes.GenericClasses;
using OpenQA.Selenium.Chrome;
using System;
using CaliberHomes.PageObjects;

namespace CaliberHomes.TestCases
{
    class CaliberCase1
    {
        
        public static void CaliberCase()
        {

            AppDriver.driver = new ChromeDriver();
            AppDriver.driver.Manage().Window.Maximize();

            //url To launch the application
            AppDriver.driver.Url = "https://calibercraftcmspoc.northcentralus.cloudapp.azure.com/chl-html/index.html";

            Home hpage = new Home();

            bool status = hpage.Send.Displayed;

            if (status == true)
            {
                Console.WriteLine("Launched and Valided successfully");
            }

            
            //hpage.UpArrow.Click();

            //hpage.Send.SendKeys("");

        }

    }

}
