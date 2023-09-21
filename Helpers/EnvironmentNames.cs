using System.IO;
using Microsoft.Extensions.Configuration;

namespace GembaCloud.PlaywrightTests.Helpers
{
    public static class EnvironmentNames
    {
        public const string develop = "Develop";
        public const string bugFix = "BugFix";
        public const string multiTenantUsers = "MultiTenantUsers";
        public const string liveData = "LiveData";
        public const string forms = "Forms";

        public static string GetCurrentEnvironmentName()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

            switch(configuration.GetSection($"Urls:Host").Value)
            {
                case "http://10.18.0.110:654/":
                    return develop;
                
                case "http://10.18.0.110:657/":
                    return bugFix;

                case "http://10.18.0.110:656/":
                    return multiTenantUsers;

                case "http://10.18.0.110:658/":
                    return liveData;

                case "http://10.18.0.110:670/":
                    return forms;

                default:
                    return configuration.GetSection($"Urls:Host").Value;
            }
        }
    }
}