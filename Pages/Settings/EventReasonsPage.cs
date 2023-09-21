namespace GembaCloud.PlaywrightTests.Pages
{
    public class EventReasonsPage : BasePage
    {
        private IPage _page;

        public EventReasonsPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToEventReasonsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.eventReasons);
        }
    }
}