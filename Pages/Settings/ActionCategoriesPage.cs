namespace GembaCloud.PlaywrightTests.Pages
{
    public class ActionCategoriesPage : BasePage
    {
        private IPage _page;

        public ActionCategoriesPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToActionCategoriesPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.actionCategories);
        }
    }
}