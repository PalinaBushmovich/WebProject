using OpenQA.Selenium;
using TestWebProject.Driver;

namespace TestWebProject.PageObject
{
    public class HomePageDecorator : IHomePage
    {
        IHomePage component;

        private static readonly By _loginInputBy = By.CssSelector("input[type ='email']");

        public HomePageDecorator(IHomePage component) { this.component = component; }

        public LogInForm OpenLoginForm()
        {
           LogInForm logInform = component.OpenLoginForm();

            logInform.LogInInput.HighlightElement(_loginInputBy);

            return logInform;
        }
    }
}
