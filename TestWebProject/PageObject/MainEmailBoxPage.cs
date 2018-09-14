using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using Serilog;
using System;
using System.Threading;
using TestWebProject.Driver;
using Utilities.Logger;

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
            try
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

                Logger.Configure();
                Log.Information($"Email with the text'{message}' was sent to '{recipient}'");
            }
            catch (Exception ex)
            {
                Logger.Configure();
                Log.Error(ex, $"Email was not sent to '{recipient}'");
            }
        }

        public LogInForm SignOut()
        {
            try
            {
                MainEmailBoxPage mainPage = new MainEmailBoxPage();
                mainPage.LinkToAccountPopUp.Click();
                mainPage.WaitTillElementIsVisible(_signOutButtonBy);
                mainPage.SignOutButton.Click();
                IWebDriver driver = Browser.GetDriver();

                if (driver.IsAlertPresent())
                {
                    driver.SwitchTo().Alert();
                    driver.SwitchTo().Alert().Dismiss();
                    driver.SwitchTo().DefaultContent();
                }

                Logger.Configure();
                Log.Information($"User was sign out'");

            }
            catch (Exception ex)
            {
                Logger.Configure();
                Log.Error(ex, "User didn't sign out");
            }

            return new LogInForm();
        }

        public void DeleteEmail(string sender)
        {
            try
            {
                MainEmailBoxPage mainPage = new MainEmailBoxPage();

                string emailName = String.Format(_emailNameXPath, sender);
                IWebElement emailTitle = Browser.GetDriver().FindElement(By.XPath(emailName));
                MainNavigationPanel navigationPanel = new MainNavigationPanel();

                navigationPanel.MoreButton.Click();

                Actions Action = new Actions(Browser.GetDriver());
                Action.DragAndDrop(emailTitle, navigationPanel.TrashButton).Build().Perform();

                Logger.Configure();
                Log.Information($"Email from {sender} was deleted'");
            }
            catch (Exception ex)
            {
                Logger.Configure();
                Log.Error(ex, "Email was not deleted");
            }
        }

        public void DeleteEmailViaRightClick(string sender)
        {
            try
            {
                string emailName = String.Format(_emailNameXPath, sender);
                IWebElement emailTitle = Browser.GetDriver().FindElement(By.XPath(emailName));
                MainNavigationPanel navigationPanel = new MainNavigationPanel();

                Actions Action = new Actions(Browser.GetDriver());

                Actions RightClickAction = new Actions(Browser.GetDriver()).ContextClick(emailTitle);

                RightClickAction.Build().Perform();

                DeleteICon.Click();

                Logger.Configure();
                Log.Information($"Email from {sender} was deleted via right click'");
            }
            catch (Exception ex)
            {
                Logger.Configure();
                Log.Error(ex, "Email was not deleted via right click");
            }

        }
    }
}
