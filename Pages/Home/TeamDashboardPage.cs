namespace GembaCloud.PlaywrightTests.Pages
{
    public class TeamDashboardPage : BasePage
    {
        private IPage _page;

        public TeamDashboardPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToTeamDashboardPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.teamDashboard);
        }
    }
}