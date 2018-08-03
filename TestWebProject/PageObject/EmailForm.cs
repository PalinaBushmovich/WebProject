using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestWebProject.Driver;

namespace TestWebProject.PageObject
{
    public class EmailForm : AbstractPage
    {

        public EmailForm()
        {
            IWebDriver driver = Browser.GetDriver();
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//td/form")]
        public IWebElement SendForm { get; set; }

        [FindsBy(How = How.XPath, Using = "//td/form//textarea[@name='to']")]
        public IWebElement ToField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Message Body']")]
        public IWebElement MessageArea { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Send')]")]
        public IWebElement SendButton { get; set; }
    }
}
