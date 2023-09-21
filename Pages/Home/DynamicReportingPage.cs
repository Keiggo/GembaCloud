using System.Linq;

namespace GembaCloud.PlaywrightTests.Pages
{
    public class DynamicReportingPage : BasePage
    {
        private IPage _page;
        private ILocator locatorCustomReportModalTab;
        private ILocator locatorAssetsRowHeaderModal;
        private ILocator locatorModalCloseButton;
        private ILocator locatorCategoryDropdown;

        public DynamicReportingPage(IPage page) : base(page)
        {
            _page = page;
            locatorCustomReportModalTab = _page.GetByRole(AriaRole.Link, new() { Name = "Custom Report" });
            locatorAssetsRowHeaderModal = _page.GetByRole(AriaRole.Button, new() { Name = "Assets: All" });
            locatorModalCloseButton = _page.GetByRole(AriaRole.Button, new() { Name = "×" });
            locatorCategoryDropdown = _page.Locator("css=select[id='dropDownBoxCategory']");
        }

        public async Task GoToDynamicReportingPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.dynamicReporting);
        }

        public async Task ClickCustomReportModalTab()
        {
            await locatorCustomReportModalTab.ClickAsync();
        }

        public async Task ClickAssetsRowHeaderModal()
        {
            await locatorAssetsRowHeaderModal.ClickAsync();
        }

        public async Task ClickModalCloseButton()
        {
            await locatorModalCloseButton.ClickAsync();
        }

        public List<string> GetModuleAuthorisedCategoriesList(string userType)
        {
            switch (userType)
            {
                case CredentialNames.oeeModuleOnly:
                    return StandardReportCategoryNames.GetOeeCategories();

                case CredentialNames.actionManagementModuleOnly:
                    return StandardReportCategoryNames.GetActionManagementCategories();

                case CredentialNames.connectSystemsIntegrationModuleOnly:
                    return StandardReportCategoryNames.GetConnectSystemsIntegrationCategories();

                case CredentialNames.plantConnectionModuleOnly:
                    return StandardReportCategoryNames.GetPlantConnectionCategories();

                case CredentialNames.revenueModuleOnly:
                    return StandardReportCategoryNames.GetRevenueCategories();

                case CredentialNames.gembaIntelligenceModuleOnly:
                    return StandardReportCategoryNames.GetGembaIntelligenceCategories();

                case CredentialNames.recipesModuleOnly:
                    return StandardReportCategoryNames.GetRecipesCategories();

                default:
                    throw new Exception("Can't get categories list as userType is not a recognised type of user. How did you even do that?");
            }
        }

        public async Task AssertCorrectCategoriesAreAvailableForUser (string user)
        {
            List<string> correctCategoriesList = GetModuleAuthorisedCategoriesList(user);
            List<string> availableCategoriesList = await GetAvailableCategories();

            if (correctCategoriesList.Count == 0)
            {
                Assert.That(availableCategoriesList.Count == 1, "There are rogue categories that should not be available");
                Assert.That(availableCategoriesList.Contains("No Report Categories"), "There are categories available when there should not be");
            }

            else foreach (var category in availableCategoriesList)
            {
                Assert.That(correctCategoriesList.Contains(category), $"'{category}' should not be an available category for this module");
            }
        }

        public async Task<List<string>> GetAvailableCategories()
        {
            List<string> availableCategoriesByName = new List<string>();

            var availableCategoriesById = await GetDropdownOptionsAsync(locatorCategoryDropdown);

            foreach (var category in availableCategoriesById) 
            {
                availableCategoriesByName.Add(await category.InnerTextAsync());
            }

            return availableCategoriesByName;
        }
    }
}