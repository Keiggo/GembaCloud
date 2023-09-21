namespace GembaCloud.PlaywrightTests.Pages
{
    public class RecipeTemplateConfigurationPage : BasePage
    {
        private IPage _page;

        public RecipeTemplateConfigurationPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToRecipeTemplateConfigurationPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.recipeTemplateConfigurations);
        }
    }
}