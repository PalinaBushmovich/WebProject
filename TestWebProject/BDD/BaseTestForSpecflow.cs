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
        protected static Browser _browser = Browser.Instance;

        [BeforeFeature]
        public static void SendEmailInitialize()
        {
            _browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configurations.StartUrl);
        }

        [AfterFeature]
        public static void CleanUp()
        {
            if (ScenarioContext.Current.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
            {
                string debugPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                string filePath = Path.Combine(debugPath, ScenarioContext.Current.ScenarioInfo.Title + ".png");
                Screenshot screenshot = ((ITakesScreenshot)Browser.GetDriver()).GetScreenshot();
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            }
            Browser.Quit();
        }
    }
}
