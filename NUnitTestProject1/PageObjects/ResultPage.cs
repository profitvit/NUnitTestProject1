using NUnit.Framework;
using OpenQA.Selenium;

namespace TestTask.PageObjects
{
    public class ResultPage : BasePage
    {

        #region Selectors
        #endregion

        #region Page objects
        public ResultPage(IWebDriver driver) : base(driver) { }

        public ResultPage CheckField(string value)
        {
            IWebElement searchResult = Driver.FindElement(By.XPath("//span[contains(text(),'Converting')]//b[6]"));
            if (searchResult.Text == value)
            {
                Assert.Pass("Values equal");
            }
            else
            {
                ScreenShotRemoteBrowser();
            }
            return this;
        }
        #endregion
    }
}
