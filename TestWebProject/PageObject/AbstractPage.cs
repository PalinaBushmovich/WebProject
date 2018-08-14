using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using TestWebProject.Driver;

namespace TestWebProject.PageObject
{
    public abstract class AbstractPage
    {
        public AbstractPage()
        {
            IWebDriver _driver = Browser.GetDriver();
            PageFactory.InitElements(_driver, this);
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
    
        public void WaitTillElementIsVisible(By locator, int timeOut = 6)
        {
            IWebDriver driver = Browser.GetDriver();
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementExists((locator)));
        }
    }
}
