using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System;
using System.Drawing.Imaging;
using System.IO;
using TechTalk.SpecFlow;


namespace TestWebProject.Driver
{
    [Binding]
    public class BaseTestForSpecflow
    {
        public static Browser Browser = Browser.Instance;
        private static TestContext _testContext { get; set; }
        

        [BeforeFeature]
        public static void SendEmailTestsInitialize( )
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configurations.StartUrl);           
        }

        [AfterFeature]
        public static void CleanUp(TestContext _testContext)
        {
            _testContext = ScenarioContext.Current.ScenarioContainer.Resolve<TestContext>();

            if (_testContext.CurrentTestOutcome == UnitTestOutcome.Failed || (_testContext.CurrentTestOutcome == UnitTestOutcome.Error))
            {
                string debugPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                string filePath = Path.Combine(debugPath, _testContext.TestName + ".png");
                Screenshot screenshot = ((ITakesScreenshot)Browser.GetDriver()).GetScreenshot();
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            }                              

            Browser.Quit();
        }
    }
}
