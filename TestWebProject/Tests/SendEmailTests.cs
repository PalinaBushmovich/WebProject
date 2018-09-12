﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestWebProject.Driver;
using TestWebProject.PageObject;

namespace TestWebProject
{
    [TestClass]
    public class SendEmailTests : BaseTest
    {
        private MainNavigationPanel _navigationPanel;
        private MainEmailBoxPage _mainEmailBoxPage;
        private SentMailPage _sentMailPage;
        private HomePage _homePage;
        private LogInForm _logInform;

        [ClassInitialize()]
        public void SendEmailInitialize(TestContext context)
        {
            Browser Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configurations.StartUrl);
        }

        public void LogInSendEmailLogOut_LogInChechThatEmailIsSent()
        {
            _homePage = new HomePage();

            _logInform = _homePage.OpenLoginForm();

            //Log in as first user
            _logInform.LogInToEmailBox(Constants.Sender, Constants.Password);
      
            _mainEmailBoxPage = new MainEmailBoxPage();
            //Write and send an email
            _mainEmailBoxPage.SendEmail(Constants.Recipient, Constants.Message);

            _navigationPanel = new MainNavigationPanel();

            //Verify that email is in sent mail box 
            _sentMailPage = _navigationPanel.OpenSentMailPage();

            bool isEmailInSentBox = _sentMailPage.RecipientName.Displayed;
            Assert.IsTrue(isEmailInSentBox, "Email was not sent and is not resent in Sent Mail box");

            _logInform = _mainEmailBoxPage.SignOut();

            _logInform.LogInToEmailBox(Constants.Recipient, Constants.Password);

            //Verify that login is successful
            bool isSecondLoginSuccessfull = _navigationPanel.InboxLink.Displayed;
            Assert.IsTrue(isSecondLoginSuccessfull, $"Login of second user '{Constants.Recipient}' was not successful");

            //Verify that email is in Inbox 
            bool isEmailInInbox = _sentMailPage.SenderName.Displayed;
            Assert.IsTrue(isEmailInInbox, $"Email is not displayed in Inbox");

            //Drag&drop email to trash
            _mainEmailBoxPage.DeleteEmail(Constants.SenderName);

            //Verify that email is in the trash
            _navigationPanel.TrashButton.Click();

            TrashPage trashPage = new TrashPage();

            bool isEmailInTrash = trashPage.SenderName.Displayed;
            Assert.IsTrue(isEmailInTrash, $"Email is not displayed in Trash");
        }
    }
}
