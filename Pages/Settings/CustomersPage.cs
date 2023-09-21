namespace GembaCloud.PlaywrightTests.Pages
{
    public class CustomersPage : BasePage
    {
        private IPage _page;

        public CustomersPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToCustomersPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.customers);
        }
    }
}