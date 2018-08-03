using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebProject.Driver;

namespace TestWebProject.PageObject
{
    public class MainNavigationPanel : AbstractPage
    {
        public MainNavigationPanel()
        {
            IWebDriver driver = Browser.GetDriver();
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[@role='button']/span[contains(text(),'More')]")]
        public IWebElement MoreButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Trash']")]
        public IWebElement TrashButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'Sent Mail')]")]
        public IWebElement SentMailLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'Inbox')]")]
        public IWebElement InboxLink { get; set; }
    }
}

