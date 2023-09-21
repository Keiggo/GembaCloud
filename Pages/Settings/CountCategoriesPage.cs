namespace GembaCloud.PlaywrightTests.Pages
{
    public class CountCategoriesPage : BasePage
    {
        private IPage _page;

        public CountCategoriesPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToCountCategoriesPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.countCategories);
        }
    }
}