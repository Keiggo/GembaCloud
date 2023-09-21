namespace GembaCloud.PlaywrightTests.Pages
{
    public class HelpCentrePage : BasePage
    {
        private IPage _page;

        public HelpCentrePage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToHelpCentrePage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.helpCentre);
        }
    }
}