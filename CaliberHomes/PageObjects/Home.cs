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

        [FindsBy(How = How.XPath, Using = "/html/body/section[1]")]
        public IWebElement Banner { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/section[1]/div/div/div/a[1]")]
        public IWebElement Purchasebtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/section[1]/div/div/div/a[2]")]
        public IWebElement Refinancebtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='homeValue']")]
        public IWebElement HomeValue { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='down']")]
        public IWebElement DownPayment { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='downPercent']")]
        public IWebElement DownPaymentPercentage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='years']")]
        public IWebElement LoanLength { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='APR']")]
        public IWebElement InterestRate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='anTax']")]
        public IWebElement AnnualTaxes { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='downPercent']")]
        public IWebElement AnnualTaxesPercentage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='anIns']")]
        public IWebElement HomeInsurance { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='calcTab2']")]
        public IWebElement Analysis { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='toTop']/i")]
        public IWebElement UpArrow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='EducationCarousel']/ul/li[1]")]
        public IWebElement EducationCarousel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='EducationCarousel']/ul/li[2]")]
        public IWebElement EducationCarousel1 { get; set; }

        [FindsBy(How = How.ClassName, Using = "help_text")]
        public IWebElement HelpText { get; set; }

        [FindsBy(How = How.Name, Using = "firstName")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.Name, Using = "cellPhone")]
        public IWebElement Mobile { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Name, Using = "zipCode")]
        public IWebElement Zipcode { get; set; }

        [FindsBy(How = How.Name, Using = "form_page_submit")]
        public IWebElement Send { get; set; }















        //[FindsBy(How = How.XPath, Using = "/html/body/section[6]/div/div[2]/form/div[1]/textarea")]
        //public IWebElement HelpText { get; set; }

        //[FindsBy(How = How.XPath, Using = "/html/body/section[6]/div/div[2]/form/input[1]")]
        //public IWebElement Name { get; set; }

        //[FindsBy(How = How.XPath, Using = "/html/body/section[6]/div/div[2]/form/input[2]")]
        //public IWebElement Mobile { get; set; }

        //[FindsBy(How = How.XPath, Using = "/html/body/section[6]/div/div[2]/form/input[3]")]
        //public IWebElement Email { get; set; }

        //[FindsBy(How = How.XPath, Using = "/html/body/section[6]/div/div[2]/form/input[4]")]
        //public IWebElement Zipcode { get; set; }

        //[FindsBy(How = How.XPath, Using = "/html/body/section[6]/div/div[2]/form/button")]
        //public IWebElement Send { get; set; }



    }
}
