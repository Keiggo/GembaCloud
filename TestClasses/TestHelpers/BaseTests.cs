using GembaCloud.PlaywrightTests.Pages;
using NUnit.Framework.Interfaces;

[assembly: LevelOfParallelism(6)]

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class BaseTests
    {
        [ThreadStatic] public static IBrowserContext context;
        protected IPage page;

        [SetUp]
        public void BeforeEach()
        {
            //this method isn't async because Nunit doesn't support async [Setup] methods

            context = OneTimeSetupAndTeardown.browser.NewContextAsync(new()
            {
                ViewportSize = new ViewportSize()
                {
                    Width = 1920,
                    Height = 1080
                }
            }).GetAwaiter().GetResult();
            page = context.NewPageAsync().GetAwaiter().GetResult();
            LoginPage _loginPage = new LoginPage(page);

            _loginPage.GoToLoginPage().GetAwaiter().GetResult();
        }

        [TearDown]
        public void AfterEach()
        {
            if (page != null)
            {
                if (TestContext.CurrentContext.Result.Outcome == ResultState.Error)
                {
                    string screenshotSaveLocation = TestContext.Parameters["ScreenshotSaveLocation"];
                    string screenshotName = TestContext.CurrentContext.Test.MethodName;

                    page.ScreenshotAsync(new()
                    {
                        Path = screenshotSaveLocation,
                    }).GetAwaiter().GetResult();
                    TestContext.AddTestAttachment($"{screenshotSaveLocation}{screenshotName}.png");
                }

                context.CloseAsync().GetAwaiter().GetResult();
            }
        }
    }
}