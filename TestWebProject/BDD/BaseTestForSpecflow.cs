using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace TestWebProject.Driver
{
    [Binding]
    public class BaseTestForSpecflow
    {
        public static Browser Browser = Browser.Instance;

        [BeforeFeature]
        public static void SendEmailTestsInitialize()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configurations.StartUrl);
           
        }

        [AfterFeature]
        public static void CleanUp()
        {
            Browser.Quit();
        }
    }
}
