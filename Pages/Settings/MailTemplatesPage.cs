namespace GembaCloud.PlaywrightTests.Pages
{
    public class MailTemplatesPage : BasePage
    {
        private IPage _page;

        public MailTemplatesPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToMailTemplatesPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.mailTemplates);
        }
    }
}