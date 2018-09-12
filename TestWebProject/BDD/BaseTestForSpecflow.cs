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
        // private static TestContext _testContext { get; set; }


        [BeforeFeature]
        public static void SendEmailInitialize()
        {
            // _testContext = testContext;
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configurations.StartUrl);
        }

        [AfterFeature]
        public static void CleanUp()
        {
            //_testContext = ScenarioContext.Current.ScenarioContainer.Resolve<TestContext>();
            //ScenarioContext.Current.ScenarioContainer.Resolve<TestContext>().Equals
            if (ScenarioContext.Current.ScenarioContainer.Resolve<TestContext>().CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                string debugPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                string filePath = Path.Combine(debugPath, ".png");
                Screenshot screenshot = ((ITakesScreenshot)Browser.GetDriver()).GetScreenshot();
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            }

            Browser.Quit();
        }
    }
}
