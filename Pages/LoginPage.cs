namespace GembaCloud.PlaywrightTests.Pages
{
    public class LoginPage : BasePage
    {
        private IPage _page;
        private ILocator locatorEmailTextField;
        private ILocator locatorPasswordTextField;
        private ILocator locatorLogInButton;
        private ILocator locatorErrorBox;
        private ILocator locatorLockedOutMessageBox;
        private ILocator locatorAccountHasBeenLockedOutMessageBox;
        private ILocator locatorReturnToLoginScreenButton;

        public LoginPage(IPage page) : base(page)
        {
            _page = page;
            locatorEmailTextField = _page.Locator("css=input[placeholder='Email Address']");
            locatorPasswordTextField = _page.Locator("css=input[placeholder='Password']");
            locatorLogInButton = _page.GetByRole(AriaRole.Button, new() { Name = "Log in" });
            locatorErrorBox = _page.Locator("css=div[class='validation-summary alert alert-danger validation-summary-errors']");
            locatorLockedOutMessageBox = _page.GetByText("Locked out", new() { Exact = true });
            locatorAccountHasBeenLockedOutMessageBox = _page.GetByText("This account has been locked out. Please try again later.");
            locatorReturnToLoginScreenButton = _page.GetByRole(AriaRole.Link, new() { Name = "Return to Login Screen" });
        }

        public async Task GoToLoginPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.login);
        }
        
        public async Task LogIn(string usernameFromConfig, string passwordFromConfig = CredentialNames.correctPassword)
        {
            await ClearTextField(locatorEmailTextField);
            await ClearTextField(locatorPasswordTextField);

            EnterTextIntoTextField(locatorEmailTextField, _config.GetCredentials(usernameFromConfig).GetAwaiter().GetResult()).Wait();
            EnterTextIntoTextField(locatorPasswordTextField, _config.GetCredentials(passwordFromConfig).GetAwaiter().GetResult()).Wait();
            var logInButton = locatorLogInButton;
            logInButton.ClickAsync().GetAwaiter().GetResult();
        }

        public async Task AssertLoginFailedFromBlankCredentials()
        {
            try
            {
                Assert.That(_page.Url.ToString().Contains(await _config.GetUrl(PageNames.login)));
            }
            catch
            {
                throw new Exception("You have navigated to another page. You should still be on the login page");
            }
        }

        public async Task AssertLoginFailedFromInvalidCredentials()
        {
            try
            {
                Assert.That(_page.Url.ToString().Contains(await _config.GetUrl(PageNames.login)));
            }
            catch
            {
                throw new Exception("You have navigated to another page. You should still be on the login page");
            }

            try
            {
                Assert.That(await locatorErrorBox.InnerTextAsync() ==
                    "Invalid login attempt.",
                    $"The Email field is required.{Environment.NewLine}The Password field is required.");                    
            }
            catch
            {
                throw new Exception("Expected invalid credentials message or field validation message, but got something else");
            }
        }

        public async Task TriggerTooManyLogInAttemptsMessage()
        {
            //TODO: move this 5 to config
            for (int i = 0; i < 5; i++)
            {
                await LogIn(CredentialNames.failsToLogIn, CredentialNames.incorrectPassword);
            }
        }

        public async Task AssetUserLockedOutOfLoggingIn()
        {
            Assert.That(_page.Url.Contains("Account/Lockout"), "The user has not been directed to the lockout screen");
            Assert.That(await locatorLockedOutMessageBox.InnerTextAsync() == "Locked out");
            Assert.That(await locatorAccountHasBeenLockedOutMessageBox.InnerTextAsync() == "This account has been locked out. Please try again later.");
        }

        public async Task LogInWithTemporaryCredentials(string temporaryEmailAddress, string temporaryPassword)
        {
            await locatorEmailTextField.TypeAsync(temporaryEmailAddress);
            await locatorPasswordTextField.TypeAsync(temporaryPassword);
            await locatorLogInButton.ClickAsync();
        }
    }
}