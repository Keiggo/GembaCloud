namespace GembaCloud.PlaywrightTests.Pages
{
    public class ManageYourUserProfilePage : BasePage
    {
        private IPage _page;

        public ManageYourUserProfilePage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToManageYourUserProfilePage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.manageYourUserProfile);
        }

        public async Task AssertUserNavigatedToManageYourUserProfilePage()
        {
            await AssertNavigatedToCorrectPage(await _config.GetUrl(PageNames.manageYourUserProfile));
        }
    }
}