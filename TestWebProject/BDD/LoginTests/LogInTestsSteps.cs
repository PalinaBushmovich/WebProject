using OpenQA.Selenium;
using Serilog;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TestWebProject.PageObject;
using Utilities.Logger;

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

        [When(@"^I log in with invalid (.*) (.*) credentials$")]
        public void WhenILogInWithInvalid(string login, string password)
        {
            By passwordInputBy = By.CssSelector("input[type = 'password']");
            LogInForm logInForm = new LogInForm();
            //Enter credentials           
            logInForm.LogInInput.SendKeys(login);
            logInForm.NextEmailButton.Click();

            logInForm.WaitTillElementIsVisible(passwordInputBy);
            logInForm.PasswordInput.SendKeys(password);
            logInForm.NextPasswordButton.Click();
            Logger.Configure();
            Log.Information($"I login with the invalid credentials: {login} / {password}");
        }

        [Then(@"Error message should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed()
        {
            By errorMessage = By.XPath("//div[contains(text(),'Wrong password')]");
            LogInForm logInForm = new LogInForm();
            logInForm.WaitTillElementIsVisible(errorMessage);
            Logger.Configure();
            Log.Information("Error message should be displayed");
        }


        [Then(@"Compose button should be visible")]
        public void ThenButtonShouldBeVisible()
        {
            By composeButtonBy = By.XPath("//div[contains(text(),'COMPOSE')]");
            LogInForm logInForm = new LogInForm();
            logInForm.WaitTillElementIsVisible(composeButtonBy);
            Logger.Configure();
            Log.Information("Compose button should be displayed");
        }
    }
}
