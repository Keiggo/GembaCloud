using GembaCloud.PlaywrightTests.Data;
using GembaCloud.PlaywrightTests.Pages;
using GembaCloud.Web.Models.GuestModels;
using GembaCloud.Web.Models.HPLAViewModels;
using GembaCloud.Web.Models.MemberViewModels;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]//TODO: work out why these tests don't parallelise nicely. It seems to sometimes close the wrong tab in multi-tab situations
    public class UserManagementTests : BaseTests
    {
        private MemberDataAccess _memberDataAccess;
        private TenantDataAccess _tenantDataAccess;
        private GuestDataAccess _guestDataAccess;
        private HPLADataAccess _hplaDataAccess;
        private Guid _allModulesTenantId;
        private Guid _guestUserHomeTenantId;
        private IEnumerable<HPLA> _hplaGroups;

        public UserManagementTests()
        {
            _memberDataAccess = new MemberDataAccess();
            _tenantDataAccess = new TenantDataAccess();
            _allModulesTenantId = _tenantDataAccess.GetTenantId(TenantNames.allModules).Result;
            _guestDataAccess = new GuestDataAccess();
            _guestUserHomeTenantId = _tenantDataAccess.GetTenantId(TenantNames.guestUserHome).Result;
            _hplaDataAccess = new HPLADataAccess();
            _hplaGroups = _hplaDataAccess.GetHplaGroups(_allModulesTenantId);
        }

        [Test]
        public void new_users_can_be_created()
        {
            LoginPage _loginPage = new LoginPage(page);
            TenMinuteMail _tenMinuteMail = new TenMinuteMail(page);
            ConfigDataAccess _config = new ConfigDataAccess();
            
            var adminUserwindow = context.NewPageAsync().GetAwaiter().GetResult();
            var adminUserLoginPage = new LoginPage(adminUserwindow);
            var adminUserMemberManagementPage = new MemberManagementPage(adminUserwindow);

            string userEmailAddress;
            string userPassword = _config.GetCredentials(CredentialNames.correctPassword).GetAwaiter().GetResult();

            //get the email address for the session
            _tenMinuteMail.GoToTenMinuteMail().GetAwaiter().GetResult();
            userEmailAddress = _tenMinuteMail.GetEmailAddress().GetAwaiter().GetResult();

            lock (CredentialNames.accountAdministration)
            {
                //admin user creates the new user using the session email address
                adminUserLoginPage.GoToLoginPage().GetAwaiter().GetResult();
                adminUserLoginPage.LogIn(CredentialNames.accountAdministration).GetAwaiter().GetResult();
                adminUserMemberManagementPage.GoToMemberManagementPage().GetAwaiter().GetResult();
                adminUserMemberManagementPage.ClickAddMemberButton().GetAwaiter().GetResult();
                adminUserMemberManagementPage.EnterEmailAddress(userEmailAddress).GetAwaiter().GetResult();
                adminUserMemberManagementPage.EnterPassword(userPassword).GetAwaiter().GetResult();
                adminUserMemberManagementPage.EnterConfirmPassword(userPassword).GetAwaiter().GetResult();
                adminUserMemberManagementPage.EnterFirstName("E2E").GetAwaiter().GetResult();
                adminUserMemberManagementPage.EnterLastName("Test").GetAwaiter().GetResult();
                adminUserMemberManagementPage.ClickReportingCheckbox().GetAwaiter().GetResult();
                adminUserMemberManagementPage.ClickCreateMemberButton().GetAwaiter().GetResult();
            }

            //new user clicks the link in the email
            _tenMinuteMail.ClickGembaConfirmationEmailRow().GetAwaiter().GetResult();
            _tenMinuteMail.DismissPopupAdvert().GetAwaiter().GetResult();
            var newUserWindow = context.RunAndWaitForPageAsync(async () =>
            {
                _tenMinuteMail.ClickAccountConfirmationLink().GetAwaiter().GetResult();
            }).GetAwaiter().GetResult();

            newUserWindow.WaitForLoadStateAsync().GetAwaiter().GetResult();
            var newUserAccountConfirmationPage = new AccountConfirmationPage(newUserWindow);
            var newUserLoginPage = new LoginPage(newUserWindow);
            var newUserOeeDashboardPage = new OeeDashboardPage(newUserWindow);
            var newUserNavigationBar = new NavigationBar(newUserWindow);

            //new user logs in
            newUserAccountConfirmationPage.ClickProceedToLoginButton().GetAwaiter().GetResult();
            newUserLoginPage.LogInWithTemporaryCredentials(userEmailAddress, userPassword).GetAwaiter().GetResult();
            newUserOeeDashboardPage.AssertNavigatedToOeeDashboardPage().GetAwaiter().GetResult();

            //cleanup step to delete user
            Member _member = _memberDataAccess.GetMemberByUsername(userEmailAddress, _allModulesTenantId).Result;
            _memberDataAccess.DeleteMember(_member, CredentialNames.allRoles);
        }

        /*        [Test]
                public void existing_users_can_be_deleted()
                {
                    // needs a setup step here
                    // api/DB call to create a user, and "activate" them
                    string userForDeletion = page.CurrentWindowHandle;

                    //prove that existing user can log in
                    _loginPage.LogIn(CredentialNames.forDeletion).GetAwaiter().GetResult();
                    _manageYourUserProfile.AssertUserNavigatedToManageYourUserProfilePage().GetAwaiter().GetResult();
                    _navigationBar.LogOutOfCurrentUser().GetAwaiter().GetResult();

                    //in a new window, delete this user
                    page.SwitchTo().NewWindow(WindowType.Window);
                    _loginPage.WaitUntilCorrectNumberOfWindowsAreOpen(2);
                    string adminUser = page.CurrentWindowHandle;

                    _loginPage.GoToLoginPage();
                    _loginPage.LogInAsAccountAdministrationAndAdvancedConfiguration();
                    _memberManagementPage.GoToMemberManagementPage();
                    _memberManagementPage.SearchMembers(MasterUserNames.forDeletion);
                    _memberManagementPage.ClickDeleteUserButton(1);
                    _memberManagementPage.ClickDeleteModalDeleteButton();

                    //prove that deleted user can no longer log in
                    page.SwitchTo().Window(userForDeletion);
                    _loginPage.GoToLoginPage();
                    _loginPage.LogInAsForDeletion();
                    _loginPage.AssertLoginFailedFromInvalidCredentials();
                }*/

        /*        [Test]
                public void existing_user_can_have_privileges_updated()
                {
                    lock (CredentialNames.roleUpdate)
                    {
                        //prove that existing user has full access
                        _loginPage.LogIn(CredentialNames.roleUpdate).GetAwaiter().GetResult();
                        _loginPage.AssertUserCanAccessAllPages().GetAwaiter().GetResult();
                        _navigationBar.LogOutOfCurrentUser().GetAwaiter().GetResult();

                        //admin user revokes all of existing user's roles


                        //proves that existing user now has no access at all
                        _loginPage.LogIn(CredentialNames.roleUpdate).GetAwaiter().GetResult();
                        _loginPage.AssertUserCanAccessAllPages().GetAwaiter().GetResult();
                        _loginPage.AssertUserCantAccessPages(PageNames.GetAllPageNamesMinusAdminPagesAndLoginPage()).GetAwaiter().GetResult();

                        //needs a cleanup step here
                        //api/DB call to reset the existing user's roles
                    }*/

        [Test]
        public void new_guests_can_be_added_to_a_tenant()
        {
            LoginPage _loginPage = new LoginPage(page);
            NavigationBar _navigationBar = new NavigationBar(page);
            GuestsPage _guestsPage = new GuestsPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.temporaryGuest)
            {
                Guest temporaryGuest = _guestDataAccess.GetGuestByUsername(_config.GetCredentials(CredentialNames.temporaryGuest).GetAwaiter().GetResult(), _allModulesTenantId).GetAwaiter().GetResult();
                
                if (temporaryGuest != null)
                {
                    _guestDataAccess.DeleteGuest(temporaryGuest, _allModulesTenantId);
                }

                lock (CredentialNames.allRoles)
                {
                    _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                    _navigationBar.SwitchToTenant(TenantNames.allModules).GetAwaiter().GetResult();
                    _guestsPage.GoToGuestsPage().GetAwaiter().GetResult();
                    _guestsPage.ClickAddGuestButton().GetAwaiter().GetResult();
                    _guestsPage.SelectModalUserDropdown(CredentialNames.temporaryGuest).GetAwaiter().GetResult();
                    _guestsPage.ClickModalCreateButton().GetAwaiter().GetResult();
                    _navigationBar.LogOutOfCurrentUser().GetAwaiter().GetResult();
                }

                _loginPage.LogIn(CredentialNames.temporaryGuest).GetAwaiter().GetResult();
                _navigationBar.SwitchToTenant(TenantNames.allModules).GetAwaiter().GetResult();
                _navigationBar.AssertNavigatedToCorrectTenant(TenantNames.allModules).GetAwaiter().GetResult();
            }
        }

        [Test]
        public void guests_can_be_deleted_from_a_tenant()
        {
            LoginPage _loginPage = new LoginPage(page);
            NavigationBar _navigationBar = new NavigationBar(page);
            GuestsPage _guestsPage = new GuestsPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            var _memberAccountAdmin = _memberDataAccess.GetMemberByUsername(_config.GetCredentials(CredentialNames.accountAdministration).GetAwaiter().GetResult(), _allModulesTenantId).GetAwaiter().GetResult();
            var _memberTemporaryGuest = _memberDataAccess.GetMemberByUsername(_config.GetCredentials(CredentialNames.temporaryGuest).GetAwaiter().GetResult(), _guestUserHomeTenantId).GetAwaiter().GetResult();
            var _exampleHplaGroup1 = _hplaDataAccess.GetHplaGroupByDescription(_allModulesTenantId, HplaGroupNames.examplePlantLevelAccessGroup1);

            lock (CredentialNames.temporaryGuest)
            {
                Guest temporaryGuest = _guestDataAccess.GetGuestByUsername(_config.GetCredentials(CredentialNames.temporaryGuest).GetAwaiter().GetResult(), _allModulesTenantId).GetAwaiter().GetResult();
                
                if (temporaryGuest == null)
                {
                    temporaryGuest = new Guest()
                    {
                        UserId = _memberTemporaryGuest.UserID,
                        HPLAGroupId = _exampleHplaGroup1.HPLAGroupID,
                        ModifiedBy = _memberAccountAdmin.UserID
                    };

                    _guestDataAccess.AddGuest(temporaryGuest, _allModulesTenantId);
                }

                lock (CredentialNames.allRoles)
                {
                    _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                    _navigationBar.SwitchToTenant(TenantNames.allModules).GetAwaiter().GetResult();
                    _guestsPage.GoToGuestsPage().GetAwaiter().GetResult();
                    _guestsPage.SearchForGuest(_config.GetCredentials(CredentialNames.temporaryGuest).GetAwaiter().GetResult()).GetAwaiter().GetResult();
                    _guestsPage.ClickDeleteGuestButton().GetAwaiter().GetResult();
                    _guestsPage.ClickModalDeleteButton().GetAwaiter().GetResult();
                    _navigationBar.LogOutOfCurrentUser().GetAwaiter().GetResult();
                }

                _loginPage.LogIn(CredentialNames.temporaryGuest).GetAwaiter().GetResult();
                _navigationBar.AssertTenantIsNotInSwitcher(TenantNames.allModules).GetAwaiter().GetResult();
            }
        }

        [Test]
        public void guest_users_can_have_their_hpla_group_updated()
        {
            LoginPage _loginPage = new LoginPage(page);
            NavigationBar _navigationBar = new NavigationBar(page);
            GuestsPage _guestsPage = new GuestsPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            var _memberAccountAdmin = _memberDataAccess.GetMemberByUsername(_config.GetCredentials(CredentialNames.accountAdministration).GetAwaiter().GetResult(), _allModulesTenantId).GetAwaiter().GetResult();
            var _memberTemporaryGuest = _memberDataAccess.GetMemberByUsername(_config.GetCredentials(CredentialNames.temporaryGuest).GetAwaiter().GetResult(), _guestUserHomeTenantId).GetAwaiter().GetResult();
            var _exampleHplaGroup1 = _hplaDataAccess.GetHplaGroupByDescription(_allModulesTenantId, HplaGroupNames.examplePlantLevelAccessGroup1);

            lock (CredentialNames.temporaryGuest)
            {
                Guest temporaryGuest = _guestDataAccess.GetGuestByUsername(_config.GetCredentials(CredentialNames.temporaryGuest).GetAwaiter().GetResult(), _allModulesTenantId).GetAwaiter().GetResult();

                if (temporaryGuest == null)
                {
                    temporaryGuest = new Guest()
                    {
                        UserId = _memberTemporaryGuest.UserID,
                        HPLAGroupId = _exampleHplaGroup1.HPLAGroupID,
                        ModifiedBy = _memberAccountAdmin.UserID
                    };

                    _guestDataAccess.AddGuest(temporaryGuest, _allModulesTenantId);
                }

                temporaryGuest.HPLAGroupId = _exampleHplaGroup1.HPLAGroupID;
                _guestDataAccess.UpdateGuest(temporaryGuest, _allModulesTenantId);

                lock (CredentialNames.allRoles)
                {
                    _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                    _guestsPage.GoToGuestsPage().GetAwaiter().GetResult();
                    _guestsPage.SearchForGuest(_config.GetCredentials(CredentialNames.temporaryGuest).GetAwaiter().GetResult()).GetAwaiter().GetResult();
                    _guestsPage.ClickEditGuestButton().GetAwaiter().GetResult();
                    _guestsPage.SelectModalHplaDropdown(HplaGroupNames.examplePlantLevelAccessGroup2).GetAwaiter().GetResult();
                    _guestsPage.ClickModalSaveButton().GetAwaiter().GetResult();
                    _navigationBar.LogOutOfCurrentUser().GetAwaiter().GetResult();
                }

                _loginPage.LogIn(CredentialNames.temporaryGuest).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.ExpandAssetTreeBranch(TestEntityNames.branch003).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertAssetIsVisibleInTree(TestEntityNames.asset001).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertAssetIsVisibleInTree(TestEntityNames.asset002).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertAssetIsVisibleInTree(TestEntityNames.asset007).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertAssetIsVisibleInTree(TestEntityNames.asset008).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset003).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset004).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset005).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset006).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset009).GetAwaiter().GetResult();
            }
        }
    }
}