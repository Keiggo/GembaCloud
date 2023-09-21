namespace GembaCloud.PlaywrightTests.Pages
{
    public class AssetGroupsPage : BasePage
    {
        private IPage _page;

        public AssetGroupsPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToAssetGroupsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.assetGroups);
        }
    }
}