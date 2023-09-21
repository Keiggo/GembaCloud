namespace GembaCloud.PlaywrightTests.Pages
{
    public class DailyProductionReviewPage : BasePage
    {
        private IPage _page;

        public DailyProductionReviewPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToDailyProductionReviewPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.dailyProductionReview);
        }
    }
}