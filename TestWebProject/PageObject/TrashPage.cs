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
    public class TrashPage : AbstractPage
    {
        public TrashPage()
        {
            IWebDriver driver = Browser.GetDriver();
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[@name = 'Eduard Tumas']/../..")]
        public IWebElement SenderName { get; set; }
    }
}
