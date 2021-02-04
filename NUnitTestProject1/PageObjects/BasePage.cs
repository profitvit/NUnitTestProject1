using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace TestTask.PageObjects
{
    public class BasePage
    {
        public IWebDriver Driver;
        public BasePage(IWebDriver driver) => Driver = driver;

        public void Visit(string url)
        {
            try
            {
                Driver.Navigate().GoToUrl(url);
                Assert.AreEqual(Driver.Title, "Google");
            }
            catch (Exception) { }
        }
        public IWebElement Find(By locator) => Driver.FindElement(locator);
        public void Click(By locator) => Find(locator).Click();
        public void Type(By locator, string inputText) => Find(locator).SendKeys(inputText);
        public void ClearAndType(By locator, string inputText)
        {
            var input = Find(locator);
            input.Click();
            input.Clear();
            input.SendKeys(inputText);
        }

        public void WaitForElementIsVisible(By locator)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                wait.Until(ElementIsVisible(locator));
            }
            catch (NoSuchElementException) { }
        }

        public void ScreenShotRemoteBrowser()
        {
            try
            {
                //Take the screenshot
                Screenshot image = ((ITakesScreenshot)Driver).GetScreenshot();
                string title = Driver.Title;
                string Runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
                string screenshotfilename = "C:\\screenshots\\" + Runname + ".jpg";
                //Save the screenshot
                image.SaveAsFile(screenshotfilename);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail("Failed with Exception: " + e);
            }
        }
    }
}
