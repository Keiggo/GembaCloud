namespace GembaCloud.PlaywrightTests.Pages
{
    public class SystemHealthPage : BasePage
    {
        private IPage _page;

        public SystemHealthPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToSystemHealthPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.systemHealth);
        }
    }
}