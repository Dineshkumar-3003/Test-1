using OpenQA.Selenium;
using CaliberHomes.GenericClasses;
using SeleniumExtras.PageObjects;

namespace CaliberHomes.PageObjects
{
    class Leadership
    {
        public Leadership()
        {
            PageFactory.InitElements(AppDriver.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement Banner { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement HomeValue { get; set; } 

    }
}
