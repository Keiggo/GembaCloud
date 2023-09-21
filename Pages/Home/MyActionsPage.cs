namespace GembaCloud.PlaywrightTests.Pages
{
    public class MyActionsPage : BasePage
    {
        private IPage _page;

        public MyActionsPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToMyActionsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.myActions);
        }
    }
}