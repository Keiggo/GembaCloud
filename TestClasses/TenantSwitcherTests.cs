using GembaCloud.PlaywrightTests.Pages;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    public class TenantSwitcherTests : BaseTests
    {
        [Test]
        public async Task tenant_switcher_is_not_available_to_users_without_permission()
        {
            LoginPage _loginPage = new LoginPage(page);
            NavigationBar _navigationBar = new NavigationBar(page);

            lock (CredentialNames.accountAdministration)
            {
                _loginPage.LogIn(CredentialNames.accountAdministration).GetAwaiter().GetResult(); //this is an arbitrarily chosen user
                _navigationBar.AssertTenantSwitcherIsNotPresent().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task home_tenant_can_be_accessed_by_users_with_multiple_account_access()
        {
            LoginPage _loginPage = new LoginPage(page);
            NavigationBar _navigationBar = new NavigationBar(page);

            lock (CredentialNames.guestAccountAdministration)
            {
                _loginPage.LogIn(CredentialNames.guestAccountAdministration).GetAwaiter().GetResult(); //this is an arbitrarily chosen guest user
                _navigationBar.SwitchToTenant(TenantNames.guestUserHome).GetAwaiter().GetResult();
                _navigationBar.AssertNavigatedToCorrectTenant(TenantNames.guestUserHome).GetAwaiter().GetResult();

                //TODO: Need a better cleanup step than this. Something api related ideally
                _navigationBar.SwitchToTenant(TenantNames.allModules).GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task users_with_multiple_account_access_can_be_guests_in_other_tenants()
        {
            LoginPage _loginPage = new LoginPage(page);
            NavigationBar _navigationBar = new NavigationBar(page);

            lock (CredentialNames.guestAccountAdministration)
            {
                _loginPage.LogIn(CredentialNames.guestAccountAdministration).GetAwaiter().GetResult(); //this is an arbitrarily chosen guest user
                _navigationBar.SwitchToTenant(TenantNames.allModules).GetAwaiter().GetResult();
                _navigationBar.AssertNavigatedToCorrectTenant(TenantNames.allModules).GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task tenant_switcher_is_available_to_sys_admin_users()
        {
            LoginPage _loginPage = new LoginPage(page);
            NavigationBar _navigationBar = new NavigationBar(page);

            lock (CredentialNames.sysAdmin)
            {
                _loginPage.LogIn(CredentialNames.sysAdmin).GetAwaiter().GetResult();
                _navigationBar.AssertTenantSwitcherIsPresent().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.accountAdministrationAndAdvancedConfiguration)]
        [TestCase(CredentialNames.accountAdministrationAndAdvancedEntry)]
        [TestCase(CredentialNames.accountAdministrationAndAdvancedReporting)]
        [TestCase(CredentialNames.accountAdministrationAndBasicConfiguration)]
        [TestCase(CredentialNames.accountAdministrationAndDataEntry)]
        [TestCase(CredentialNames.accountAdministrationAndReporting)]
        [TestCase(CredentialNames.accountAdministrationAndRevenue)]
        public async Task add_guest_button_unavailble_to_users_without_sys_admin_role(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            GuestsPage _guestsPage = new GuestsPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _guestsPage.GoToGuestsPage().GetAwaiter().GetResult();
                _guestsPage.AssertAddGuestButtonIsNotPresent().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.accountAdministration)]
        [TestCase(CredentialNames.guestAccountAdministration)]
        public async Task multiple_account_access_role_cannot_be_assigned_by_account_admin_users_lacking_sys_admin_role(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            MemberManagementPage _memberManagementPage = new MemberManagementPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _memberManagementPage.GoToMemberManagementPage().GetAwaiter().GetResult();
                _memberManagementPage.ClickAddMemberButton().GetAwaiter().GetResult();
                _memberManagementPage.AssertMultipleAccountAccessCheckboxIsDisabled().GetAwaiter().GetResult();
            }
        }

        //TODO: reenable this test once api is available
/*        [Test]
        public async Task tenant_switcher_access_removed_when_multiple_account_access_role_is_revoked()
        {
            lock (CredentialNames.guestAccountAdministration)//this is an arbitrarily chosen guest user
            {
                _loginPage.LogIn(CredentialNames.guestAccountAdministration).GetAwaiter().GetResult();
                _navigationBar.AssertTenantSwitcherIsPresent().GetAwaiter().GetResult();
                _navigationBar.LogOutOfCurrentUser().GetAwaiter().GetResult();


                //TODO: all of the "all roles" user stuff to be replaced with api calls, when available
                lock (CredentialNames.allRoles)
                {
                    _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                    _navigationBar.SwitchToTenant(TenantNames.guestUserHome).GetAwaiter().GetResult();
                    _memberManagementPage.GoToMemberManagementPage().GetAwaiter().GetResult();
                    _memberManagementPage.SearchMembers(config.GetCredentials(CredentialNames.guestAccountAdministration).GetAwaiter().GetResult()).GetAwaiter().GetResult();
                    _memberManagementPage.ClickEditUserButton().GetAwaiter().GetResult();
                    _memberManagementPage.ClickMultipleAccountAccessCheckbox().GetAwaiter().GetResult();
                    _memberManagementPage.ClickSaveUserButton().GetAwaiter().GetResult();
                    _navigationBar.LogOutOfCurrentUser().GetAwaiter().GetResult();
                }

                _loginPage.LogIn(CredentialNames.guestAccountAdministration).GetAwaiter().GetResult();
                _navigationBar.AssertTenantSwitcherIsNotPresent().GetAwaiter().GetResult();
                _navigationBar.LogOutOfCurrentUser().GetAwaiter().GetResult();

                lock (CredentialNames.allRoles)
                {
                    _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                    _navigationBar.SwitchToTenant(TenantNames.guestUserHome).GetAwaiter().GetResult();
                    _memberManagementPage.GoToMemberManagementPage().GetAwaiter().GetResult();
                    _memberManagementPage.SearchMembers(config.GetCredentials(CredentialNames.guestAccountAdministration).GetAwaiter().GetResult()).GetAwaiter().GetResult();
                    _memberManagementPage.ClickEditUserButton().GetAwaiter().GetResult();
                    _memberManagementPage.ClickMultipleAccountAccessCheckbox().GetAwaiter().GetResult();
                    _memberManagementPage.ClickSaveUserButton().GetAwaiter().GetResult();
                }

                //TODO:need to replace this cleanup step with api
                _navigationBar.LogOutOfCurrentUser().GetAwaiter().GetResult();
                _loginPage.LogIn(CredentialNames.guestAccountAdministration).GetAwaiter().GetResult();
                _navigationBar.SwitchToTenant(TenantNames.allModules).GetAwaiter().GetResult();
            }
        }*/
    }
}
