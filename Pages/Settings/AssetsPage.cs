namespace GembaCloud.PlaywrightTests.Pages
{
    public class AssetsPage : BasePage
    {
        private IPage _page;

        public AssetsPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToAssetsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.assets);
        }
    }
}