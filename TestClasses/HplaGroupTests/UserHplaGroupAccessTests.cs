using GembaCloud.PlaywrightTests.Data;
using GembaCloud.PlaywrightTests.Pages;
using GembaCloud.Web.Models.GuestModels;
using GembaCloud.Web.Models.MemberViewModels;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class UserHplaGroupAccessTests : BaseTests
    {
        private IPage _page;
        private MemberDataAccess _memberDataAccess;
        private GuestDataAccess _guestDataAccess;
        private TenantDataAccess _tenantDataAccess;
        private Member _member;
        private Guest _guest;
        private Guid _tenantId;
        private ConfigDataAccess _config => new ConfigDataAccess();

        public UserHplaGroupAccessTests()
         {
            _memberDataAccess = new MemberDataAccess();
            _guestDataAccess = new GuestDataAccess();
            _tenantDataAccess = new TenantDataAccess();

            _page = page;
            _tenantId = _tenantDataAccess.GetTenantId(TenantNames.allModules).Result;
            _member = _memberDataAccess.GetMemberByUsername(_config.GetCredentials(CredentialNames.plantLevelAccessGroups).Result, _tenantId).Result;
            _guest = _guestDataAccess.GetGuestByUsername(_config.GetCredentials(CredentialNames.guestPlantLevelAccessGroups).Result, _tenantId).Result;
        }

        [SetUp]
        public void SetPlantLevelAccessGroupUserToGroup2()
        {
            _member.HPLAGroupID = 52;
            _memberDataAccess.UpdateMember(_member, _config.GetCredentials(CredentialNames.allRoles).Result);

            _guest.HPLAGroupId = 52;
            _guestDataAccess.UpdateGuest(_guest, _tenantId);
        }

        [TestCase(CredentialNames.plantLevelAccessGroups)]
        [TestCase(CredentialNames.guestPlantLevelAccessGroups)]
        public async Task users_can_only_access_entities_within_their_hpla_group_on_oee_dashboard(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
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

        [TestCase(CredentialNames.plantLevelAccessGroups)]
        [TestCase(CredentialNames.guestPlantLevelAccessGroups)]
        public async Task users_can_only_access_entities_within_their_hpla_group_on_map_overview_page(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            MapOverviewPage _mapOverviewPage = new MapOverviewPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _mapOverviewPage.GoToMapOverviewPage().GetAwaiter().GetResult();
                _mapOverviewPage.ExpandAssetTreeBranch(TestEntityNames.branch003).GetAwaiter().GetResult();
                _mapOverviewPage.AssertAssetIsVisibleInTree(TestEntityNames.asset001).GetAwaiter().GetResult();
                _mapOverviewPage.AssertAssetIsVisibleInTree(TestEntityNames.asset002).GetAwaiter().GetResult();
                _mapOverviewPage.AssertAssetIsVisibleInTree(TestEntityNames.asset007).GetAwaiter().GetResult();
                _mapOverviewPage.AssertAssetIsVisibleInTree(TestEntityNames.asset008).GetAwaiter().GetResult();
                _mapOverviewPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset003).GetAwaiter().GetResult();
                _mapOverviewPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset004).GetAwaiter().GetResult();
                _mapOverviewPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset005).GetAwaiter().GetResult();
                _mapOverviewPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset006).GetAwaiter().GetResult();
                _mapOverviewPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset009).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.plantLevelAccessGroups)]
        [TestCase(CredentialNames.guestPlantLevelAccessGroups)]
        public async Task users_can_only_access_entities_within_their_hpla_group_on_oee_reporting_page(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeReportingPage _oeeReportingPage = new OeeReportingPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _oeeReportingPage.GoToOeeReportingPage().GetAwaiter().GetResult();
                _oeeReportingPage.ExpandAssetTreeBranch(TestEntityNames.branch003).GetAwaiter().GetResult();
                _oeeReportingPage.AssertAssetIsVisibleInTree(TestEntityNames.asset001).GetAwaiter().GetResult();
                _oeeReportingPage.AssertAssetIsVisibleInTree(TestEntityNames.asset002).GetAwaiter().GetResult();
                _oeeReportingPage.AssertAssetIsVisibleInTree(TestEntityNames.asset007).GetAwaiter().GetResult();
                _oeeReportingPage.AssertAssetIsVisibleInTree(TestEntityNames.asset008).GetAwaiter().GetResult();
                _oeeReportingPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset003).GetAwaiter().GetResult();
                _oeeReportingPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset004).GetAwaiter().GetResult();
                _oeeReportingPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset005).GetAwaiter().GetResult();
                _oeeReportingPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset006).GetAwaiter().GetResult();
                _oeeReportingPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset009).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.plantLevelAccessGroups)]
        [TestCase(CredentialNames.guestPlantLevelAccessGroups)]
        public async Task users_can_only_access_entities_within_their_hpla_group_on_daily_production_review_page(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            DailyProductionReviewPage _dailyProductionReviewPage = new DailyProductionReviewPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _dailyProductionReviewPage.GoToDailyProductionReviewPage().GetAwaiter().GetResult();
                _dailyProductionReviewPage.ExpandAssetTreeBranch(TestEntityNames.branch003).GetAwaiter().GetResult();
                _dailyProductionReviewPage.AssertAssetIsVisibleInTree(TestEntityNames.asset001).GetAwaiter().GetResult();
                _dailyProductionReviewPage.AssertAssetIsVisibleInTree(TestEntityNames.asset002).GetAwaiter().GetResult();
                _dailyProductionReviewPage.AssertAssetIsVisibleInTree(TestEntityNames.asset007).GetAwaiter().GetResult();
                _dailyProductionReviewPage.AssertAssetIsVisibleInTree(TestEntityNames.asset008).GetAwaiter().GetResult();
                _dailyProductionReviewPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset003).GetAwaiter().GetResult();
                _dailyProductionReviewPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset004).GetAwaiter().GetResult();
                _dailyProductionReviewPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset005).GetAwaiter().GetResult();
                _dailyProductionReviewPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset006).GetAwaiter().GetResult();
                _dailyProductionReviewPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset009).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.plantLevelAccessGroups)]
        [TestCase(CredentialNames.guestPlantLevelAccessGroups)]
        public async Task users_can_only_access_entities_within_their_hpla_group_on_shift_editor_page(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            ShiftEditorPage _shiftEditorPage = new ShiftEditorPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _shiftEditorPage.GoToShiftEditorPage().GetAwaiter().GetResult();
                _shiftEditorPage.SetShiftDate("2022", "01", "01").GetAwaiter().GetResult();
                _shiftEditorPage.SelectShiftDropDownOptionByText("Example Shift").GetAwaiter().GetResult();
                _shiftEditorPage.ClickAssetEllipsisButton().GetAwaiter().GetResult();
                _shiftEditorPage.ExpandAssetTreeBranch(TestEntityNames.branch003).GetAwaiter().GetResult();
                _shiftEditorPage.AssertAssetIsVisibleInTree(TestEntityNames.asset001).GetAwaiter().GetResult();
                _shiftEditorPage.AssertAssetIsVisibleInTree(TestEntityNames.asset002).GetAwaiter().GetResult();
                _shiftEditorPage.AssertAssetIsVisibleInTree(TestEntityNames.asset007).GetAwaiter().GetResult();
                _shiftEditorPage.AssertAssetIsVisibleInTree(TestEntityNames.asset008).GetAwaiter().GetResult();
                _shiftEditorPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset003).GetAwaiter().GetResult();
                _shiftEditorPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset004).GetAwaiter().GetResult();
                _shiftEditorPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset005).GetAwaiter().GetResult();
                _shiftEditorPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset006).GetAwaiter().GetResult();
                _shiftEditorPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset009).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.plantLevelAccessGroups)]
        [TestCase(CredentialNames.guestPlantLevelAccessGroups)]
        public async Task users_can_only_access_entities_within_their_hpla_group_on_gemba_intelligence_page(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            GembaIntelligencePage _gembaIntelligencePage = new GembaIntelligencePage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _gembaIntelligencePage.GoToGembaIntelligencePage().GetAwaiter().GetResult();
                _gembaIntelligencePage.ExpandAssetTreeBranch(TestEntityNames.branch003).GetAwaiter().GetResult();
                _gembaIntelligencePage.AssertAssetIsVisibleInTree(TestEntityNames.asset001).GetAwaiter().GetResult();
                _gembaIntelligencePage.AssertAssetIsVisibleInTree(TestEntityNames.asset002).GetAwaiter().GetResult();
                _gembaIntelligencePage.AssertAssetIsVisibleInTree(TestEntityNames.asset007).GetAwaiter().GetResult();
                _gembaIntelligencePage.AssertAssetIsVisibleInTree(TestEntityNames.asset008).GetAwaiter().GetResult();
                _gembaIntelligencePage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset003).GetAwaiter().GetResult();
                _gembaIntelligencePage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset004).GetAwaiter().GetResult();
                _gembaIntelligencePage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset005).GetAwaiter().GetResult();
                _gembaIntelligencePage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset006).GetAwaiter().GetResult();
                _gembaIntelligencePage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset009).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.plantLevelAccessGroups)]
        [TestCase(CredentialNames.guestPlantLevelAccessGroups)]
        public async Task users_can_only_access_entities_within_their_hpla_group_on_log_book_page(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            LogBookPage _logBookPage = new LogBookPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _logBookPage.GoToLogBookPage().GetAwaiter().GetResult();
                _logBookPage.ExpandAssetTreeBranch(TestEntityNames.branch003).GetAwaiter().GetResult();
                _logBookPage.AssertAssetIsVisibleInTree(TestEntityNames.asset001).GetAwaiter().GetResult();
                _logBookPage.AssertAssetIsVisibleInTree(TestEntityNames.asset002).GetAwaiter().GetResult();
                _logBookPage.AssertAssetIsVisibleInTree(TestEntityNames.asset007).GetAwaiter().GetResult();
                _logBookPage.AssertAssetIsVisibleInTree(TestEntityNames.asset008).GetAwaiter().GetResult();
                _logBookPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset003).GetAwaiter().GetResult();
                _logBookPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset004).GetAwaiter().GetResult();
                _logBookPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset005).GetAwaiter().GetResult();
                _logBookPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset006).GetAwaiter().GetResult();
                _logBookPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset009).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.plantLevelAccessGroups)]
        [TestCase(CredentialNames.guestPlantLevelAccessGroups)]
        public async Task users_can_only_access_entities_within_their_hpla_group_on_dynamic_reporting_page(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            DynamicReportingPage _dynamicReportingPage = new DynamicReportingPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _dynamicReportingPage.GoToDynamicReportingPage().GetAwaiter().GetResult();
                _dynamicReportingPage.ClickCustomReportModalTab().GetAwaiter().GetResult();
                _dynamicReportingPage.ClickAssetsRowHeaderModal().GetAwaiter().GetResult();
                _dynamicReportingPage.ExpandAssetTreeBranch(TestEntityNames.branch003).GetAwaiter().GetResult();
                _dynamicReportingPage.AssertAssetIsVisibleInTree(TestEntityNames.asset001).GetAwaiter().GetResult();
                _dynamicReportingPage.AssertAssetIsVisibleInTree(TestEntityNames.asset002).GetAwaiter().GetResult();
                _dynamicReportingPage.AssertAssetIsVisibleInTree(TestEntityNames.asset007).GetAwaiter().GetResult();
                _dynamicReportingPage.AssertAssetIsVisibleInTree(TestEntityNames.asset008).GetAwaiter().GetResult();
                _dynamicReportingPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset003).GetAwaiter().GetResult();
                _dynamicReportingPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset004).GetAwaiter().GetResult();
                _dynamicReportingPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset005).GetAwaiter().GetResult();
                _dynamicReportingPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset006).GetAwaiter().GetResult();
                _dynamicReportingPage.AssertAssetIsNotVisibleInTree(TestEntityNames.asset009).GetAwaiter().GetResult();
            }
        }
    }
}