namespace GembaCloud.PlaywrightTests.Pages
{
    public class GeneralAccountSettingsPage : BasePage
    {
        private IPage _page;

        public GeneralAccountSettingsPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToGeneralAccountSettingsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.generalAccountSettings);
        }
    }
}