namespace GembaCloud.PlaywrightTests.Pages
{
    public class NavigationBar : BasePage
    {
        private IPage _page;
        private ILocator locatorUserAvatarId;
        private ILocator locatorLogOutButton;
        private ILocator locatorTenantSwitcher;
        private ILocator locatorTenantSwitcherOptions;
        private ILocator locatorSettingsButton;
        private ILocator locatorDesktopDropdownMenu;

        public NavigationBar(IPage page) : base(page)
        {
            _page = page;
            locatorDesktopDropdownMenu = _page.Locator("css=ul[class='dropdown-menu top-menu-dropdown']");
            locatorUserAvatarId = _page.Locator("css=button[id='top-menu-dropdown-trigger']");
            locatorLogOutButton = locatorDesktopDropdownMenu.Locator("css=button[title='Log out']");
            locatorTenantSwitcher = _page.Locator("css=span[title='Switch Account']");
            locatorTenantSwitcherOptions = _page.Locator("css=select[title='Switch Account']");
            locatorSettingsButton = locatorDesktopDropdownMenu.Locator("css=a[title='Setting Menu']");
        }

        public async Task ClickUserAvatar()
        {
            await locatorUserAvatarId.ClickAsync();
        }
        public async Task ClickSettingsButton()
        {
            await locatorSettingsButton.ClickAsync();
            await WaitForPageLoad();
        }

        public async Task LogOutOfCurrentUser()
        {
            await WaitForPageLoad();
            await locatorUserAvatarId.ClickAsync();
            await locatorLogOutButton.ClickAsync();
        }

        public async Task AssertUserIsLoggedIn()
        {
            await locatorUserAvatarId.WaitForAsync();
            Assert.That(await locatorUserAvatarId.IsVisibleAsync());
        }

        public async Task SwitchToTenant(string tenantName)
        {
            await WaitForPageLoad();
            await locatorTenantSwitcher.ClickAsync();
            await _page.Keyboard.TypeAsync(tenantName);
            await _page.Keyboard.PressAsync("Enter");
            await WaitForPageLoad();
        }

        public async Task AssertTenantSwitcherIsNotPresent()
        {
            await locatorTenantSwitcher.WaitForAsync();
            await AssertElementIsDisabled(locatorTenantSwitcher);
        }

        public async Task AssertTenantSwitcherIsPresent()
        {
            await locatorTenantSwitcher.WaitForAsync();
            await AssertElementIsEnabled(locatorTenantSwitcher);
        }

        public async Task AssertNavigatedToCorrectTenant(string correctTenantName)
        {
            await WaitForPageLoad();
            Assert.That(await locatorTenantSwitcher.InnerTextAsync() == correctTenantName.ToUpper());
        }

        public async Task AssertTenantIsNotInSwitcher(string tenantName)
        {
            await WaitForPageLoad();
            await locatorTenantSwitcher.ClickAsync();
            var availableTenants = await GetDropdownOptionsAsync(locatorTenantSwitcherOptions);

            foreach (var tenant in availableTenants)
            {
                var innerText = await tenant.InnerTextAsync();
                if (innerText.Contains(tenantName))
                {
                    throw new Exception($"'{tenantName}' is available in the switcher and it shouldn't be");
                }
            }
        }

        public async Task AssertTenantIsInSwitcher(string tenantName)
        {
            await WaitForPageLoad();
            var availableTenants = await GetDropdownOptionsAsync(locatorTenantSwitcher);

            foreach (var tenant in availableTenants)
            {
                if (await tenant.InnerTextAsync() == tenantName)
                {
                    return;
                }
            }

            throw new Exception($"'{tenantName}' is not available in the switcher and it should be :(");
        }
    }
}