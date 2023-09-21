using GembaCloud.PlaywrightTests.Data;
using GembaCloud.PlaywrightTests.Pages;
using GembaCloud.Web.Models.TenantViewModels;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class OeeDashboardTests : BaseTests
    {
        private TenantDataAccess _tenantData;
        private ActionDataAccess _actionData;
        private Guid _tenantId;
        private TenantDetails _tenant;

        public OeeDashboardTests()
        {
            _tenantData = new TenantDataAccess();
            _actionData = new ActionDataAccess();
            _tenantId = _tenantData.GetTenantId(TenantNames.allModules).Result;
            _tenant = _tenantData.GetTenantData(_tenantId).Result;
        }
        [Test]
        public async Task oee_by_asset_chart_displays_data_correctly()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022","01","01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertOeeByAssetChartIsLoaded().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task oee_components_chart_displays_data_correctly()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertOeeComponentsChartIsLoaded().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task oee_trend_chart_displays_data_correctly()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.ScrollToBottomOfPage().GetAwaiter().GetResult();
                _oeeDashboardPage.AssertOeeTrendChartIsLoaded().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task availability_by_asset_chart_displays_data_correctly()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.ClickAvailButton().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertAvailabilityByAssetChartIsLoaded().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task reasons_chart_displays_data_correctly()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.ClickAvailButton().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertReasonsChartIsLoaded().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task availability_trend_chart_displays_data_correctly()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.ClickAvailButton().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.ScrollToBottomOfPage().GetAwaiter().GetResult();
                _oeeDashboardPage.AssertAvailabilityTrendChartIsLoaded().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task performance_by_asset_chart_displays_data_correctly()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.ClickPerfButton().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertPerformanceByAssetChartIsLoaded().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task product_performance_chart_displays_data_correctly()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.ClickPerfButton().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertProductPerformanceChartIsLoaded().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task product_performance_trend_chart_displays_data_correctly()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.ClickPerfButton().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.ScrollToBottomOfPage().GetAwaiter().GetResult();
                _oeeDashboardPage.AssertProductPerformanceTrendChartIsLoaded().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task quality_by_asset_chart_displays_data_correctly()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.ClickQualButton().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertQualityByAssetChartIsLoaded().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task product_quality_chart_displays_data_correctly()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.ClickQualButton().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.AssertProductQualityChartIsLoaded().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task quality_reason_trend_chart_displays_data_correctly()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.ClickQualButton().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.ScrollToBottomOfPage().GetAwaiter().GetResult();
                _oeeDashboardPage.AssertQualityReasonChartIsLoaded().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task quality_trend_chart_displays_data_correctly()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.ClickQualButton().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.ScrollToBottomOfPage().GetAwaiter().GetResult();
                _oeeDashboardPage.AssertQualityTrendChartIsLoaded().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task actions_can_be_created_on_oee_dashboard_page()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeDashboardPage _oeeDashboardPage = new OeeDashboardPage(page);
            ActionDashboardPage _actionDashboardPage = new ActionDashboardPage(page);

            lock (CredentialNames.allRoles)
            {
                _loginPage.LogIn(CredentialNames.allRoles).GetAwaiter().GetResult();
                _oeeDashboardPage.GoToOeeDashboardPage().GetAwaiter().GetResult();
                _oeeDashboardPage.ClickQualButton().GetAwaiter().GetResult();
                _oeeDashboardPage.SetStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _oeeDashboardPage.SetEndDate("2023", "08", "25").GetAwaiter().GetResult();
                _oeeDashboardPage.SelectAssetTreeAsset(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _oeeDashboardPage.ClickActionButton().GetAwaiter().GetResult();

                var actionTitle = _oeeDashboardPage.GetCurrentActionModalTitle().GetAwaiter().GetResult();

                _oeeDashboardPage.SelectActionModalCategoryDropdown("Process").GetAwaiter().GetResult();
                _oeeDashboardPage.ClickActionModalCreateButton().GetAwaiter().GetResult();
                _actionDashboardPage.GoToActionDashboardPage().GetAwaiter().GetResult();
                _actionDashboardPage.AssertActionCardIsPresent(actionTitle).GetAwaiter().GetResult();

                var action = _actionData.GetActionByTitle(actionTitle, _tenantId).GetAwaiter().GetResult();
                _actionData.DeleteGembaAction(action, _tenantId);
            }
        }
    }
}