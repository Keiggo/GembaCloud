namespace GembaCloud.PlaywrightTests.Pages
{
    public class KnowledgeBasePage : BasePage
    {
        private IPage _page;
        private ILocator locatorShowAllCheckbox;
        private ILocator locatorAddArticleButton;
        private ILocator locatorExampleEventCategoryEntityPickerPlusButton;
        private ILocator locatorExampleEventReasonEntityPickerEntity;
        private ILocator locatorSavedAndPublishedHeader;
        private ILocator locatorEditSavedAndPublishedArticleButton;
        private ILocator locatorSavedAndPublishedPanel;
        private ILocator locatorDeleteSavedAndPublishedArticleButton;
        private ILocator locatorDraftHeader;
        private ILocator locatorDraftPanel;

        public KnowledgeBasePage(IPage page) : base(page)
        {
            _page = page;
            locatorShowAllCheckbox = _page.GetByLabel("Show All");
            locatorAddArticleButton = _page.GetByRole(AriaRole.Link, new() { Name = "+ Add" });
            locatorExampleEventCategoryEntityPickerPlusButton = _page.GetByRole(AriaRole.Tabpanel, new() { Name = "Downtime  " }).Locator("i").First;
            locatorExampleEventReasonEntityPickerEntity = _page.GetByRole(AriaRole.Link, new() { Name = "Example Event Reason (1/2)" });
            locatorSavedAndPublishedHeader = _page.GetByText("Saved and Published");
            locatorEditSavedAndPublishedArticleButton = _page.Locator("css=#article-6 > div.panel-footer > div:nth-child(2) > div > div > a.btn.add-edit-article");
            locatorSavedAndPublishedPanel = _page.Locator("#article-6");
            locatorDeleteSavedAndPublishedArticleButton = _page.Locator("css=#article-6 > i[class='fa fa-trash-can']");
            locatorDraftHeader = _page.Locator("#article-6").GetByText("Delete");
            locatorDraftPanel = _page.Locator("#article-7");
    }

        public async Task GoToKnowledgeBasePage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.knowledgeBase);
        }

        public async Task AssertShowAllCheckboxIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorShowAllCheckbox);
        }

        public async Task ClickAddArticleButton()
        {
            await locatorAddArticleButton.ClickAsync();
        }

        public async Task AssertAddArticleButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorAddArticleButton);
        }

        public async Task ClickExampleEventCategoryEntityPickerPlusButton()
        {
            await locatorExampleEventCategoryEntityPickerPlusButton.ClickAsync();
        }

        public async Task ClickExampleEventReasonEntityPickerEntity()
        {
            IReadOnlyList<IElementHandle> downtimeItems = await _page.QuerySelectorAllAsync("css=a[class='jstree-anchor']");

            foreach (IElementHandle item in downtimeItems)
            {
                string innerText = await item.InnerTextAsync();
                if (innerText.Trim() == "Example Event Reason" || innerText.Trim() == "Example Event Reason (1/2)")
                {
                    await item.ClickAsync();
                }
            }
        }

        public async Task<IElementHandle> GetRow(string rowName)
        {
            var potentialRows = await _page.QuerySelectorAllAsync("css=span[data-bind='html: article.title']");
            foreach(var row in potentialRows)
            {
                if(await row.InnerTextAsync() == rowName)
                {
                    return row;
                }
            }

            throw new Exception("No row with that name exists on the page");
        }

        public async Task ExpandSavedAndPublishedPanel()
        {
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            var row = await GetRow("SAVED AND PUBLISHED");
            await row.ClickAsync();
        }

        public async Task AssertEditSavedAndPublishedArticleButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorEditSavedAndPublishedArticleButton);
        }

        public async Task AssertDeleteSavedAndPublishedArticleButtonIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorDeleteSavedAndPublishedArticleButton);
        }

        public async Task AssertDraftPaneIsNotOnPage()
        {
            await AssertElementIsNotPresent(locatorDraftHeader);
            await AssertElementIsNotPresent(locatorDraftPanel);
        }
    }
}