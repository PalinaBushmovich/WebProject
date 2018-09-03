using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TestWebProject.Driver;

namespace TestWebProject.PageObject
{
    public abstract class AbstractPage
    {          

        public void HighlightElement(By locator)
        {
            IWebDriver driver = Browser.GetDriver();
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            IWebElement askQuestionElement = driver.FindElement(locator);
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", askQuestionElement);
        }
    
        public void WaitTillElementIsVisible(By locator, int timeOut = 10)
        {
            Thread.Sleep(3000);
            IWebDriver driver = Browser.GetDriver();
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementExists((locator)));
        }       
    }
}
