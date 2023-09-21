using GembaCloud.PlaywrightTests.Pages;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    public class ModulePageAuthorisationTests : BaseTests
    {
        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_changelog_page_restricted_by_module(string user)
        {
            //TODO: these locks on every test are to prevent tests from logging in as the same user. This is another approach we could consider https://stackoverflow.com/a/45769160
            LoginPage _loginPage = new LoginPage(page);
            ChangeLogPage _changeLogPage = new ChangeLogPage(page);
            
            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _changeLogPage.GoToChangeLogPage(true).GetAwaiter().GetResult();
                _changeLogPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.changeLog, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_help_centre_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            HelpCentrePage _helpCentrePage = new HelpCentrePage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _helpCentrePage.GoToHelpCentrePage(true).GetAwaiter().GetResult();
                _helpCentrePage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.helpCentre, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_action_search_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ActionSearchPage _actionSearchPage = new ActionSearchPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _actionSearchPage.GoToActionSearchPage(true).GetAwaiter().GetResult();
                _actionSearchPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.actionSearch, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_action_dashboard_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ActionDashboardPage _actionDashboardPage = new ActionDashboardPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _actionDashboardPage.GoToActionDashboardPage(true).GetAwaiter().GetResult();
                _actionDashboardPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.actionDashboard, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_knowledge_base_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            KnowledgeBasePage _knowledgeBasePage = new KnowledgeBasePage(page);
            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _knowledgeBasePage.GoToKnowledgeBasePage(true).GetAwaiter().GetResult();
                _knowledgeBasePage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.knowledgeBase, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_log_book_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            LogBookPage _logBookPage = new LogBookPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _logBookPage.GoToLogBookPage(true).GetAwaiter().GetResult();
                _logBookPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.logBook, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_gemba_intelligence_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            GembaIntelligencePage _gembaIntelligencePage = new GembaIntelligencePage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _gembaIntelligencePage.GoToGembaIntelligencePage(true).GetAwaiter().GetResult();
                _gembaIntelligencePage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.gembaIntelligence, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_shift_editor_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ShiftEditorPage _shiftEditorPage = new ShiftEditorPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _shiftEditorPage.GoToShiftEditorPage(true).GetAwaiter().GetResult();
                _shiftEditorPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.shiftEditor, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_daily_production_review_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            DailyProductionReviewPage _dailyProductionReviewPage = new DailyProductionReviewPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _dailyProductionReviewPage.GoToDailyProductionReviewPage(true).GetAwaiter().GetResult();
                _dailyProductionReviewPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.dailyProductionReview, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_dynamic_reporting_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            DynamicReportingPage _dynamicReportingPage = new DynamicReportingPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _dynamicReportingPage.GoToDynamicReportingPage(true).GetAwaiter().GetResult();
                _dynamicReportingPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.dynamicReporting, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_oee_reporting_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            OeeReportingPage _oeeReportingPage = new OeeReportingPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _oeeReportingPage.GoToOeeReportingPage(true).GetAwaiter().GetResult();
                _oeeReportingPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.oeeReporting, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_map_overview_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            MapOverviewPage _mapOverviewPage = new MapOverviewPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _mapOverviewPage.GoToMapOverviewPage(true).GetAwaiter().GetResult();
                _mapOverviewPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.mapOverview, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_actions_status_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ActionStatusPage _actionStatusPage = new ActionStatusPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _actionStatusPage.GoToActionStatusPage(true).GetAwaiter().GetResult();
                _actionStatusPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.actionStatus, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_performance_reason_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            PerformanceReasonPage _performanceReasonPage = new PerformanceReasonPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _performanceReasonPage.GoToPerformanceReasonPage(true).GetAwaiter().GetResult();
                _performanceReasonPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.performanceReason, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_count_definitions_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            CountDefinitionsPage _countDefinitionsPage = new CountDefinitionsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _countDefinitionsPage.GoToCountDefinitionsPage(true).GetAwaiter().GetResult();
                _countDefinitionsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.countDefinitions, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_count_categories_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            CountCategoriesPage _countCategoriesPage = new CountCategoriesPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _countCategoriesPage.GoToCountCategoriesPage(true).GetAwaiter().GetResult();
                _countCategoriesPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.countCategories, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_event_reasons_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            EventReasonsPage _eventReasonsPage = new EventReasonsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _eventReasonsPage.GoToEventReasonsPage(true).GetAwaiter().GetResult();
                _eventReasonsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.eventReasons, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_event_categories_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            EventCategoriesPage _eventCategoriesPage = new EventCategoriesPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _eventCategoriesPage.GoToEventCategoriesPage(true).GetAwaiter().GetResult();
                _eventCategoriesPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.eventCategories, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_customers_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            CustomersPage _customersPage = new CustomersPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _customersPage.GoToCustomersPage(true).GetAwaiter().GetResult();
                _customersPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.customers, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_operators_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            OperatorsPage _operatorsPage = new OperatorsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _operatorsPage.GoToOperatorsPage(true).GetAwaiter().GetResult();
                _operatorsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.operators, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_standard_rates_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            StandardRatesPage _standardRatesPage = new StandardRatesPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _standardRatesPage.GoToStandardRatesPage(true).GetAwaiter().GetResult();
                _standardRatesPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.standardRates, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_parts_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            PartsPage _partsPage = new PartsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _partsPage.GoToPartsPage(true).GetAwaiter().GetResult();
                _partsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.parts, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_log_book_categories_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            LogBookCategoriesPage _logBookCategoriesPage = new LogBookCategoriesPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _logBookCategoriesPage.GoToLogBookCategoriesPage(true).GetAwaiter().GetResult();
                _logBookCategoriesPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.logBookCategories, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_anomaly_categories_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            AnomalyCategoriesPage _anomalyCategoriesPage = new AnomalyCategoriesPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _anomalyCategoriesPage.GoToAnomalyCategoriesPage(true).GetAwaiter().GetResult();
                _anomalyCategoriesPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.anomalyCategories, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_shifts_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ShiftsPage _shiftsPage = new ShiftsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _shiftsPage.GoToShiftsPage(true).GetAwaiter().GetResult();
                _shiftsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.shifts, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_assets_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            AssetsPage _assetsPage = new AssetsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _assetsPage.GoToAssetsPage(true).GetAwaiter().GetResult();
                _assetsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.assets, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_asset_types_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            AssetTypesPage _assetTypesPage = new AssetTypesPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _assetTypesPage.GoToAssetTypesPage(true).GetAwaiter().GetResult();
                _assetTypesPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.assetTypes, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_work_centres_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            WorkCentresPage _workCentresPage = new WorkCentresPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _workCentresPage.GoToWorkCentresPage(true).GetAwaiter().GetResult();
                _workCentresPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.workCentres, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_asset_groups_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            AssetGroupsPage _assetGroupsPage = new AssetGroupsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _assetGroupsPage.GoToAssetGroupsPage(true).GetAwaiter().GetResult();
                _assetGroupsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.assetGroups, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_plant_level_access_group_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            PlantLevelAccessGroupPage _plantLevelAccessGroupPage = new PlantLevelAccessGroupPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _plantLevelAccessGroupPage.GoToPlantLevelAccessGroupPage(true).GetAwaiter().GetResult();
                _plantLevelAccessGroupPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.plantLevelAccessGroup, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_member_management_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            MemberManagementPage _memberManagementPage = new MemberManagementPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _memberManagementPage.GoToMemberManagementPage(true).GetAwaiter().GetResult();
                _memberManagementPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.memberManagement, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_guest_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            GuestsPage _guestsPage = new GuestsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _guestsPage.GoToGuestsPage(true).GetAwaiter().GetResult();
                _guestsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.guests, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_manage_your_user_profile_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ManageYourUserProfilePage _manageYourUserProfilePage = new ManageYourUserProfilePage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _manageYourUserProfilePage.GoToManageYourUserProfilePage(true).GetAwaiter().GetResult();
                _manageYourUserProfilePage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.manageYourUserProfile, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_revenue_dashboard_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            RevenueDashboardPage _revenueDashboardPage = new RevenueDashboardPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _revenueDashboardPage.GoToRevenueDashboardPage(true).GetAwaiter().GetResult();
                _revenueDashboardPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.revenueDashboard, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_team_dashboard_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            TeamDashboardPage _teamDashboardPage = new TeamDashboardPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _teamDashboardPage.GoToTeamDashboardPage(true).GetAwaiter().GetResult();
                _teamDashboardPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.teamDashboard, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_my_actions_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            MyActionsPage _myActionsPage = new MyActionsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _myActionsPage.GoToMyActionsPage(true).GetAwaiter().GetResult();
                _myActionsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.myActions, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_action_categories_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ActionCategoriesPage _actionCategoriesPage = new ActionCategoriesPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _actionCategoriesPage.GoToActionCategoriesPage(true).GetAwaiter().GetResult();
                _actionCategoriesPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.actionCategories, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_teams_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            TeamsPage _teamsPage = new TeamsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _teamsPage.GoToTeamsPage(true).GetAwaiter().GetResult();
                _teamsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.teams, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_revenue_contracts_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            RevenueContractsPage _revenueContractsPage = new RevenueContractsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _revenueContractsPage.GoToRevenueContractsPage(true).GetAwaiter().GetResult();
                _revenueContractsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.revenueContracts, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_connect_systems_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ConnectSystemsPage _connectSystemsPage = new ConnectSystemsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _connectSystemsPage.GoToConnectSystemsPage(true).GetAwaiter().GetResult();
                _connectSystemsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.connectSystems, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_system_health_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            SystemHealthPage _systemHealthPage = new SystemHealthPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _systemHealthPage.GoToSystemHealthPage(true).GetAwaiter().GetResult();
                _systemHealthPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.systemHealth, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_tpi_export_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            TpiExportPage _tpiExportPage = new TpiExportPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _tpiExportPage.GoToTpiExportPage(true).GetAwaiter().GetResult();
                _tpiExportPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.tpiExport, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_general_account_settings_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            GeneralAccountSettingsPage _generalAccountSettingsPage = new GeneralAccountSettingsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _generalAccountSettingsPage.GoToGeneralAccountSettingsPage(true).GetAwaiter().GetResult();
                _generalAccountSettingsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.generalAccountSettings, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_mail_templates_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            MailTemplatesPage _mailTemplatesPage = new MailTemplatesPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _mailTemplatesPage.GoToMailTemplatesPage(true).GetAwaiter().GetResult();
                _mailTemplatesPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.mailTemplates, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_manage_tenants_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ManageTenantsPage _manageTenantsPage = new ManageTenantsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _manageTenantsPage.GoToManageTenantsPage(true).GetAwaiter().GetResult();
                _manageTenantsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.manageTenants, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_manage_admin_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ManageAdminPage _manageAdminPage = new ManageAdminPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _manageAdminPage.GoToManageAdminPage(true).GetAwaiter().GetResult();
                _manageAdminPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.manageAdmin, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_my_forms_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            MyFormsPage _myFormsPage = new MyFormsPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _myFormsPage.GoToMyFormsPage(true).GetAwaiter().GetResult();
                _myFormsPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.myForms, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_forms_dashboard_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            FormsDashboardPage _formsDashboardPage = new FormsDashboardPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _formsDashboardPage.GoToFormsDashboardPage(true).GetAwaiter().GetResult();
                _formsDashboardPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.formsDashboard, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_form_categories_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            FormCategoriesPage _formCategoriesPage = new FormCategoriesPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _formCategoriesPage.GoToFormCategoriesPage(true).GetAwaiter().GetResult();
                _formCategoriesPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.formCategories, user).GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        [TestCase(CredentialNames.plantConnectionModuleOnly)]
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        [TestCase(CredentialNames.formsModuleOnly)]
        public async Task access_to_form_templates_page_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            FormTemplatesPage _formTemplatesPage = new FormTemplatesPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _formTemplatesPage.GoToFormTemplatesPage(true).GetAwaiter().GetResult();
                _formTemplatesPage.AssertModuleAuthorisationLevelIsCorrectForPage(PageNames.formTemplates, user).GetAwaiter().GetResult();
            }
        }
    }
}