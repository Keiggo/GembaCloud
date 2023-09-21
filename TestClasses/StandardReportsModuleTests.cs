using GembaCloud.PlaywrightTests.Pages;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    public class StandardReportsModuleTests : BaseTests
    {
        [TestCase(CredentialNames.actionManagementModuleOnly)]
        [TestCase(CredentialNames.gembaIntelligenceModuleOnly)]
        [TestCase(CredentialNames.oeeModuleOnly)]
        /*[TestCase(CredentialNames.plantConnectionModuleOnly)]*/ //TODO: commented out until the Live Data stuff is merged
        [TestCase(CredentialNames.connectSystemsIntegrationModuleOnly)]
        [TestCase(CredentialNames.recipesModuleOnly)]
        [TestCase(CredentialNames.revenueModuleOnly)]
        public async Task access_to_custom_report_categories_restricted_by_module(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            DynamicReportingPage _dynamicReportingPage = new DynamicReportingPage(page);
            
            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _dynamicReportingPage.GoToDynamicReportingPage().GetAwaiter().GetResult();
                _dynamicReportingPage.ClickCustomReportModalTab().GetAwaiter().GetResult();
                _dynamicReportingPage.AssertCorrectCategoriesAreAvailableForUser(user).GetAwaiter().GetResult();
            }
        }
    }
}