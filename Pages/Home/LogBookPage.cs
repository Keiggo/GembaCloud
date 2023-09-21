namespace GembaCloud.PlaywrightTests.Pages
{
    public class LogBookPage : BasePage
    {
        private IPage _page;
        private ILocator locatorGridViewButton;
        private ILocator locatorAddLogButton;
        private ILocator locatorSelectAllAssetsCheckbox;
        private ILocator locatorDeleteLogButton;
        private ILocator locatorEditLogButton;
        private ILocator locatorViewLogButton;
        private ILocator locatorStartDateField;
        private ILocator locatorFormPane;
        private ILocator locatorLogBookTable;

        public LogBookPage(IPage page) : base(page)
        {
            _page = page;
            locatorGridViewButton = _page.GetByRole(AriaRole.Link, new() { Name = " Grid View" });
            locatorAddLogButton = _page.GetByRole(AriaRole.Link, new() { Name = "+ Add" });
            locatorSelectAllAssetsCheckbox = _page.GetByRole(AriaRole.Link, new() { Name = "System Top Level" });
            locatorDeleteLogButton = _page.Locator("td:nth-child(9)");
            locatorEditLogButton = _page.GetByRole(AriaRole.Link, new() { Name = " Edit" });
            locatorViewLogButton = _page.GetByRole(AriaRole.Link, new() { Name = "View", Exact = true });
            locatorStartDateField = _page.Locator("#LogBookStartDate");
            locatorFormPane = _page.Locator("#EditForm div");
            locatorLogBookTable = _page.Locator("#pageContent");
        }

        public async Task GoToLogBookPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.logBook);
        }

        public async Task<IReadOnlyList<IElementHandle>> GetLogBookTable()
        {
            return await GetTable();
        }

        public async Task AssertAddLogButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorAddLogButton);
        }

        public async Task ClickAddLogButton()
        {
            await locatorAddLogButton.ClickAsync();
        }

        public async Task ClickGridViewButton()
        {
            await locatorGridViewButton.ClickAsync();
        }

        public async Task SelectAllAssets()
        {
            await SelectAssetPickerCheckBox(locatorSelectAllAssetsCheckbox);
        }

        public async Task AssertDeleteLogButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorDeleteLogButton);
        }

        public async Task AssertEditLogButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorEditLogButton);
        }

        public async Task ClickEditLogButton()
        {
            await locatorEditLogButton.ClickAsync();
        }

        public async Task<IElementHandle> FindViewLogButtonInLogBookTableRow(int rowIndex)
        {
            var table = await GetLogBookTable();
            var row = table[rowIndex];
            var viewLogButton = await row.QuerySelectorAsync(GetElementSelector(locatorViewLogButton).ToString());

            return viewLogButton;
        }

        public async Task ClickViewLogButton(int containingTableRowIndex)
        {
            var viewLogButton = FindViewLogButtonInLogBookTableRow(containingTableRowIndex);
            await locatorViewLogButton.ClickAsync();
        }

        public async Task SetStartDateFilter(string yyyy, string mm, string dd)
        {
            await EnterDateIntoHtml5DatePicker(locatorStartDateField, yyyy, mm, dd);
            await _page.Keyboard.PressAsync("Enter");
        }
    }
}