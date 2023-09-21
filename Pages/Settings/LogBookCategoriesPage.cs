namespace GembaCloud.PlaywrightTests.Pages
{
    public class LogBookCategoriesPage : BasePage
    {
        private IPage _page;
        private ILocator locatorAddLogBookCategoryButton;
        private ILocator locatorEditLogBookCategoryButton;
        private ILocator locatorDeleteLogBookCategoryButton;

        public LogBookCategoriesPage(IPage page) : base(page)
        {
            _page = page;
            locatorAddLogBookCategoryButton = _page.GetByRole(AriaRole.Link, new() { Name = "+ Add" });
            locatorEditLogBookCategoryButton = _page.GetByRole(AriaRole.Link, new() { Name = "Edit" });
            locatorDeleteLogBookCategoryButton = _page.GetByRole(AriaRole.Link, new() { Name = "Delete" });
    }

        public async Task GoToLogBookCategoriesPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.logBookCategories);
        }

        public async Task AssertAddLogBookCategoryButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorAddLogBookCategoryButton);
        }

        public async Task AssertEditLogBookCategoryButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorEditLogBookCategoryButton);
        }

        public async Task AssertDeleteLogBookCategoryButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorDeleteLogBookCategoryButton);
        }
    }
}