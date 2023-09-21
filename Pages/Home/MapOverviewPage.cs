namespace GembaCloud.PlaywrightTests.Pages
{
    public class MapOverviewPage : BasePage
    {
        private IPage _page;

        public MapOverviewPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToMapOverviewPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.mapOverview);
        }
    }
}