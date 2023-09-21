using GembaCloud.PlaywrightTests.Data;
using GembaCloud.PlaywrightTests.Pages;
using GembaCloud.Web.Models.TenantViewModels;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    public class EmailLinkProcessFlows : BaseTests
    {
        private TenantDataAccess _tenantData;
        private ActionDataAccess _actionData;
        private Guid _tenantId;
        private TenantDetails _tenant;

        public EmailLinkProcessFlows()
        {
            _tenantData = new TenantDataAccess();
            _actionData = new ActionDataAccess();
            _tenantId = _tenantData.GetTenantId(TenantNames.allModules).Result;
            _tenant = _tenantData.GetTenantData(_tenantId).Result;
        }

        [Test]
        public async Task link_in_action_email_correctly_funtions_when_user_initially_logged_in()
        {
            LoginPage _loginPage = new LoginPage(page);
            Email _email = new Email(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                var action = _actionData.GetActionByTitle("Example Action", _tenantId).GetAwaiter().GetResult();
                _email.NavigateToActionFromEmail(action.ActionID).GetAwaiter().GetResult();
                _email.AssertNavigatedToCorrectAction(action.ActionID).GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task link_in_action_email_correctly_funtions_when_user_initially_logged_out()
        {
            LoginPage _loginPage = new LoginPage(page);
            Email _email = new Email(page);

            lock (CredentialNames.allRoles)
            {
                var action = _actionData.GetActionByTitle("Example Action", _tenantId).GetAwaiter().GetResult();
                _email.NavigateToActionFromEmail(action.ActionID).GetAwaiter().GetResult();
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _email.AssertNavigatedToCorrectAction(action.ActionID).GetAwaiter().GetResult();
            }
        }
    }
}