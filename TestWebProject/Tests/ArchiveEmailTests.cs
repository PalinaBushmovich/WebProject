using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class ArchiveEmailTests : BaseTest
    {
        private HomePage _homePage;
        private MainNavigationPanel _navigationPanel;
        private MainEmailBoxPage _mainEmailBoxPage;
        private SentMailPage _sentMailPage;

        [ClassInitialize()]
        public static void SendEmailTestsInitialize(TestContext context)
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configurations.StartUrl);
        }

        [TestMethod, TestCategory("Email"), TestCategory("Archive")]
        public void LogInSendEmail_ArhiveViaRightMouseClick()
        {
            //Log in as first user
            _mainEmailBoxPage = _homePage.LogInToEmailBox(Constants.Sender, Constants.Password);

            //Verify that login is successful
            bool isFirstLoginSuccessfull = _navigationPanel.InboxLink.Displayed;
            Assert.IsTrue(isFirstLoginSuccessfull, $"Login of first user '{Constants.Sender}' was not successful");

            //Write and send an email
            _mainEmailBoxPage.SendEmail(Constants.Recipient, Constants.Message);

            _mainEmailBoxPage.ReLogin(Constants.Recipient, Constants.Password);

            //Verify that login is successful
            bool isSecondLoginSuccessfull = _navigationPanel.InboxLink.Displayed;
            Assert.IsTrue(isSecondLoginSuccessfull, $"Login of second user '{Constants.Recipient}' was not successful");

            //Send the email to archive
            _mainEmailBoxPage.MoveEmailToArchive(Constants.Sender);
        }

    }
}
