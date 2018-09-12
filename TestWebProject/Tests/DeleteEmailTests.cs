using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebProject.Driver;
using TestWebProject.PageObject;

namespace TestWebProject.Tests
{
    [TestClass]
    public class DeleteEmailTests : BaseTest
    {
        private HomePage _homePage;
        private MainNavigationPanel _navigationPanel;
        private MainEmailBoxPage _mainEmailBoxPage;
        private SentMailPage _sentMailPage;
        private LogInForm _logInform;

        [ClassInitialize()]
        public static void DeleteEmailInitialize(TestContext testContext)
        {
            _testContext = testContext;
            _browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configurations.StartUrl);
        }

        [TestMethod, TestCategory("Email")]
        public void LogInSendEmail_DeleteViaRightMouseClick()
        {
            _homePage = new HomePage();

            IWebDriver driver = Browser.GetDriver();
            driver.Manage();

            _logInform = _homePage.OpenLoginForm();

            //Log in as first user
            _mainEmailBoxPage = _logInform.LogInToEmailBox(Constants.Sender, Constants.Password);

            _navigationPanel = new MainNavigationPanel();

            //Verify that login is successful
            bool isFirstLoginSuccessfull = _navigationPanel.InboxLink.Displayed;
            Assert.IsTrue(isFirstLoginSuccessfull, $"Login of first user '{Constants.Sender}' was not successful");

            //Write and send an email
            _mainEmailBoxPage.SendEmail(Constants.Recipient, Constants.Message);

            _logInform = _mainEmailBoxPage.SignOut();

            _logInform.LogInToEmailBox(Constants.Recipient, Constants.Password);

            //Delete an email
            _mainEmailBoxPage.DeleteEmailViaRightClick(Constants.SenderName);

        }
    }
}
