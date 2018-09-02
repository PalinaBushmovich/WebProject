﻿using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TestWebProject.PageObject;

namespace TestWebProject.BDD.LoginTests
{
    [Binding]
    public class LogInTestsSteps
    {
        [Given(@"I navigate to Login form")]
        public void GivenINavigateToLoginForm()
        {
            HomePage _homePage = new HomePage();
            LogInForm _logInform = _homePage.OpenLoginForm();
        }

        [When(@"^I log in with ..valid (.*) (.*) credantials$")]
        public void WhenILogInWithInvalid(string login, string password)
        {
            LogInForm logInForm = new LogInForm();
            //Enter credentials           
            logInForm.LogInInput.SendKeys(login);
            logInForm.NextEmailButton.Click();
            Thread.Sleep(2000);
            logInForm.PasswordInput.SendKeys(password);
            logInForm.NextEmailButton.Click();
        }

        [Then(@"Error message should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed()
        {
            By errorMessage = By.XPath("//div[contains(text(),'Wrong password')]");
            LogInForm logInForm = new LogInForm();
            logInForm.WaitTillElementIsVisible(errorMessage);
        }


        [Then(@"Compose button should be visible")]
        public void ThenButtonShouldBeVisible()
        {
            By composeButtonBy = By.XPath("//div[contains(text(),'COMPOSE')]");
            LogInForm logInForm = new LogInForm();
            logInForm.WaitTillElementIsVisible(composeButtonBy);
        }
    }
}
