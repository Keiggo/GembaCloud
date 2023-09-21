using Microsoft.Extensions.Configuration;

namespace GembaCloud.PlaywrightTests.Data
{
    public class ConfigDataAccess
    {
        private string _secret = "381b09eab3c013d4ca54922bb802bec8fd5315192f0a75f201d8b3727425632fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        public IConfiguration GetData()
        {
            IConfiguration _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();
            return _configuration;
        }

        public async Task<string> GetCredentials(string credentialName)
        {
            return GetData().GetSection($"Credentials:{credentialName}").Value;
        }

        public async Task<string> GetUrl(string subdirectoryName = "")
        {
            string domain = GetData().GetSection($"Urls:HostUrl").Value;

            if (subdirectoryName != String.Empty)
            {
                string subdirectory = GetData().GetSection($"Urls:{subdirectoryName}").Value;

                return domain + subdirectory;
            }
            else
            {
                return domain;
            }
        }

        private async Task<DbConfig> GetDbConfig()
        {
            var dbConfig = new DbConfig();
            var config = GetData();
            dbConfig.ServerName = config.GetSection($"DbConfig:ServerName").Value;
            dbConfig.DatabaseName = config.GetSection($"DbConfig:DatabaseName").Value;
            dbConfig.Username = config.GetSection($"DbConfig:Username").Value;
            dbConfig.EncryptedPassword = config.GetSection($"DbConfig:EncryptedPassword").Value;

            return dbConfig;
        }

        public async Task<string> GetConnectionStringAsync()
        {
            var db = await GetDbConfig();
            return $"Server={db.ServerName};Database={db.DatabaseName};User ID={db.Username};Password={StringCipher.Decrypt(db.EncryptedPassword, _secret)}";
        }
    }
}
