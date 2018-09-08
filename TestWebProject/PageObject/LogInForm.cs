using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Serilog;
using System;
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
        private static readonly By _errorMessage = By.XPath("//div[contains(text(),'Wrong password')]");
        private static readonly By _nextButtonBy = By.Id("identifierNext");
        private static readonly By _contentBy = By.XPath("//div//content[contains(text(),'English (United Kingdom)‬')]");


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
      
        [FindsBy(How = How.XPath, Using = "//div[@data-value = 'ru']")]
        public IWebElement RussianLanguageSelected { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Wrong password')]")]
        public IWebElement ErrorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div//content[contains(text(),'Русский')]")]
        public IWebElement RussianLanguageIsSelected { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='option']//content[contains(text(),'English (United Kingdom)‬')]")]
        public IWebElement EnglishLanguage { get; set; }

        public MainEmailBoxPage LogInToEmailBox(string email, string password)
        {
            try
            {
                HomePage homePage = new HomePage();
                IWebDriver driver = Browser.GetDriver();
                driver.Manage();

                LogInForm logInForm = new LogInForm();

                WaitTillElementIsVisible(_logInForm);

                if (RussianLanguageIsSelected.Displayed)
                {
                    RussianLanguageIsSelected.Click();
                    WaitTillElementIsVisible(_contentBy);
                    EnglishLanguage.Click();
                    WaitTillElementIsVisible(_logInForm);
                }

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

                logInForm.WaitTillElementIsVisible(_passwordInputBy);
                logInForm.PasswordInput.SendKeys(password);
                logInForm.PasswordInput.HighlightElement(_passwordInputBy);
                logInForm.NextPasswordButton.Click();

                //Wait till main mail box page is loaded 
                MainEmailBoxPage mainEmailBoxPage = new MainEmailBoxPage();

                mainEmailBoxPage.WaitTillElementIsVisible(_composeButtonBy);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Log in to the email box was failed");
            }

            return new MainEmailBoxPage();
        }
    }
}
