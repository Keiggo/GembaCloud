namespace GembaCloud.PlaywrightTests.Pages
{
    public class PartsPage : BasePage
    {
        private IPage _page;

        public PartsPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToPartsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.parts);
        }
    }
}