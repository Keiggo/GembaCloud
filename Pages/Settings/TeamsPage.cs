namespace GembaCloud.PlaywrightTests.Pages
{
    public class TeamsPage : BasePage
    {
        private IPage _page;
        private ILocator locatorModalSelectMemberDropdown;
        private ILocator locatorAddMemberButton;

        public TeamsPage(IPage page) : base(page)
        {
            _page = page;
            locatorModalSelectMemberDropdown = _page.Locator("css=span[id$='UserID-container']");
            locatorAddMemberButton = _page.Locator("css=a[id='addItem']");
        }

        public async Task GoToTeamsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.teams);
        }

        public async Task ClickEditTeamButton()
        {
            IReadOnlyList<IElementHandle> table = await _page.QuerySelectorAllAsync("tbody");
            var tableRow = await GetTableRow(table, 0);
            var editButton = await tableRow.QuerySelectorAsync("a[data-postback='/Team/Edit']");

            await editButton.ClickAsync();
        }

        public async Task AssertTeamMemberIsAvailable(string teamMemberUsername)
        {
            await locatorModalSelectMemberDropdown.ClickAsync();
            await _page.Keyboard.TypeAsync(teamMemberUsername);
            await _page.Keyboard.PressAsync("Enter");

            var selectedUser = await locatorModalSelectMemberDropdown.InnerTextAsync();
            Assert.That(selectedUser.Contains(teamMemberUsername));
        }

        public async Task ClickAddMemberButton()
        {
            await locatorAddMemberButton.ClickAsync();
            await WaitForPageLoad();
        }
    }
}