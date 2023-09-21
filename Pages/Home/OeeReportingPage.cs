namespace GembaCloud.PlaywrightTests.Pages
{
    public class OeeReportingPage : BasePage
    {
        private IPage _page;

        public OeeReportingPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToOeeReportingPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.oeeReporting);
        }
    }
}