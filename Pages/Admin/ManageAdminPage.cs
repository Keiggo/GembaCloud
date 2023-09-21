namespace GembaCloud.PlaywrightTests.Pages
{
    public class ManageAdminPage : BasePage
    {
        private IPage _page;

        public ManageAdminPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToManageAdminPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.manageAdmin);
        }
    }
}