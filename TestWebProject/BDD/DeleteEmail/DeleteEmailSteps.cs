using Utilities.Logger;
using System;
using TechTalk.SpecFlow;
using TestWebProject.Business_Object;
using TestWebProject.PageObject;
using Serilog;

namespace TestWebProject.BDD.DeleteEmail
{
    [Binding]
    public class DeleteEmailSteps
    {
        [Given(@"I login with the following credentials:")]
        public void GivenILoginWithTheFollowingCredentials(Table table)
        {
            var user = new User(table.Rows[0][0], table.Rows[0][1]);
            ScenarioContext.Current.Add("Username", user);
            ScenarioContext.Current.Add("Password", user);
            HomePage _homePage = new HomePage();
            LogInForm _logInform = _homePage.OpenLoginForm();
            _logInform.LogInToEmailBox(user.Username, user.Password);
            Logger.Configure();
            Log.Information("I login with the following credentials: {Username} / {Password}", table.Rows[0][0], table.Rows[0][1]);
        }
    }
}
