using CaliberHomes.GenericClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliberHomes.TestCases
{
    class HistoryCase
    {
        public static void historyTC()
        {

            AppDriver.driver = new ChromeDriver();
            //AppDriver.driver = new FirefoxDriver();
            //AppDriver.driver = new InternetExplorerDriver();
            AppDriver.driver.Manage().Window.Maximize();

            //url To launch the application
            AppDriver.driver.Url = "https://calibercraftcmspoc.northcentralus.cloudapp.azure.com/leadership";

            

        }
    }
}
