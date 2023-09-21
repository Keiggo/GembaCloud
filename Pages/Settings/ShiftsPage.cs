namespace GembaCloud.PlaywrightTests.Pages
{
    public class ShiftsPage : BasePage
    {
        private IPage _page;

        public ShiftsPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToShiftsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.shifts);
        }
    }
}