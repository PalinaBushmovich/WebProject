using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWebProject.Driver;
using TestWebProject.PageObject;

namespace TestWebProject.Tests
{
    [TestClass]
    public class MultipleUsersLogIn : BaseTest
    {
        private HomePage _homePage;
        private MainNavigationPanel _navigationPanel;
        private MainEmailBoxPage _mainEmailBoxPage;
        private SentMailPage _sentMailPage;
        private LogInForm _logInform;

        private static TestContext _testContextInstance;

        [ClassInitialize()]
        public static void SendEmailTestsInitialize(TestContext context)
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configurations.StartUrl);
            _testContextInstance = context;
        }
       
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "LogInData.xml", "Credentials", DataAccessMethod.Sequential)]
        [DeploymentItem("@Data")]
        public void LogIn_VerifySuccessfulLogIn()
        {
            #region set variables

            string input = _testContextInstance.DataRow["InputParameter"].ToString();
            string expectedResult = _testContextInstance.DataRow["Result"].ToString();

            #endregion

            _homePage = new HomePage();

            _logInform = _homePage.OpenLoginForm();

            //Log in as first user
            _mainEmailBoxPage = _logInform.LogInToEmailBox(Constants.Sender, Constants.Password);

            _navigationPanel = new MainNavigationPanel();

            //Verify that login is successful
            bool isFirstLoginSuccessfull = _navigationPanel.InboxLink.Displayed;
            Assert.IsTrue(isFirstLoginSuccessfull, $"Login of first user '{Constants.Sender}' was not successful");

            _logInform = _mainEmailBoxPage.SignOut();

            _logInform.LogInToEmailBox(Constants.Recipient, Constants.Password);

        }

    }
}
