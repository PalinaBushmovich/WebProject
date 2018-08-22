using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TestWebProject.Driver;
using TestWebProject.PageObject;

namespace TestWebProject
{
    [Binding]
    public class SpecFlowTestSteps : BaseTestForSpecflow
    {
        [Given(@"I navigate to login form")]
        public void GivenINavigateToLoginForm()
        {
            HomePage _homePage = new HomePage();
            LogInForm _logInform = _homePage.OpenLoginForm();
        }

        [Given(@"I log in to the email box with (.*) and (.*)")]
        public void GivenILogInToTheEmailBoxWithAnd(string login, string password)
        {
            LogInForm _logInform = new LogInForm();
            _logInform.LogInToEmailBox(login, password);
        }

        [When(@"I sent an email to (.*) with text (.*)")]
        public void WhenISentAnEmailToWithText(string email, string text)
        {
            MainEmailBoxPage _mainEmailBoxPage = new MainEmailBoxPage();
            _mainEmailBoxPage.SendEmail(email, text);
        }

        [Given(@"I sent an email to (.*) with text (.*)")]
        public void GivenISentAnEmailToWithText(string email, string text)
        {
            MainEmailBoxPage _mainEmailBoxPage = new MainEmailBoxPage();
            _mainEmailBoxPage.SendEmail(email, text);
        }

        [Given(@"I sign out")]
        public void GivenISignOut()
        {
            By signOutButtonBy = By.XPath("//a[text()='Sign out']");

            MainEmailBoxPage mainPage = new MainEmailBoxPage();
            mainPage.LinkToAccountPopUp.Click();
            mainPage.WaitTillElementIsVisible(signOutButtonBy);
            mainPage.SignOutButton.Click();

            LogInForm logInForm = new LogInForm();
        }

        [Then(@"the email to (.*) is present in Sent folder")]
        public void ThenTheEmailIsPresentInSentFolder(string email)
        {
            string bodyXpath = "//*[contains(@email,'{0}')]/../..";
            string emailText = String.Format(bodyXpath, email);

            MainNavigationPanel navigationPanel = new MainNavigationPanel();
            navigationPanel.SentMailLink.Click();
            SentMailPage sentMailPage = new SentMailPage();

            IWebElement toField = Browser.GetDriver().FindElement(By.XPath(emailText));
          
            bool isEmailInSentBox = toField.Displayed;
            Assert.IsTrue(isEmailInSentBox, "Email was not sent and is not present in Sent Mail box");
        }

        [When(@"I move the email from (.*) to Trash")]
        public void WhenIMoveTheEmailToTrash(string sender)
        {
            string _emailNameXPath = "//span[contains(@name,'{0}')]";
            string emailName = String.Format(_emailNameXPath, sender);
            IWebElement emailTitle = Browser.GetDriver().FindElement(By.XPath(emailName));
            MainEmailBoxPage mainPage = new MainEmailBoxPage();

            Actions Action = new Actions(Browser.GetDriver());
            Actions RightClickAction = new Actions(Browser.GetDriver()).ContextClick(emailTitle);

            RightClickAction.Build().Perform();

            mainPage.DeleteICon.Click();
        }

        [Then(@"Email with recipient (.*) is in Trash")]
        public void EmailWithRecipientIsInTrash(string sender)
        {
            MainNavigationPanel navigationPanel = new MainNavigationPanel();
            navigationPanel.TrashButton.Click();

            TrashPage trashPage = new TrashPage();

            string _emailNameXPath = "//span[contains(@name,'{0}')]";
            string emailName = String.Format(_emailNameXPath, sender);
            IWebElement emailTitle = Browser.GetDriver().FindElement(By.XPath(emailName));

            bool isEmailInTrash = trashPage.SenderName.Displayed;
            Assert.IsTrue(isEmailInTrash, $"Email is not displayed in Trash");

        }
    }
}