namespace GembaCloud.PlaywrightTests.Pages
{
    public class ConnectSystemsPage : BasePage
    {
        private IPage _page;

        public ConnectSystemsPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToConnectSystemsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.connectSystems);
        }
    }
}