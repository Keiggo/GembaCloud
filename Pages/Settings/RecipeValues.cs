namespace GembaCloud.PlaywrightTests.Pages
{
        public class RecipeValuesPage : BasePage
        {
        private IPage _page;

        public RecipeValuesPage(IPage page) : base(page)
            {
                _page = page;
            }

            public async Task GoToRecipeValuesPage(bool isPageAccessTest = false)
            {
                await GoToUrl(isPageAccessTest, PageNames.recipeValues);
            }
        }
}