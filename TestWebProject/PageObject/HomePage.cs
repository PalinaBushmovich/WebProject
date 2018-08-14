using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestWebProject.Driver;


namespace TestWebProject.PageObject
{
    public class HomePage : AbstractPage
    {
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

        public LogInForm OpenLoginForm()
        {
            //Click Sign in button
            SignInButton.JSclick(_signInButtonBy);

            return new LogInForm();
        }
    }
}