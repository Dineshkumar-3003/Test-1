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
    class LeadershipPO
    {
        public LeadershipPO()
        {
            PageFactory.InitElements(AppDriver.driver, this);
        }
        [FindsBy(How=How.XPath, Using = "(//i[@class='fa fa-angle-double-down'])[1]")]
        public IWebElement expand { get; set; }

        [FindsBy(How = How.XPath, Using = "(//i[@class='fa fa-angle-double-down'])[1]")]
        public IWebElement collapse { get; set; }


    }
}
