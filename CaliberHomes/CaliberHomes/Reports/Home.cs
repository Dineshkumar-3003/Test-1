using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using CaliberHomes.GenericClasses;

namespace CaliberHomes.PageObjects
{
    class Home
    {

        public Home()
        {
            PageFactory.InitElements(AppDriver.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/section[6]/div/div[2]/form/button")]
        public IWebElement Send { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='toTop']/i")]
        public IWebElement UpArrow { get; set; }

    }
}
