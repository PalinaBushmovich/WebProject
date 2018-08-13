﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestWebProject.Driver;
using TestWebProject.PageObject;

namespace TestWebProject
{
    [TestClass]
    public class SendEmailTests : BaseTest
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

        [TestMethod, TestCategory("Email"), TestCategory("Delete")]
        public void LogInSendEmailLogOut_LogInChechThatEmailIsSent()
        {
            _homePage = new HomePage();

            //Log in as first user
            MainEmailBoxPage _mainEmailBoxPage = _homePage.LogInToEmailBox(Constants.Sender, Constants.Password);

            //Verify that login is successful
            _navigationPanel = new MainNavigationPanel();

            bool isFirstLoginSuccessfull = _navigationPanel.InboxLink.Displayed;
            Assert.IsTrue(isFirstLoginSuccessfull, $"Login of first user '{Constants.Sender}' was not successful");

            //Write and send an email
            _mainEmailBoxPage.SendEmail(Constants.Recipient, Constants.Message);

            //Verify that email is in sent mail box 
            _navigationPanel.SentMailLink.Click();

            _sentMailPage = new SentMailPage();

            bool isEmailInSentBox = _sentMailPage.RecipientName.IsElementDisplayed();
            Assert.IsTrue(isEmailInSentBox, "Email was not sent and is not resent in Sent Mail box");

            _mainEmailBoxPage.ReLogin(Constants.Recipient, Constants.Password);

            //Verify that login is successful
            bool isSecondLoginSuccessfull = _navigationPanel.InboxLink.IsElementDisplayed();
            Assert.IsTrue(isSecondLoginSuccessfull, $"Login of second user '{Constants.Recipient}' was not successful");

            //Verify that email is in Inbox 
            bool isEmailInInbox = _sentMailPage.SenderName.IsElementDisplayed();
            Assert.IsTrue(isEmailInInbox, $"Email is not displayed in Inbox");

            //Drag&drop email to trash
            _mainEmailBoxPage.DeleteEmail(Constants.SenderName);

            //Verify that email is in the trash
            _navigationPanel.TrashButton.Click();

            TrashPage trashPage = new TrashPage();

            bool isEmailInTrash = trashPage.SenderName.IsElementDisplayed();
            Assert.IsTrue(isEmailInInbox, $"Email is not displayed in Trash");

        }
           
    }
}