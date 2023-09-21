namespace GembaCloud.PlaywrightTests.Pages
{
    public class ManageTenantsPage : BasePage
    {
        private IPage _page;

        public ManageTenantsPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToManageTenantsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.manageTenants);
        }
    }
}