namespace GembaCloud.PlaywrightTests.Pages
{
    public class GuestsPage : BasePage
    {
        private IPage _page;
        public ILocator locatorSearchGuests;
        public ILocator locatorAddGuestButton;
        public ILocator locatorEditGuestButton;
        public ILocator locatorDeleteGuestButton;
        public ILocator locatorModalUserDropdown;
        public ILocator locatorModalCreateButton;
        public ILocator locatorModalSaveButton;
        public ILocator locatorModalDeleteButton;
        public ILocator locatorModalHplaDropdown;

        public GuestsPage(IPage page) : base(page)
        {
            _page = page;
            locatorAddGuestButton = _page.Locator("css=a[data-postback='/Guest/Create']");
            locatorEditGuestButton = _page.Locator("css=a[data-postback='/Guest/Edit']");
            locatorDeleteGuestButton = _page.Locator("css=a[data-postback='/Guest/Delete']");
            locatorModalUserDropdown = _page.Locator("css=select[id='UserId']");
            locatorModalCreateButton = _page.Locator("css=button[value='Create']");
            locatorModalSaveButton = _page.Locator("css=button[value='Save']");
            locatorSearchGuests = _page.Locator("css=input[type='search']");
            locatorModalDeleteButton = _page.Locator("css=button[value='Delete']");
            locatorModalHplaDropdown = _page.Locator("css=select[id='HPLAGroupId']");
        }

        public async Task GoToGuestsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.guests);
        }

        public async Task AssertAddGuestButtonIsNotPresent()
        {
            await AssertElementIsNotPresent(locatorAddGuestButton);
        }

        public async Task AssertEditGuestButtonIsNotPresent()
        {
            await AssertElementIsNotPresent(locatorEditGuestButton);
        }

        public async Task AssertDeleteGuestButtonIsNotPresent()
        {
            await AssertElementIsNotPresent(locatorDeleteGuestButton);
        }

        public async Task ClickAddGuestButton()
        {
            await locatorAddGuestButton.ClickAsync();
        }

        public async Task ClickEditGuestButton()
        {
            await locatorEditGuestButton.ClickAsync();
        }

        public async Task SelectModalUserDropdown(string username)
        {
            var availableOptions = await GetDropdownOptionsAsync(locatorModalUserDropdown);

            foreach (var option in availableOptions)
            {
                var innerText = await option.InnerTextAsync();

                if (innerText.Contains(await _config.GetCredentials(username)))
                {
                    await locatorModalUserDropdown.SelectOptionAsync(option);
                    return;
                }
            }

            throw new Exception($"The user '{username}' is not listed");
        }

        public async Task ClickModalCreateButton()
        {
            await WaitForPageLoad();
            await locatorModalCreateButton.ClickAsync();
        }

        public async Task ClickModalSaveButton()
        {
            await WaitForPageLoad();
            await locatorModalSaveButton.ClickAsync();
        }

        public async Task SearchForGuest(string guest)
        {
            await EnterTextIntoTextField(locatorSearchGuests, guest);
        }

        public async Task ClickDeleteGuestButton()
        {
            await locatorDeleteGuestButton.ClickAsync();
        }

        public async Task ClickModalDeleteButton()
        {
            await locatorModalDeleteButton.ClickAsync();
        }

        public async Task SelectModalHplaDropdown(string hplaGroup)
        {
            await SelectDropDownOptionByText(locatorModalHplaDropdown, hplaGroup);
        }
    }
}