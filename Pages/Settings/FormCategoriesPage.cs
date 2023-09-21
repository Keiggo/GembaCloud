namespace GembaCloud.PlaywrightTests.Pages
{
    public class FormCategoriesPage : BasePage
    {
        private IPage _page;

        public FormCategoriesPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToFormCategoriesPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.formCategories);
        }
    }
}