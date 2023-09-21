namespace GembaCloud.PlaywrightTests.Pages
{
    public class StandardRatesPage : BasePage
    {
        private IPage _page;

        public StandardRatesPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToStandardRatesPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.standardRates);
        }
    }
}