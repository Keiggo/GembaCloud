namespace GembaCloud.PlaywrightTests.Helpers
{
     public static class StandardReportCategoryNames
    {
        public const string unscheduledDowntime = "Unscheduled Downtime";
        public const string oee = "OEE";
        public const string reject= "Reject";
        public const string productionEffectiveness= "Production Effectiveness";
        public const string production = "Production";
        public const string performanceLosses = "Performance Losses";
        public const string globalEfficiency = "Global Efficiency";
        public const string gembaIntelligence = "Gemba Intelligence";
        public const string temboOle = "Tembo OLE";
        public const string assetParameters = "Asset Parameters";
        public const string plantConnectionData = "Plant Connection Data";
        public const string processData = "Process Data";
        public const string meterData = "Meter Data";
        public const string scheduledDowntime = "Scheduled Downtime";

        public static List<string> GetAllCategories()
        {
            List<string> categories = new List<string>();

            categories.Add(unscheduledDowntime);
            categories.Add(oee);
            categories.Add(reject);
            categories.Add(productionEffectiveness);
            categories.Add(production);
            categories.Add(performanceLosses);
            categories.Add(globalEfficiency);
            categories.Add(gembaIntelligence);
            categories.Add(temboOle);
            categories.Add(assetParameters);
            categories.Add(plantConnectionData);
            categories.Add(processData);
            categories.Add(meterData);

            return categories;
        }

        public static List<string> GetCoreCategories()
        {
            //this lis is correctly empty at the moment
            List<string> categories = new List<string>();
            
            return categories;
        }

        public static List<string> GetOeeCategories()
        {
            List<string> categories = new List<string>();

            categories = GetCoreCategories();
            categories.Add(unscheduledDowntime);
            categories.Add(scheduledDowntime);
            categories.Add(oee);
            categories.Add(reject);
            categories.Add(productionEffectiveness);
            categories.Add(production);
            categories.Add(performanceLosses);
            categories.Add(globalEfficiency);
            categories.Add(temboOle);
            categories.Add(assetParameters);

            return categories;
        }

        public static List<string> GetActionManagementCategories()
        {
            List<string> categories = new List<string>();

            categories = GetCoreCategories();

            return categories;
        }

        public static List<string> GetConnectSystemsIntegrationCategories()
        {
            List<string> categories = new List<string>();

            categories = GetCoreCategories();

            return categories;
        }

        public static List<string> GetPlantConnectionCategories()
        {
            List<string> categories = new List<string>();

            categories = GetCoreCategories();
            categories.Add(plantConnectionData);
            categories.Add(processData);
            categories.Add(meterData);

            return categories;
        }

        public static List<string> GetRevenueCategories()
        {
            List<string> categories = new List<string>();

            categories = GetCoreCategories();

            return categories;
        }

        public static List<string> GetGembaIntelligenceCategories()
        {
            List<string> categories = new List<string>();

            categories = GetCoreCategories();
            categories.Add(gembaIntelligence);

            return categories;
        }

        public static List<string> GetRecipesCategories()
        {
            List<string> categories = new List<string>();

            categories = GetCoreCategories();

            return categories;
        }
    }
}