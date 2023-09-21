namespace GembaCloud.PlaywrightTests.Pages
{
    public class ChangeLogPage : BasePage
    {
        private IPage _page;

        public ChangeLogPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToChangeLogPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.changeLog);
        }
    }
}