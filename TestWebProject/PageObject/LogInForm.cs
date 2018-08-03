using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestWebProject.Driver;


namespace TestWebProject.PageObject
{
    public class LogInForm : AbstractPage
    {
        public LogInForm()
        {
            IWebDriver _driver = Browser.GetDriver();
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input[type ='email']")]
        public IWebElement LogInInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "identifierNext")]
        public IWebElement NextEmailButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#passwordNext")]
        public IWebElement NextPasswordButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Switch account']")]
        public IWebElement SwitchAccountButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[p='Use another account']")]
        public IWebElement UseAnotherAccountButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='profileIdentifier']")]
        public IWebElement ChangeUserButton { get; set; }     
    }
}
