using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestWebProject.Driver;


namespace TestWebProject.PageObject
{
    public class HomePage : AbstractPage
    {
        private static readonly By _signInButtonBy = By.CssSelector(".gmail-nav__nav-link__sign-in");
        private static readonly By _logInInputBy = By.CssSelector("input[type ='email']");
        private static readonly By _nextButtonBy = By.Id("identifierNext");
        private static readonly By _contentBy = By.XPath("//div//content[contains(text(),'English (United Kingdom)‬')]");


        public HomePage()
        {
            IWebDriver driver = Browser.GetDriver();
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input[type ='email']")]
        public IWebElement LogInInput { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".gmail-nav__nav-link__sign-in")]
        public IWebElement SignInButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//div//content[contains(text(),'Русский')]")]
        public IWebElement RussianLanguageIsSelected { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@role='option']//content[contains(text(),'English (United Kingdom)‬')]")]
        public IWebElement EnglishLanguage { get; set; }


        public LogInForm OpenLoginForm()
        {
            //Click Sign in button
            SignInButton.JSclick(_signInButtonBy);

            WaitTillElementIsVisible(_logInInputBy);

            if (RussianLanguageIsSelected.Displayed)
            {
                RussianLanguageIsSelected.Click();
                WaitTillElementIsVisible(_contentBy);
                EnglishLanguage.Click();
                WaitTillElementIsVisible(_nextButtonBy);
            }
            return new LogInForm();
        }
    }
}