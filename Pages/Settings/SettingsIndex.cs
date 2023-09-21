namespace GembaCloud.PlaywrightTests.Pages
{
    public class SettingsIndex : BasePage
    {
        private IPage _page;
        private ILocator locatorGuestsLink;
        private ILocator locatorTeamsLink;

        public SettingsIndex(IPage page) : base(page)
        {
            _page = page;
            locatorGuestsLink = _page.Locator("#pageContent").GetByRole(AriaRole.Link, new() { Name = " Guests" });
            locatorTeamsLink = _page.Locator("#pageContent").GetByRole(AriaRole.Link, new() { Name = " Teams" });
        }

        public async Task ClickGuestsLink()
        {
            await locatorGuestsLink.ClickAsync();
        }

        public async Task ClickTeamsLink()
        {
            await locatorTeamsLink.ClickAsync();
            await WaitForPageLoad();
        }
    }
}