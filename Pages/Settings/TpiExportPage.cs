namespace GembaCloud.PlaywrightTests.Pages
{
    public class TpiExportPage : BasePage
    {
        private IPage _page;

        public TpiExportPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToTpiExportPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.tpiExport);
        }
    }
}