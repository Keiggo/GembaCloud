namespace GembaCloud.PlaywrightTests.Pages
{
    public class MyFormsPage : BasePage
    {
        private IPage _page;

        public MyFormsPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToMyFormsPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.myForms);
        }
    }
}