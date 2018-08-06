using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestWebProject.Driver;

namespace TestWebProject.PageObject
{
    public abstract class AbstractPage
    {
        
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

       

        

    }
}
