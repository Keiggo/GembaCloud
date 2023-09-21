namespace GembaCloud.PlaywrightTests.Pages
{
    public class AssetTypesPage : BasePage
    {
        private IPage _page;

        public AssetTypesPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToAssetTypesPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.assetTypes);
        }
    }
}