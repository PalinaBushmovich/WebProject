using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.IO;
using TestWebProject.Utilities;

namespace TestWebProject.Driver
{
    [TestClass]
    public class BaseTest
    {
        protected static Browser _browser = Browser.Instance;
        public TestContext TestContext { get; set; }
        protected static TestContext _testContext;

        public static void InitializeTestsExecution (TestContext context)
        {
            _testContext = context;
            Browser Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configurations.StartUrl);
        }

        [ClassCleanup]
        public void CleanUp()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                ScreenshotMaker.TakeBrowserScreenshot(_testContext);
                ScreenshotMaker.TakeFullDisplayScreenshot(_testContext);
            }

            Browser.Quit();
        }

    }
}
