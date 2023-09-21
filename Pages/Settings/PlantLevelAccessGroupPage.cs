namespace GembaCloud.PlaywrightTests.Pages
{
    public class PlantLevelAccessGroupPage : BasePage
    {
        private IPage _page;
        public ILocator locatorSearchField;
        public ILocator locatorEditPlantLevelAccessGroup2Button;
        public ILocator locatorModalSaveButton;

        public PlantLevelAccessGroupPage(IPage page) : base(page)
        {
            _page = page;
            locatorSearchField = _page.GetByLabel("Search:");
            locatorEditPlantLevelAccessGroup2Button = _page.GetByRole(AriaRole.Row, new() { Name = "Example Plant Level Access Group 2" }).GetByRole(AriaRole.Link, new() { Name = "Edit" });
            locatorModalSaveButton = _page.GetByRole(AriaRole.Button, new() { Name = "? Save" });
    }

        public async Task GoToPlantLevelAccessGroupPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.plantLevelAccessGroup);
        }

        public async Task SearchPlantLevelAccessGroups(string textToEnter)
        {
            await EnterTextIntoTextField(locatorSearchField, textToEnter);
        }

        public async Task ClickPlantLevelAccessGroup2Button()
        {
            await locatorEditPlantLevelAccessGroup2Button.ClickAsync();
        }

        public async Task ClickModalSaveButton()
        {
            await locatorModalSaveButton.ClickAsync();
        }
    }
}