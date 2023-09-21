namespace GembaCloud.PlaywrightTests.Pages
{
    public class RevenueContractsPage : BasePage
    {
        private IPage _page;

        public RevenueContractsPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToRevenueContractsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.revenueContracts);
        }
    }
}