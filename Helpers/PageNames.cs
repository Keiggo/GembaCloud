using System.Reflection;

namespace GembaCloud.PlaywrightTests.Helpers
{
     public static class PageNames
    {
        public const string oeeDashboard = "OeeDashboard";
        public const string login = "Login";
        public const string mapOverview = "MapOverview";
        public const string oeeReporting = "OeeReporting";
        public const string dynamicReporting = "DynamicReporting";
        public const string dailyProductionReview = "DailyProductionReview";
        public const string shiftEditor = "ShiftEditor";
        public const string gembaIntelligence = "GembaIntelligence";
        public const string logBook = "LogBook";
        public const string knowledgeBase = "KnowledgeBase";
        public const string actionDashboard = "ActionDashboard";
        public const string actionSearch = "ActionSearch";
        public const string myActions = "MyActions";
        public const string teamDashboard = "TeamDashboard";
        public const string revenueDashboard = "RevenueDashboard";
        public const string manageYourUserProfile = "ManageYourUserProfile";
        public const string memberManagement = "MemberManagement";
        public const string guests = "Guests";
        public const string plantLevelAccessGroup = "PlantLevelAccessGroup";
        public const string assetGroups = "AssetGroups";
        public const string workCentres = "WorkCentres";
        public const string assetTypes = "AssetTypes";
        public const string assets = "Assets";
        public const string shifts = "Shifts";
        public const string anomalyCategories = "AnomalyCategories";
        public const string logBookCategories = "LogBookCategories";
        public const string parts = "Parts";
        public const string standardRates = "StandardRates";
        public const string operators = "Operators";
        public const string customers = "Customers";
        public const string eventCategories = "EventCategories";
        public const string eventReasons = "EventReasons";
        public const string countCategories = "CountCategories";
        public const string countDefinitions = "CountDefinitions";
        public const string performanceReason = "PerformanceReason";
        public const string actionStatus = "ActionStatus";
        public const string actionCategories = "ActionCategories";
        public const string teams = "Teams";
        public const string revenueContracts = "RevenueContracts";
        public const string connectSystems = "ConnectSystems";
        public const string systemHealth = "SystemHealth";
        public const string tpiExport = "TPIExport";
        public const string generalAccountSettings = "GeneralAccountSettings";
        public const string mailTemplates = "MailTemplates";
        public const string manageTenants = "ManageTenants";
        public const string manageAdmin = "ManageAdmin";
        public const string helpCentre = "HelpCentre";
        public const string changeLog = "ChangeLog";
        public const string recipeTemplateConfigurations = "RecipeTemplateConfigurations";
        public const string recipeValues = "RecipeValues";
        public const string myForms = "MyForms";
        public const string formsDashboard = "FormsDashboard";
        public const string formCategories = "FormCategories";
        public const string formTemplates = "FormTemplates";

        public static List<string> GetAllPageNames()
        {
            List<FieldInfo> allStringNames = new List<FieldInfo>();
            List<string> allPageNames = new List<string>();
            System.Type masterPageNames = typeof(PageNames);

            allStringNames = masterPageNames.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi.IsLiteral && !fi.IsInitOnly).ToList();

            foreach(FieldInfo stringName in allStringNames)
            {
                allPageNames.Add(stringName.GetValue(null).ToString());
            }

            return allPageNames;
        }

        public static List<string> GetAllPageNamesMinusAdminPages()
        {
            List<string> pageNames = new List<string>();

            pageNames = GetAllPageNames();
            pageNames.RemoveRange(43, 3);

            return pageNames;
        }

        public static List<string> GetAllPageNamesMinusLoginPage()
        {
            List<string> pageNames = new List<string>();

            pageNames = GetAllPageNames();
            pageNames.Remove(login);

            return pageNames;
        }

        public static List<string> GetAllPageNamesMinusAdminPagesAndLoginPage()
        {
            List<string> pageNames = new List<string>();

            pageNames = GetAllPageNamesMinusAdminPages();
            pageNames.Remove(login);

            return pageNames;
        }

        private static List<string> GetBaseUserAuthorisedPagesList()
        {
            List<string> pages = new List<string>();

            pages.Add(manageYourUserProfile);
            pages.Add(helpCentre);
            pages.Add(changeLog);

            return pages;
        }

        public static List<string> GetSysAdminAuthorisedPagesList()
        {
            List<string> pages = new List<string>();

            pages.AddRange(GetBaseUserAuthorisedPagesList());
            pages.Add(manageTenants);
            pages.Add(manageAdmin);

            return pages;
        }

        public static List<string> GetAccountAdministrationAuthorisedPagesList()
        {
            List<string> pages = new List<string>();

            pages.AddRange(GetBaseUserAuthorisedPagesList());
            pages.Add(memberManagement);
            pages.Add(guests);
            pages.Add(plantLevelAccessGroup);
            pages.Add(teams);
            pages.Add(generalAccountSettings);
            pages.Add(mailTemplates);

            return pages;
        }

        public static List<string> GetAdvancedConfigurationAuthorisedPagesList()
        {
            List<string> pages = new List<string>();

            pages.AddRange(GetBaseUserAuthorisedPagesList());
            pages.AddRange(GetBasicConfigurationAuthorisedPagesList());
            pages.Add(tpiExport);

            return pages;
        }

        public static List<string> GetAdvancedEntryAuthorisedPagesList()
        {
            List<string> pages = new List<string>();

            pages.AddRange(GetBaseUserAuthorisedPagesList());
            pages.AddRange(GetDataEntryAuthorisedPagesList());

            return pages;
        }

        public static List<string> GetAdvancedReportingAuthorisedPagesList()
        {
            List<string> pages = new List<string>();

            pages.AddRange(GetBaseUserAuthorisedPagesList());
            pages.AddRange(GetReportingAuthorisedPagesList());

            return pages;
        }

        public static List<string> GetBasicConfigurationAuthorisedPagesList()
        {
            List<string> pages = new List<string>();

            pages.AddRange(GetBaseUserAuthorisedPagesList());
            pages.Add(assetGroups);
            pages.Add(workCentres);
            pages.Add(assetTypes);
            pages.Add(assets);
            pages.Add(shifts);
            pages.Add(anomalyCategories);
            pages.Add(eventReasons);
            pages.Add(countCategories);
            pages.Add(countDefinitions);
            pages.Add(performanceReason);
            pages.Add(parts);
            pages.Add(standardRates);
            pages.Add(operators);
            pages.Add(customers);
            pages.Add(eventCategories);
            pages.Add(actionStatus);
            pages.Add(actionCategories);
            pages.Add(connectSystems);
            pages.Add(recipeTemplateConfigurations);
            pages.Add(recipeValues);
            pages.Add(logBookCategories);
            pages.Add(systemHealth);
            pages.Add(formCategories);
            pages.Add(formTemplates);

            return pages;
        }

        public static List<string> GetDataEntryAuthorisedPagesList()
        {
            List<string> pages = new List<string>();

            pages.AddRange(GetBaseUserAuthorisedPagesList());
            pages.Add(shiftEditor);
            pages.Add(gembaIntelligence);
            pages.Add(logBook);
            pages.Add(knowledgeBase);
            pages.Add(formsDashboard);
            pages.Add(myForms);

            return pages;
        }

        public static List<string> GetReportingAuthorisedPagesList()
        {
            List<string> pages = new List<string>();

            pages.AddRange(GetBaseUserAuthorisedPagesList());
            pages.Add(oeeReporting);
            pages.Add(mapOverview);
            pages.Add(dynamicReporting);
            pages.Add(dailyProductionReview);
            pages.Add(shiftEditor);
            pages.Add(gembaIntelligence);
            pages.Add(logBook);
            pages.Add(knowledgeBase);
            pages.Add(actionDashboard);
            pages.Add(actionSearch);
            pages.Add(myActions);
            pages.Add(teamDashboard);
            pages.Add(formsDashboard);
            pages.Add(myForms);
            pages.Add(oeeDashboard);

            return pages;
        }

        public static List<string> GetRevenueAuthorisedPagesList()
        {
            List<string> pages = new List<string>();

            pages.AddRange(GetBaseUserAuthorisedPagesList());
            pages.Add(revenueDashboard);
            pages.Add(revenueContracts);

            return pages;
        }

        public static List<string> GetLoggedOutAuthorisedPagesList()
        {
            //this is correct, the list should be empty
            List<string> pages = new List<string>();

            return pages;
        }
    }
}