namespace GembaCloud.PlaywrightTests.Pages
{
    public class PerformanceReasonPage : BasePage
    {
        private IPage _page;

        public PerformanceReasonPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToPerformanceReasonPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.performanceReason);
        }
    }
}