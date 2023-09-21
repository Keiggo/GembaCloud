using GembaCloud.PlaywrightTests.Data;
using GembaCloud.Web.Models.TenantViewModels;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    [NonParallelizable]
    public class GuestUserTenantAccessTests : BaseTests
    {
        private TenantDataAccess _dataAccess;
        private Guid _tenantId;
        private TenantDetails _tenant;

        public GuestUserTenantAccessTests()
        {
            _dataAccess = new TenantDataAccess();
            _tenantId = _dataAccess.GetTenantId(TenantNames.allModules).Result;
            _tenant = _dataAccess.GetTenantData(_tenantId).Result;
        }

        [TearDown]
        public void AfterEach()
        {
            //this method isn't async because Nunit doesn't support async [TearDown] methods
            _tenant.Status = "Active";
            _tenant.StatusId = 10;
            _tenant.MaintMode = false;

            _dataAccess.UpdateTenant(_tenant, CredentialNames.allRoles);
        }
        //TODO: uncomment this when there's an api for refreshing the app cache as it won't work at the moment :(
/*        [Test]
        public async Task guest_users_can_switch_tenants_when_logged_into_inactive_tenant()
        {
            lock (CredentialNames.guestAccountAdministration)//guest user arbitrarily chosen
            {
                _loginPage.LogIn(CredentialNames.guestAccountAdministration).GetAwaiter().GetResult();
                _navigationBar.SwitchToTenant(TenantNames.allModules).GetAwaiter().GetResult();
                _navigationBar.LogOutOfCurrentUser().GetAwaiter().GetResult();

                _tenant.Status = "Inactive";
                _tenant.StatusId = 50;
                _dataAccess.UpdateTenant(_tenant, CredentialNames.allRoles).GetAwaiter().GetResult();

                _loginPage.LogIn(CredentialNames.guestAccountAdministration).GetAwaiter().GetResult();
                _inactiveTenantPage.AssertUrlIsCorrect();
                _inactiveTenantPage.AssertTenantSwitcherIsPresent().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task guest_users_can_switch_tenants_when_logged_into_tenant_in_maintenance_mode()
        {
            lock (CredentialNames.guestAccountAdministration)//guest user arbitrarily chosen
            {
                _loginPage.LogIn(CredentialNames.guestAccountAdministration).GetAwaiter().GetResult();
                _navigationBar.SwitchToTenant(TenantNames.allModules).GetAwaiter().GetResult();
                _navigationBar.LogOutOfCurrentUser().GetAwaiter().GetResult();

                _tenant.MaintMode = true;
                _dataAccess.UpdateTenant(_tenant, CredentialNames.allRoles);

                _loginPage.LogIn(CredentialNames.guestAccountAdministration).GetAwaiter().GetResult();
                _maintenanceModePage.AssertUrlIsCorrect();
                _maintenanceModePage.AssertTenantSwitcherIsPresent().GetAwaiter().GetResult();
            }
        }*/
    }
}