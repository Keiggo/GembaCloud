using GembaCloud.PlaywrightTests.Pages;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class GuestsPageUserRoleElementAuthorisationTests : BaseTests
    {
        [TestCase(CredentialNames.accountAdministration)]
        [TestCase(CredentialNames.guestAccountAdministration)]
        public async Task account_admin_user_should_not_have_access_to_add_guests_button(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            GuestsPage _guestsPage = new GuestsPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType, CredentialNames.correctPassword).GetAwaiter().GetResult();
                _guestsPage.GoToGuestsPage().GetAwaiter().GetResult();
                _guestsPage.AssertAddGuestButtonIsNotPresent().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.accountAdministration)]
        [TestCase(CredentialNames.guestAccountAdministration)]
        public async Task account_admin_user_should_not_have_access_to_edit_guests_button(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            GuestsPage _guestsPage = new GuestsPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType, CredentialNames.correctPassword).GetAwaiter().GetResult();
                _guestsPage.GoToGuestsPage().GetAwaiter().GetResult();
                _guestsPage.AssertEditGuestButtonIsNotPresent().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.accountAdministration)]
        [TestCase(CredentialNames.guestAccountAdministration)]
        public async Task account_admin_user_should_not_have_access_to_delete_guests_button(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            GuestsPage _guestsPage = new GuestsPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType, CredentialNames.correctPassword).GetAwaiter().GetResult();
                _guestsPage.GoToGuestsPage().GetAwaiter().GetResult();
                _guestsPage.AssertDeleteGuestButtonIsNotPresent().GetAwaiter().GetResult();
            }
        }
    }
}