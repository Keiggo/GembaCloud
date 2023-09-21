namespace GembaCloud.PlaywrightTests.Pages
{
    public class ShiftEditorPage : BasePage
    {
        private IPage _page;
        private ILocator locatorShiftDropdown;
        private ILocator locatorAssetEllipsisButton;
        private ILocator locatorCreateShiftButton;
        private ILocator locatorNoDataMessage;
        private ILocator locatorSystemTopLevelBranch;
        private ILocator locatorShiftDateField;
        private ILocator locatorSaveShiftButton;
        private ILocator locatorCancelEditButton;
        private ILocator locatorDeleteShiftButton;
        private ILocator locatorProductionRunsHeader;

        public ShiftEditorPage(IPage page) : base(page)
        {
            _page = page;
            locatorShiftDropdown = _page.GetByRole(AriaRole.Combobox, new() { Name = "Shift" });
            locatorAssetEllipsisButton = _page.Locator("css=button[class='asset-popup-button icon-button']");
            locatorCreateShiftButton = _page.Locator("xpath=//button[.='Create']");
            locatorNoDataMessage = _page.GetByText("No data for the selected Date, Shift and Asset");
            locatorSystemTopLevelBranch = _page.GetByRole(AriaRole.Link, new() { Name = "System Top Level" });
            locatorShiftDateField = _page.GetByLabel("Shift Date");
            locatorSaveShiftButton = _page.Locator("a").Filter(new() { HasText = "Save" }).Nth(1);
            locatorCancelEditButton = _page.Locator("#grid-buttons a").Filter(new() { HasText = "Cancel" });
            locatorDeleteShiftButton = _page.Locator("a").Filter(new() { HasText = "Delete" });
            locatorProductionRunsHeader = _page.GetByRole(AriaRole.Button, new() { Name = " Production Runs" });
        }

        public async Task GoToShiftEditorPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.shiftEditor);
        }

        public async Task SelectShiftDropDownOptionByIndex(int optionIndex)
        {
            await SelectDropDownOptionByIndex(locatorShiftDropdown, optionIndex);
        }

        public async Task SelectShiftDropDownOptionByText(string optionText)
        {
            await SelectDropDownOptionByText(locatorShiftDropdown, optionText);
        }

        public async Task ClickAssetEllipsisButton()
        {
            await locatorAssetEllipsisButton.ClickAsync();
            await _page.WaitForSelectorAsync("a[class='jstree-anchor']");
        }

        public async Task SetShiftDate(string yyyy, string mm, string dd)
        {
            await ClearTextField(locatorShiftDateField);
            await EnterTextIntoTextField(locatorShiftDateField, $"{yyyy}-{mm}-{dd}");
            await _page.Keyboard.PressAsync("Enter");
        }

        public async Task AssertCreateShiftButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorCreateShiftButton);
        }

        public async Task AssertDeleteShiftButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorDeleteShiftButton);
        }

        public async Task AssertCancelEditButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorCancelEditButton);
        }

        public async Task AssertSaveShiftButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorSaveShiftButton);
        }
    }
}