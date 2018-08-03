using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestWebProject.Driver
{
    public static class WebDriverExtensions
    {
        public static WebDriverWait Wait(this IWebDriver Driver, int waitTimeoutSeconds = 6, int iterationDelaySeconds = 2)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTimeoutSeconds));
            wait.PollingInterval = TimeSpan.FromSeconds(iterationDelaySeconds);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException), typeof(NullReferenceException), typeof(WebDriverException), typeof(WebDriverTimeoutException));

            return wait;
        }

        public static IWebElement WaitForElementExist(this IWebDriver driver, By by, int timeoutInSeconds = 20, int iterationDelaySeconds = 2)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    Wait(driver, timeoutInSeconds, iterationDelaySeconds).Until(d => d.FindElements(by).Count > 0);
                }

            }
            catch
            {
                Console.WriteLine("Timed out waiting for element with selector: " + by);
            }

            return driver.FindElement(by);
        }

        public static void HighlightElement(this IWebElement element, By by)
        {
            IWebDriver driver = Browser.GetDriver();
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            IWebElement askQuestionElement = driver.FindElement(by);
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", askQuestionElement);
        }

        public static void JSclick(this IWebElement element, By locator)
        {
            IWebDriver driver = Browser.GetDriver();
            driver.WaitForElementExist(locator);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(locator));

        }
    }
}
