using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.IO;

namespace TestWebProject.Driver
{
    [TestClass]
    public class BaseTest
    {
        protected static Browser _browser = Browser.Instance;
        public TestContext TestContext { get; set; }
        protected static TestContext _testContext;

        [TestCleanup]
        public void CleanUp()
        {
            if(TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                string debugPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                string filePath = Path.Combine(debugPath, TestContext.TestName + ".png");
                Screenshot screenshot = ((ITakesScreenshot)Browser.GetDriver()).GetScreenshot();
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            }

            Browser.Quit();
        }
    }
}
