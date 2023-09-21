namespace GembaCloud.PlaywrightTests.Pages
{
    public class ActionSearchPage : BasePage
    {
        private IPage _page;

        public ActionSearchPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToActionSearchPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.actionSearch);
        }
    }
}