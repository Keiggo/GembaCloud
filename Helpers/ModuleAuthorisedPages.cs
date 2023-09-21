namespace GembaCloud.PlaywrightTests.Helpers
{
    public class ModuleAuthorisedPages
    {
        public string[] BaseAuthorisedPages =>
            new string[]
            {
                PageNames.manageYourUserProfile,
                PageNames.memberManagement,
                PageNames.guests,
                PageNames.plantLevelAccessGroup,
                PageNames.assetGroups,
                PageNames.workCentres,
                PageNames.assetTypes,
                PageNames.assets,
                PageNames.shifts,
                PageNames.eventCategories,
                PageNames.eventReasons,
                PageNames.countCategories,
                PageNames.countDefinitions,
                PageNames.performanceReason,
                PageNames.parts,
                PageNames.standardRates,
                PageNames.operators,
                PageNames.customers,
                PageNames.generalAccountSettings,
                PageNames.helpCentre,
                PageNames.dynamicReporting,
                PageNames.changeLog,
            };

        public string[] ActionManagementModuleAuthorisedPagesList =>
            new string[]
            {
                PageNames.actionStatus,
                PageNames.actionCategories,
                PageNames.teams,
                PageNames.actionDashboard,
                PageNames.actionSearch,
                PageNames.myActions,
                PageNames.teamDashboard,
                PageNames.mailTemplates,
            };
        
        public string[] ConnectSystemsIntegrationModuleAuthorisedPagesList =>
            new string[]
            {
                PageNames.connectSystems,
                PageNames.systemHealth,
                PageNames.tpiExport
            };

        public string[] GembaIntelligenceModuleAuthorisedPagesList =>
            new string[]
            {
                PageNames.anomalyCategories,
                PageNames.logBookCategories,
                PageNames.gembaIntelligence,
                PageNames.logBook,
                PageNames.knowledgeBase,
            };

        public string[] OeeModuleAuthorisedPagesList =>
            new string[]
            {
                PageNames.oeeReporting,
                PageNames.dynamicReporting,
                PageNames.dailyProductionReview,
                PageNames.shiftEditor,
                PageNames.mapOverview,
            };

        public string[] PlantConnectionModuleAuthorisedPagesList =>
            new string[]
            {

            };

        public string[] RecipesModuleAuthorisedPagesList =>
            new string[]
            {
                PageNames.recipeTemplateConfigurations,
                PageNames.recipeValues,
            };

        public string[] RevenueModuleAuthorisedPagesList =>
            new string[]
            {
                PageNames.revenueContracts,
                PageNames.revenueDashboard,
            };

        public string[] FormsModuleAuthorisedPagesList =>
            new string[]
            {
                PageNames.formsDashboard,
                PageNames.myForms,
                PageNames.formCategories,
                PageNames.formTemplates,
            };
    }
}