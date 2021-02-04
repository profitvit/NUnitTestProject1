using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using TestTask.Configurations;

namespace NUnitTestProject1.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver { get; private set; }
        public BrowserType BrowserType;

        public void ChooseDriverInstance(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    Driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    Driver = new FirefoxDriver();
                    break;
                case BrowserType.Opera:
                    Driver = new OperaDriver();
                    break;
                default:
                    throw new AssertionException("Browser wasn't instal successfully");
            }
        }

        [SetUp]
        public void InitializeDriverForEveryTest()
        {
            ChooseDriverInstance(BrowserType);
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDownForEveryTest()
        {
            Driver?.Quit();
        }
    }
}