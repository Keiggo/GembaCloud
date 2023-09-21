namespace GembaCloud.PlaywrightTests.TestClasses
{
    [SetUpFixture]
    public class OneTimeSetupAndTeardown
    {
        public static IBrowser browser;
        public static IPlaywright playwright;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            browser = new DriverFactory().BrowserDriver(TestContext.Parameters["BrowserName"],false); // you can whack a false in there if you want to disable headless running
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            TestContext.Progress.WriteLine($"These tests were run against the {EnvironmentNames.GetCurrentEnvironmentName()} environment on the {TestContext.Parameters["BrowserName"]} browser, and finished at {DateTime.Now.ToString()}");

            browser.CloseAsync().GetAwaiter().GetResult();
        }
    }
}