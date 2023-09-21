namespace GembaCloud.PlaywrightTests.Pages
{
    public class OeeDashboardPage : BasePage
    {
        private IPage _page;
        private ILocator locatorOeeButton;
        private ILocator locatorAvailButton;
        private ILocator locatorPerfButton;
        private ILocator locatorQualButton;
        private ILocator locatorActionButton;
        private ILocator locatorStartDateField;
        private ILocator locatorEndDateField;
        private ILocator locatorActionModalCategoryDropdown;
        private ILocator locatorActionModalCreateButton;
        private ILocator locatorActionModalTitleField;

        public OeeDashboardPage(IPage page) : base(page)
        {
            _page = page;
            locatorOeeButton = _page.Locator("button.btn.OEE");
            locatorAvailButton = _page.Locator("button.btn.AvailData");
            locatorPerfButton = _page.Locator("button.btn.PerfData");
            locatorQualButton = _page.Locator("button.btn.QualData");
            locatorActionButton = _page.Locator("button[id='ActionNavBar']");
            locatorStartDateField = _page.Locator("input[id='StartDate']");
            locatorEndDateField = _page.Locator("input[id='EndDate']");
            locatorActionModalCategoryDropdown = _page.Locator("select[id='CategoryID']");
            locatorActionModalCreateButton = _page.Locator("button[value='Create']");
            locatorActionModalTitleField = _page.Locator("input[id='Title']");
        }

        public async Task GoToOeeDashboardPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.oeeDashboard);
        }

        public async Task AssertNavigatedToOeeDashboardPage()
        {
            await AssertNavigatedToCorrectPage(await _config.GetUrl(PageNames.oeeDashboard));
        }

        public async Task ClickOeeButton()
        {
            await locatorOeeButton.ClickAsync();
        }

        public async Task ClickAvailButton()
        {
            await locatorAvailButton.ClickAsync();
        }

        public async Task ClickPerfButton()
        {
            await locatorPerfButton.ClickAsync();
        }

        public async Task ClickQualButton()
        {
            await locatorQualButton.ClickAsync();
        }

        public async Task ClickActionButton()
        {
            await locatorActionButton.ClickAsync();
            await WaitForPageLoad();
        }

        public async Task SelectAsset(string asset)
        {
            await SelectAssetTreeAssetCheckBox(asset);
        }

        public async Task SetStartDate(string yyyy, string mm, string dd)
        {
            await EnterDateIntoJsDatePicker(locatorStartDateField, yyyy, mm, dd);
        }

        public async Task SetEndDate(string yyyy, string mm, string dd)
        {
            await EnterDateIntoJsDatePicker(locatorEndDateField, yyyy, mm, dd);
        }

        public async Task AssertOeeByAssetChartIsLoaded()
        {
            await CompareCurrentPageToScreenshot("OeeByAssetChartScreenshot.png");
        }

        public async Task AssertOeeComponentsChartIsLoaded()
        {
            await CompareCurrentPageToScreenshot("OeeComponentsChartScreenshot.png");
        }

        public async Task AssertOeeTrendChartIsLoaded()
        {
            await CompareCurrentPageToScreenshot("OeeTrendChartScreenshot.png");
        }

        public async Task AssertAvailabilityByAssetChartIsLoaded()
        {
            await CompareCurrentPageToScreenshot("AvailabilityByAssetChartScreenshot.png");
        }

        public async Task AssertReasonsChartIsLoaded()
        {
            await CompareCurrentPageToScreenshot("ReasonsChartScreenshot.png");
        }

        public async Task AssertAvailabilityTrendChartIsLoaded()
        {
            await CompareCurrentPageToScreenshot("AvailabilityTrendChartScreenshot.png");
        }

        public async Task AssertPerformanceByAssetChartIsLoaded()
        {
            await CompareCurrentPageToScreenshot("PerformanceByAssetChartScreenshot.png");
        }

        public async Task AssertProductPerformanceChartIsLoaded()
        {
            await CompareCurrentPageToScreenshot("ProductPerformanceChartScreenshot.png");
        }

        public async Task AssertProductPerformanceTrendChartIsLoaded()
        {
            await CompareCurrentPageToScreenshot("ProductPerformanceTrendChartScreenshot.png");
        }

        public async Task AssertQualityByAssetChartIsLoaded()
        {
            await CompareCurrentPageToScreenshot("QualityByAssetChartScreenshot.png");
        }

        public async Task AssertProductQualityChartIsLoaded()
        {
            await CompareCurrentPageToScreenshot("ProductQualityChartScreenshot.png");
        }

        public async Task AssertQualityReasonChartIsLoaded()
        {
            await CompareCurrentPageToScreenshot("QualityReasonChartScreenshot.png");
        }

        public async Task AssertQualityTrendChartIsLoaded()
        {
            await CompareCurrentPageToScreenshot("QualityTrendChartScreenshot.png");
        }

        public async Task SelectActionModalCategoryDropdown(string option)
        {
            await SelectDropDownOptionByText(locatorActionModalCategoryDropdown, option);
        }

        public async Task ClickActionModalCreateButton()
        {
            await WaitForPageLoad();
            await locatorActionModalCreateButton.ClickAsync();
            await WaitForPageLoad();
        }

        public async Task<string> GetCurrentActionModalTitle()
        {
            return await locatorActionModalTitleField.InputValueAsync();
        }
    }
}