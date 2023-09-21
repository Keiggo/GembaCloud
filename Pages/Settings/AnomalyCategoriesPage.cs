namespace GembaCloud.PlaywrightTests.Pages
{
    public class AnomalyCategoriesPage : BasePage
    {
        private IPage _page;

        public AnomalyCategoriesPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToAnomalyCategoriesPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.anomalyCategories);
        }
    }
}