using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using TestWebProject.Driver;

namespace TestWebProject.PageObject
{
    public class SentMailPage : AbstractPage
    {
        public SentMailPage()
        {
            IWebDriver driver = Browser.GetDriver();
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[@name = 'dxvcdescfsdc']/../..")]
        public IWebElement RecipientName { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@name = 'Eduard Tumas']/../..")]
        public IWebElement SenderName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@role, 'menuitem')]//div[contains(text(),'Delete')]")]
        public IWebElement DeleteICon { get; set; }
        

        public void DeleteEmail()
        {
            SentMailPage sentMailPage = new SentMailPage();

            sentMailPage.SenderName.Click();
            Browser.GetDriver().SwitchTo().ParentFrame();

            EmailContentPage emailContentPage = new EmailContentPage();
            emailContentPage.DeleteButton.Click();
        }

    }
}
