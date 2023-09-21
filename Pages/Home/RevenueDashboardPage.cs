namespace GembaCloud.PlaywrightTests.Pages
{
    public class RevenueDashboardPage : BasePage
    {
        private IPage _page;

        public RevenueDashboardPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToRevenueDashboardPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.revenueDashboard);
        }
    }
}