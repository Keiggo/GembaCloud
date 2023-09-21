namespace GembaCloud.PlaywrightTests.Pages
{
    public class AccountConfirmationPage : BasePage
    {
        private IPage _page;
        private ILocator locatorProceedToLoginButton;

        public AccountConfirmationPage(IPage page) : base(page)
        {
            _page = page;
            locatorProceedToLoginButton = _page.Locator("css=a[href='/Account/Login']");
        }

        public async Task ClickProceedToLoginButton()
        {
            await WaitForPageLoad();
            await locatorProceedToLoginButton.ClickAsync();
        }
    }
}