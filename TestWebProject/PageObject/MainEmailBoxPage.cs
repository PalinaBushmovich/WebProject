using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using TestWebProject.Driver;

namespace TestWebProject.PageObject
{
    public class MainEmailBoxPage : AbstractPage
    {
        private static readonly By _composeButtonXPath = By.XPath("//div[contains(text(),'COMPOSE')]");
        private static readonly By _sendFormXPath = By.XPath("//td/form");
        private static readonly By _logInInputXPath = By.CssSelector("input[type = 'Email']");
        private static readonly By _passwordInputXPath = By.CssSelector("input[type = 'password']");
        private static readonly By _useAnotherAccountXPath = By.XPath("//div[p='Use another account']");
        private static readonly By _signOutButtonBy = By.XPath("//a[text()='Sign out']");
        private string _emailNameXPath = "//span[contains(@name,'{0}')]";

        private string _deleteRowXPath = "//span[contains(@name,'{0}')]";

        public MainEmailBoxPage()
        {
            IWebDriver driver = Browser.GetDriver();
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Sign In']")]
        public IWebElement SignInButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'COMPOSE')]")]
        public IWebElement ComposeButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Delete']")]
        public IWebElement DeleteButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'Google Account')]")]
        public IWebElement LinkToAccountPopUp { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Sign out']")]
        public IWebElement SignOutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@role, 'menuitem')]//div[contains(text(),'Delete')]")]
        public IWebElement DeleteICon { get; set; }

        public void SendEmail(string recipient, string message)
        {
            MainEmailBoxPage mainPage = new MainEmailBoxPage();

            mainPage.WaitTillElementIsVisible(_composeButtonXPath);
            mainPage.ComposeButton.Click();

            EmailForm emailForm = new EmailForm();

            emailForm.WaitTillElementIsVisible(_sendFormXPath);
            Browser.GetDriver().SwitchTo().ActiveElement();

            emailForm.ToField.SendKeys(recipient);
            emailForm.ToField.SendKeys(Keys.Enter);
            emailForm.MessageArea.SendKeys(message);
            emailForm.MessageArea.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            emailForm.SendButton.Click();
        }

        public LogInForm SignOut()
        {
            MainEmailBoxPage mainPage = new MainEmailBoxPage();
            mainPage.LinkToAccountPopUp.Click();
            mainPage.WaitTillElementIsVisible(_signOutButtonBy);
            mainPage.SignOutButton.Click();

            LogInForm logInForm = new LogInForm();

            return logInForm;
        }

        public void DeleteEmail(string sender)
        {
            MainEmailBoxPage mainPage = new MainEmailBoxPage();

            string emailName = String.Format(_emailNameXPath, sender);
            IWebElement emailTitle = Browser.GetDriver().FindElement(By.XPath(emailName));
            MainNavigationPanel navigationPanel = new MainNavigationPanel();

            navigationPanel.MoreButton.Click();

            Actions Action = new Actions(Browser.GetDriver());
            Action.DragAndDrop(emailTitle, navigationPanel.TrashButton).Build().Perform();
        }

        public void DeleteEmailViaRightClick(string sender)
        {
            string emailName = String.Format(_emailNameXPath, sender);
            IWebElement emailTitle = Browser.GetDriver().FindElement(By.XPath(emailName));
            MainNavigationPanel navigationPanel = new MainNavigationPanel();

            Actions Action = new Actions(Browser.GetDriver());

            Actions RightClickAction = new Actions(Browser.GetDriver()).ContextClick(emailTitle);

            RightClickAction.Build().Perform();

            DeleteICon.Click();

        }
    }
}
