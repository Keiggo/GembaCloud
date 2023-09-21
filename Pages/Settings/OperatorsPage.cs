namespace GembaCloud.PlaywrightTests.Pages
{
    public class OperatorsPage : BasePage
    {
        private IPage _page;

        public OperatorsPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToOperatorsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.operators);
        }
    }
}