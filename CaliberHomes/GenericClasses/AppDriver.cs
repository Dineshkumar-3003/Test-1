﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;


namespace CaliberHomes.GenericClasses
{
       enum ProperType
        {
            id,
            name,
            linkText,
            xpath
        }
        class AppDriver
        {
            public static IWebDriver driver { get; set; }
            private string strInfo { get; set; }           
            public static ExtentHtmlReporter htmlReporter { get; set; }
            public static ExtentReports extent { get; set; }
            public static ExtentTest test { get; set; }

            public static Screenshot file;

        }

}

