using GembaCloud.PlaywrightTests.Pages;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture, Order(1)]
    public class UserAuthenticationTests : BaseTests
    {
        [Test]
        public async Task user_cant_login_with_invalid_credentials()
        {
            LoginPage _loginPage = new LoginPage(page);

            lock (CredentialNames.incorrectPassword)
            {
                _loginPage.LogIn(CredentialNames.accountAdministration, CredentialNames.incorrectPassword).GetAwaiter().GetResult();
                _loginPage.AssertLoginFailedFromInvalidCredentials().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task user_cant_login_with_blank_credentials()
        {
            LoginPage _loginPage = new LoginPage(page);

            lock (CredentialNames.blankEmail)
            {
                _loginPage.LogIn(CredentialNames.blankEmail, CredentialNames.blankPassword).GetAwaiter().GetResult();
                _loginPage.AssertLoginFailedFromBlankCredentials().GetAwaiter().GetResult();
            }
        }

        [Test, Timeout(1200000), Order(1)]
        public async Task user_is_prevented_from_logging_in_for_15_minutes_after_5_failed_attempts()
        {
            LoginPage _loginPage = new LoginPage(page);
            NavigationBar _navigationBar = new NavigationBar(page);

            lock (CredentialNames.failsToLogIn) //don't strictly need to lock here but this test is very timing based so it's best to
            {
                _loginPage.TriggerTooManyLogInAttemptsMessage().GetAwaiter().GetResult();
                _loginPage.AssetUserLockedOutOfLoggingIn().GetAwaiter().GetResult();

                _loginPage.GoToLoginPage().GetAwaiter().GetResult();
                _loginPage.LogIn(CredentialNames.failsToLogIn).GetAwaiter().GetResult();

                _loginPage.AssetUserLockedOutOfLoggingIn().GetAwaiter().GetResult(); //this is to assert that the user can't log in, even if they get the password correct now

                Thread.Sleep(TimeSpan.FromMinutes(14)); //waits 14 minutes(!) before asserting that it still can't log in
                _loginPage.GoToLoginPage().GetAwaiter().GetResult();
                _loginPage.LogIn(CredentialNames.failsToLogIn).GetAwaiter().GetResult();

                _loginPage.AssetUserLockedOutOfLoggingIn().GetAwaiter().GetResult();

                Thread.Sleep(TimeSpan.FromMinutes(1)); //finally waits another minute before asserting that it can now log in
                _loginPage.GoToLoginPage().GetAwaiter().GetResult();
                _loginPage.LogIn(CredentialNames.failsToLogIn).GetAwaiter().GetResult();

                _navigationBar.AssertUserIsLoggedIn().GetAwaiter().GetResult();
            }
        }
    }
}