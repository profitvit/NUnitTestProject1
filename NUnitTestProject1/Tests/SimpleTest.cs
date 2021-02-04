using NUnit.Framework;
using NUnitTestProject1.PageObjects;
using TestTask.PageObjects;

namespace NUnitTestProject1.Tests
{
    [TestFixture]
    public class SimpleTest : BaseTest
    {

        [Test]
        public void SimpleTestForGoogle()
        {
            new GoogleMainPage(Driver)
                .TypeTextInSearchField("Selenium IDE export to C#");
            new ResultPage(Driver).CheckField("Selenium IDE");
        }
    }
}
