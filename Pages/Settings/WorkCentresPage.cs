namespace GembaCloud.PlaywrightTests.Pages
{
    public class WorkCentresPage : BasePage
    {
        private IPage _page;

        public WorkCentresPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToWorkCentresPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.workCentres);
        }
    }
}