using GembaCloud.PlaywrightTests.Data;
using GembaCloud.PlaywrightTests.Pages;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class TenantSwitcherProcessFlows : BaseTests
    {
        [Test]
        public async Task guest_users_can_be_added_as_team_members()
        {
            LoginPage _loginPage = new LoginPage(page);
            NavigationBar _navigationBar = new NavigationBar(page);
            SettingsIndex _settingsIndex = new SettingsIndex(page);
            TeamsPage _teamsPage = new TeamsPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();
            
            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _navigationBar.SwitchToTenant(TenantNames.allModules).GetAwaiter().GetResult();
                _navigationBar.ClickUserAvatar().GetAwaiter().GetResult();
                _navigationBar.ClickSettingsButton().GetAwaiter().GetResult();
                _settingsIndex.ClickTeamsLink().GetAwaiter().GetResult();
                _teamsPage.ClickEditTeamButton().GetAwaiter().GetResult();
                _teamsPage.ClickAddMemberButton().GetAwaiter().GetResult();
                _teamsPage.AssertTeamMemberIsAvailable(_config.GetCredentials(CredentialNames.guestAccountAdministration).GetAwaiter().GetResult()).GetAwaiter().GetResult();
            }
        }
    }
}
