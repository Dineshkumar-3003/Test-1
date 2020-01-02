using CaliberHomes.GenericClasses;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliberHomes.PageObjects
{
    class HistoryPO
    {
        public HistoryPO()
        {
            PageFactory.InitElements(AppDriver.driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//img[@data-image='fwxo68rmxqya']")]
        public IWebElement image { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@class='btn btn-outline-dark'])[1]")]
        public IWebElement GTCbutton { get; set; }
    }
}