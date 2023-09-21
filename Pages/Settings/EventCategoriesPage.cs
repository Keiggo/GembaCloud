namespace GembaCloud.PlaywrightTests.Pages
{
    public class EventCategoriesPage : BasePage
    {
        private IPage _page;

        public EventCategoriesPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToEventCategoriesPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.eventCategories);
        }
    }
}