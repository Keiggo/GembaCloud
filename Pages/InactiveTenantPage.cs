namespace GembaCloud.PlaywrightTests.Pages
{
    public class InactiveTenantPage : BasePage
    {
        private IPage _page;
        private ILocator locatorLogOutButton;
        private ILocator locatorTenantSwitcher;

        public InactiveTenantPage(IPage page) : base(page)
        {
            _page = page;
            locatorLogOutButton = _page.Locator("css=button[title='Log out']");
            locatorTenantSwitcher = _page.Locator("css=span[title='Switch Account']");
        }

        public async Task ClickLogOutButton()
        {
            await locatorLogOutButton.ClickAsync();
        }

        public void AssertUrlIsCorrect()
        {
            Assert.That(_page.Url.EndsWith("/Account/Inactive"));
        }

        public async Task AssertTenantSwitcherIsPresent()
        {
            await AssertElementIsPresent(locatorTenantSwitcher);
        }
    }
}