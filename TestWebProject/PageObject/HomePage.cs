using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestWebProject.Driver;


namespace TestWebProject.PageObject
{
    public class HomePage : AbstractPage
    {
        private static readonly By _passwordInputBy = By.CssSelector("input[type = 'password']");
        private static readonly By _loginInputBy = By.CssSelector("input[type ='email']");
        private static readonly By _composeButtonBy = By.XPath("//div[contains(text(),'COMPOSE')]");
        private static readonly By _signInButtonBy = By.CssSelector(".gmail-nav__nav-link__sign-in");

        public HomePage()
        {
            IWebDriver driver = Browser.GetDriver();
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input[type ='email']")]
        public IWebElement LogInInput { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".gmail-nav__nav-link__sign-in")]
        public IWebElement SignInButton { get; set; }

        public MainEmailBoxPage LogInToEmailBox(string email, string password)
        {
            HomePage homePage = new HomePage();

            //Click Sign in button
            homePage.SignInButton.JSclick(_signInButtonBy);

            LogInForm logInForm = new LogInForm();

            //Enter credentials 
            logInForm.LogInInput.WaitWhileVisible(3000);
            logInForm.LogInInput.SendKeys(email);
            logInForm.NextEmailButton.Click();

            logInForm.PasswordInput.WaitWhileVisible(3000);
            logInForm.PasswordInput.HighlightElement(_passwordInputBy);
            logInForm.PasswordInput.SendKeys(password);
            logInForm.NextPasswordButton.Click();

            IWebDriver driver = Browser.GetDriver();
            driver.Wait(6, 3);

            //Wait till main mail box page is loaded 
            MainEmailBoxPage mainEmailBoxPage = new MainEmailBoxPage();
            mainEmailBoxPage.ComposeButton.WaitWhileVisible(3000);

            return new MainEmailBoxPage();
        }
    }
}