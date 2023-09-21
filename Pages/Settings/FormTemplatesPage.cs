namespace GembaCloud.PlaywrightTests.Pages
{
    public class FormTemplatesPage : BasePage
    {
        private IPage _page;

        public FormTemplatesPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToFormTemplatesPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.formTemplates);
        }
    }
}