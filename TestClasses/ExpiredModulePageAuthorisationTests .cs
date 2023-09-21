using GembaCloud.PlaywrightTests.Data;
using GembaCloud.PlaywrightTests.Pages;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    public class ExpiredModulePageAuthorisationTests : BaseTests
    {
        string redirect = "Manage/Profile?redirect=True";

        [Test]
        public async Task access_to_action_search_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            ActionSearchPage _actionSearchPage = new ActionSearchPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _actionSearchPage.GoToActionSearchPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_action_dashboard_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            ActionDashboardPage _actionDashboardPage = new ActionDashboardPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _actionDashboardPage.GoToActionDashboardPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_knowledge_base_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            KnowledgeBasePage _knowledgeBasePage = new KnowledgeBasePage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _knowledgeBasePage.GoToKnowledgeBasePage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");            }
        }

        [Test]
        public async Task access_to_log_book_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            LogBookPage _logBookPage = new LogBookPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _logBookPage.GoToLogBookPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_gemba_intelligence_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            GembaIntelligencePage _gembaIntelligencePage = new GembaIntelligencePage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _gembaIntelligencePage.GoToGembaIntelligencePage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_shift_editor_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            ShiftEditorPage _shiftEditorPage = new ShiftEditorPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _shiftEditorPage.GoToShiftEditorPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_daily_production_review_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            DailyProductionReviewPage _dailyProductionReviewPage = new DailyProductionReviewPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _dailyProductionReviewPage.GoToDailyProductionReviewPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_map_overview_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            MapOverviewPage _mapOverviewPage = new MapOverviewPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _mapOverviewPage.GoToMapOverviewPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_oee_reporting_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeReportingPage _oeeReportingPage = new OeeReportingPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _oeeReportingPage.GoToOeeReportingPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_actions_status_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            ActionStatusPage _actionStatusPage = new ActionStatusPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _actionStatusPage.GoToActionStatusPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_log_book_categories_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            LogBookCategoriesPage _logBookCategoriesPage = new LogBookCategoriesPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _logBookCategoriesPage.GoToLogBookCategoriesPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_anomaly_categories_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            AnomalyCategoriesPage _anomalyCategoriesPage = new AnomalyCategoriesPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _anomalyCategoriesPage.GoToAnomalyCategoriesPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_revenue_dashboard_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            RevenueDashboardPage _revenueDashboardPage = new RevenueDashboardPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _revenueDashboardPage.GoToRevenueDashboardPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_team_dashboard_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            TeamDashboardPage _teamDashboardPage = new TeamDashboardPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _teamDashboardPage.GoToTeamDashboardPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_my_actions_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            MyActionsPage _myActionsPage = new MyActionsPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _myActionsPage.GoToMyActionsPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_action_categories_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            ActionCategoriesPage _actionCategoriesPage = new ActionCategoriesPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _actionCategoriesPage.GoToActionCategoriesPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_teams_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            TeamsPage _teamsPage = new TeamsPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _teamsPage.GoToTeamsPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_revenue_contracts_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            RevenueContractsPage _revenueContractsPage = new RevenueContractsPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _revenueContractsPage.GoToRevenueContractsPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_connect_systems_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            ConnectSystemsPage _connectSystemsPage = new ConnectSystemsPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _connectSystemsPage.GoToConnectSystemsPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_system_health_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            SystemHealthPage _systemHealthPage = new SystemHealthPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _systemHealthPage.GoToSystemHealthPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_tpi_export_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            TpiExportPage _tpiExportPage = new TpiExportPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _tpiExportPage.GoToTpiExportPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }

        [Test]
        public async Task access_to_mail_templates_page_restricted_if_module_is_expired()
        {
            LoginPage _loginPage = new LoginPage(page);
            MailTemplatesPage _mailTemplatesPage = new MailTemplatesPage(page);
            ConfigDataAccess _config = new ConfigDataAccess();

            lock (CredentialNames.allRolesExpiredModules)
            {
                _loginPage.LogIn(CredentialNames.allRolesExpiredModules).GetAwaiter().GetResult();
                _mailTemplatesPage.GoToMailTemplatesPage(true).GetAwaiter().GetResult();
                Assert.That(page.Url == $"{_config.GetUrl().GetAwaiter().GetResult()}{redirect}");
            }
        }
    }
}