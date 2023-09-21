namespace GembaCloud.PlaywrightTests.Pages
{
    public class ActionStatusPage : BasePage
    {
        private IPage _page;

        public ActionStatusPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToActionStatusPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.actionStatus);
        }
    }
}