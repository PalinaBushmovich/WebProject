using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using TestWebProject.Driver;

namespace TestWebProject.PageObject
{
    public class LogInForm : AbstractPage
    {
        private static readonly By _passwordInputBy = By.CssSelector("input[type = 'password']");
        private static readonly By _loginInputBy = By.CssSelector("input[type ='email']");
        private static readonly By _composeButtonBy = By.XPath("//div[contains(text(),'COMPOSE')]");
      
        private static readonly By _useAnotherAccountBy = By.XPath("//div[p='Use another account']");
        private static readonly By _logInForm = By.XPath("//*[@id='initialView']/div[contains(@role,'presentation')]");
        private static readonly By _changeUserButton = By.XPath("//*[@id='profileIdentifier']");

        public LogInForm()
        {
            IWebDriver driver = Browser.GetDriver();
            PageFactory.InitElements(driver, this);
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

        public MainEmailBoxPage LogInToEmailBox(string email, string password)
        {
            HomePage homePage = new HomePage();
            IWebDriver driver = Browser.GetDriver();
            driver.Manage();

            LogInForm logInForm = new LogInForm();

            WaitTillElementIsVisible(_logInForm);

            if (driver.IsElementDisplayed(_changeUserButton))
            {
                ChangeUserButton.Click();
            }
            if (driver.IsElementDisplayed(_useAnotherAccountBy))
            {
                logInForm.UseAnotherAccountButton.Click();
            }

            //Enter credentials 
            logInForm.WaitTillElementIsVisible(_loginInputBy);
            logInForm.LogInInput.SendKeys(email);
            logInForm.NextEmailButton.Click();

            Thread.Sleep(3000);
            logInForm.WaitTillElementIsVisible(_passwordInputBy);
            logInForm.PasswordInput.HighlightElement(_passwordInputBy);
            logInForm.PasswordInput.SendKeys(password);
            logInForm.NextPasswordButton.Click();

            //Wait till main mail box page is loaded 
            MainEmailBoxPage mainEmailBoxPage = new MainEmailBoxPage();

       

            mainEmailBoxPage.WaitTillElementIsVisible(_composeButtonBy);

            return new MainEmailBoxPage();
        }
    }
}
