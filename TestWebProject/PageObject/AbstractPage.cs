using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestWebProject.Driver;

namespace TestWebProject.PageObject
{
    public abstract class AbstractPage
    {
  
        public void WaitTillElementIsVisible(By locator, int timeoutInSeconds = 5)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(timeoutInSeconds)).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void DeleteEmail()
        {

        }            

        public void HighlightElement(By locator)
        {
            IWebDriver driver = Browser.GetDriver();
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            IWebElement askQuestionElement = driver.FindElement(locator);
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", askQuestionElement);
        }

        public bool IsElementDisplayed(IWebElement element)
        {          
            return element.Displayed;

        }

    }
}
