using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.IO;

namespace TestWebProject.Driver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox,
            IExplorer,
            RemoteFirefox,
            RemoteChrome
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver = null;


            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        //in order to run test from console. test results should be stored in the TestResults folder             
                        string solutionParentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName.ToString();
                        string pathToDriver = Path.Combine(solutionParentDirectory, @"TestWebProject\bin\Debug");
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        option.AddArgument("--disable-notifications");
                        driver = new ChromeDriver(pathToDriver);
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        var service = FirefoxDriverService.CreateDefaultService();
                        var options = new FirefoxOptions();
                        driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
                        Browser.GetDriver();
                        break;
                    }
                case BrowserType.RemoteChrome:
                    {
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        option.AddArgument("--no-sandbox");
                        driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), option.ToCapabilities());
                        break;
                    }
                case BrowserType.IExplorer:
                    {
                        var service = InternetExplorerDriverService.CreateDefaultService();
                        var option = new InternetExplorerOptions();
                        driver = new InternetExplorerDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
            }
            return driver;
        }
    }
}
