namespace GembaCloud.PlaywrightTests.Pages
{
    public class GembaIntelligencePage : BasePage
    {
        private IPage _page;
        private ILocator locatorAcknowledgeButton;
        private ILocator locatorFilterStartDate;
        private ILocator locatorSelectAllAssetsCheckbox;
        private ILocator locatorSubTable;//wtf?!?!?!
        private ILocator locatorAcknowledgeDropdownButton;
        private ILocator locatorLogBookDropdownButton;
        private ILocator locatorCreateActionDropdownButton;

        public GembaIntelligencePage(IPage page) : base(page)
        {
            _page = page;
            locatorAcknowledgeButton = _page.Locator("#grid-buttons a").Filter(new() { HasText = "Acknowledge" });
            locatorFilterStartDate = _page.GetByLabel("Start Date:");
            locatorSelectAllAssetsCheckbox = _page.GetByRole(AriaRole.Link, new() { Name = "System Top Level" });
            locatorSubTable = _page.GetByRole(AriaRole.Cell, new() { Name = "Type Category Code Detail Description Cost  Availability N/A N/A N/A 36.4% drop from the average of 59.6% to 23.2% 30035.0 units 120.2 mins   Downtime Duration Example Event Category 001 Example Event Reason 5.6x increase from the average of 7.07 mins to 39.4 mins 30035.0 units 120.2 mins " });//wtf?!?!?!
            locatorAcknowledgeDropdownButton = _page.GetByRole(AriaRole.Cell, new()).GetByText("Acknowledge");
            locatorLogBookDropdownButton = _page.GetByRole(AriaRole.Cell, new()).GetByText("Log Book");
            locatorCreateActionDropdownButton = _page.GetByRole(AriaRole.Cell, new()).GetByText("Create Action");
    }

        public async Task<IReadOnlyList<IElementHandle>> GetGembaIntelligenceTable()
        {
            var table = await GetTable("foreach: shifts", "assetShiftId");
            return table;
        }

        public async Task GoToGembaIntelligencePage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.gembaIntelligence);
        }

        public async Task AssertAcknowledgeButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorAcknowledgeButton);
        }

        private async Task<IElementHandle> FindSubTableRowElipsesButton(int tableRowIndex, int subTableRowIndex)
        {
            await _page.Locator("css=tr[class='kpi-row']").WaitForAsync();
            IReadOnlyList<IElementHandle> subTable = await _page.QuerySelectorAllAsync("css=tr[class='kpi-row']");

            return subTable[0];
        }

        public async Task ClickSubTableRowElipsesButton(int tableRowIndex, int subTableRowIndex)
        {
            IElementHandle button = await FindSubTableRowElipsesButton(tableRowIndex, subTableRowIndex);
                
            await button.ClickAsync();
        }

        public async Task ExpandGembaIntelligenceTableRow(int rowIndex)
        {
            await ExpandTableRow(await GetGembaIntelligenceTable(), rowIndex);
        }

        public async Task SetFilterStartDate(string yyyy, string mm, string dd)
        {
            await locatorFilterStartDate.ClickAsync();
            await ClearTextField(locatorFilterStartDate);
                
            await _page.Keyboard.TypeAsync($"{yyyy}-{mm}-{dd}");
            await locatorFilterStartDate.PressAsync("Enter");
        }

        public async Task SelectAllAssetsInPicker()
        {
            await SelectAssetPickerCheckBox(locatorSelectAllAssetsCheckbox);
        }

        public async Task ClickGembaIntelligenceSubTableElipsisButton(int tableRowIndex, int subTableRowIndex)
        {
            await ClickSubTableRowElipsesButton(tableRowIndex, subTableRowIndex);
        }

        public async Task AssertAcknowledgeDropdownButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorAcknowledgeDropdownButton);
        }

        public async Task AssertCreateActionDropdownButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorCreateActionDropdownButton);
        }
    }
}