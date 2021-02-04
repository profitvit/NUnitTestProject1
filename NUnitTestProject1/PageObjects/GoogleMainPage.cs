using OpenQA.Selenium;
using TestTask.PageObjects;

namespace NUnitTestProject1.PageObjects
{
    public class GoogleMainPage : BasePage
    {
        #region Selectors
        private readonly By searchField = By.XPath("//*[@name='q']");
        #endregion

        #region Page object
        public GoogleMainPage(IWebDriver driver) : base(driver) { }

        public GoogleMainPage VisitUrL()
        {
            Visit(Configurations.EnvironmentData.Url);
            return this;
        }

        public ResultPage TypeTextInSearchField(string searchQuery)
        {
            WaitForElementIsVisible(searchField);
            Type(searchField, searchQuery);
            Type(searchField, Keys.Enter);
            return new ResultPage(Driver);
        }
        #endregion
    }
}
