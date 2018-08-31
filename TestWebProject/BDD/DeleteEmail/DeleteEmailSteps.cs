using System;
using TechTalk.SpecFlow;
using TestWebProject.Business_Object;
using TestWebProject.PageObject;

namespace TestWebProject.BDD.DeleteEmail
{
    [Binding]
    public class DeleteEmailSteps
    {
        [Given(@"I login with the following credentials:")]
        public void GivenILoginWithTheFollowingCredentials(Table table)
        {
            var user = new User(table.Rows[0][0], table.Rows[0][1]);
            HomePage _homePage = new HomePage();
            LogInForm _logInform = _homePage.OpenLoginForm();
            _logInform.LogInToEmailBox(user.Username, user.Password);
        }
    }
}
