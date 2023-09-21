using GembaCloud.PlaywrightTests.Pages;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    public class PendingFormTests : BaseTests
    {
        [Test]
        public async Task pending_form_owners_with_data_entry_role_can_edit()
        {
            lock (CredentialNames.dataEntry)
            {
                LoginPage _loginPage = new LoginPage(page);
                FormsDashboardPage _formsDashboardPage = new FormsDashboardPage(page);
                
                _loginPage.LogIn(CredentialNames.dataEntry).GetAwaiter().GetResult();
                _formsDashboardPage.GoToFormsDashboardPage().GetAwaiter().GetResult();
                _formsDashboardPage.EnterStartDate("2050", "12", "31").GetAwaiter().GetResult();
                _formsDashboardPage.EnterEndDate("2050","12","31").GetAwaiter().GetResult();
                _formsDashboardPage.ClickPendingCard().GetAwaiter().GetResult();
                _formsDashboardPage.ClickModalSaveButton().GetAwaiter().GetResult();
                _formsDashboardPage.AssertSuccessAlertIsDisplayed().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task pending_form_non_owners_with_advanced_data_entry_role_can_edit()
        {
            lock (CredentialNames.advancedEntry)
            {
                LoginPage _loginPage = new LoginPage(page);
                FormsDashboardPage _formsDashboardPage = new FormsDashboardPage(page);

                _loginPage.LogIn(CredentialNames.advancedEntry).GetAwaiter().GetResult();
                _formsDashboardPage.GoToFormsDashboardPage().GetAwaiter().GetResult();
                _formsDashboardPage.EnterStartDate("2050", "12", "31").GetAwaiter().GetResult();
                _formsDashboardPage.EnterEndDate("2050", "12", "31").GetAwaiter().GetResult();
                _formsDashboardPage.ClickPendingCard().GetAwaiter().GetResult();
                _formsDashboardPage.ClickModalSaveButton().GetAwaiter().GetResult();
                _formsDashboardPage.AssertSuccessAlertIsDisplayed().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task pending_form_owners_without_data_entry_role_cannot_edit()
        {
            lock (CredentialNames.reporting)
            {
                LoginPage _loginPage = new LoginPage(page);
                FormsDashboardPage _formsDashboardPage = new FormsDashboardPage(page);

                _loginPage.LogIn(CredentialNames.reporting).GetAwaiter().GetResult();
                _formsDashboardPage.GoToFormsDashboardPage().GetAwaiter().GetResult();
                _formsDashboardPage.EnterStartDate("2075", "12", "31").GetAwaiter().GetResult();
                _formsDashboardPage.EnterEndDate("2075", "12", "31").GetAwaiter().GetResult();
                _formsDashboardPage.ClickPendingCard().GetAwaiter().GetResult();
                _formsDashboardPage.AssertThatEditFormModalIsNotDisplayed().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task pending_form_non_owners_with_data_entry_role_cannot_edit()
        {
            lock (CredentialNames.dataEntry)
            {
                LoginPage _loginPage = new LoginPage(page);
                FormsDashboardPage _formsDashboardPage = new FormsDashboardPage(page);

                _loginPage.LogIn(CredentialNames.dataEntry).GetAwaiter().GetResult();
                _formsDashboardPage.GoToFormsDashboardPage().GetAwaiter().GetResult();
                _formsDashboardPage.EnterStartDate("2075", "12", "31").GetAwaiter().GetResult();
                _formsDashboardPage.EnterEndDate("2075", "12", "31").GetAwaiter().GetResult();
                _formsDashboardPage.ClickPendingCard().GetAwaiter().GetResult();
                _formsDashboardPage.AssertThatEditFormModalIsNotDisplayed().GetAwaiter().GetResult();
            }
        }
    }
}
