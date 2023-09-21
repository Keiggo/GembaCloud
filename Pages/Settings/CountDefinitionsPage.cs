namespace GembaCloud.PlaywrightTests.Pages
{
    public class CountDefinitionsPage : BasePage
    {
        private IPage _page;

        public CountDefinitionsPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToCountDefinitionsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.countDefinitions);
        }
    }
}