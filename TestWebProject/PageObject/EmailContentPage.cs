using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using TestWebProject.Driver;

namespace TestWebProject.PageObject
{
    public class EmailContentPage : AbstractPage
    {
        public EmailContentPage()
        {
            IWebDriver driver = Browser.GetDriver();
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[data-tooltip='Delete']")]
        public IWebElement DeleteButton { get; set; }

        public void DeleteEmail()
        {
            Browser.GetDriver().SwitchTo().ParentFrame();
            EmailContentPage emailContentPage = new EmailContentPage();
            emailContentPage.DeleteButton.Click();
        }
    }
}
