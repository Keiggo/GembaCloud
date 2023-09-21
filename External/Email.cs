namespace GembaCloud.PlaywrightTests.Pages
{
    public class Email : BasePage
    {
        private IPage _page;
        
        public Email(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task NavigateToActionFromEmail(int actionId)
        {
            await _page.GotoAsync($"{_config.GetData().GetSection($"Urls:HostUrl").Value}Action/EditExternal?id={actionId}");
            await WaitForPageLoad();
        }

        public async Task AssertNavigatedToCorrectAction(int actionId)
        {
            await WaitForPageLoad();
            Assert.That(_page.Url == $"{_config.GetData().GetSection($"Urls:HostUrl").Value}Action/EditExternal?id={actionId}");
        }
    }
}