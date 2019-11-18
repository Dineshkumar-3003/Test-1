using System;
using OpenQA.Selenium;
using CaliberHomes.GenericClasses;
using SeleniumExtras.PageObjects;

namespace CaliberHomes.PageObjects
{
    class History
    {
        public History()
        {
            PageFactory.InitElements(AppDriver.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/section[3]/div/div/div[1]/div/div/div[2]/p[2]/a")]
        public IWebElement BtnCalculator { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/section[3]/div/div/div[2]/div/div/div[2]/p[2]/a")]
        public IWebElement BtnFreshStart { get; set; }


    }
}
