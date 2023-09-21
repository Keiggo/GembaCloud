using GembaCloud.PlaywrightTests.Pages;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]//this is different from other TestFixtures as I think these tests can interfere with each other
    public class GembaIntelligencePageUserRoleElementAuthorisationTests : BaseTests
    {
        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.guestReporting)]
        public async Task reporting_user_should_not_have_access_to_intelligence_header_acknowledge_button(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            GembaIntelligencePage _gembaIntelligencePage = new GembaIntelligencePage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _gembaIntelligencePage.GoToGembaIntelligencePage().GetAwaiter().GetResult();
                _gembaIntelligencePage.AssertAcknowledgeButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.guestReporting)]
        public async Task reporting_user_should_not_have_access_to_intelligence_dropdown_create_action_button(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            GembaIntelligencePage _gembaIntelligencePage = new GembaIntelligencePage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _gembaIntelligencePage.GoToGembaIntelligencePage().GetAwaiter().GetResult();
                _gembaIntelligencePage.SetFilterStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _gembaIntelligencePage.SelectAllAssetsInPicker().GetAwaiter().GetResult();
                _gembaIntelligencePage.ExpandGembaIntelligenceTableRow(0).GetAwaiter().GetResult();
                _gembaIntelligencePage.ClickSubTableRowElipsesButton(0, 0).GetAwaiter().GetResult();
                _gembaIntelligencePage.AssertCreateActionDropdownButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.guestReporting)]
        public async Task reporting_user_should_not_have_access_to_intelligence_dropdown_acknowledge_button(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            GembaIntelligencePage _gembaIntelligencePage = new GembaIntelligencePage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _gembaIntelligencePage.GoToGembaIntelligencePage().GetAwaiter().GetResult();
                _gembaIntelligencePage.SetFilterStartDate("2022", "01", "01").GetAwaiter().GetResult();
                _gembaIntelligencePage.SelectAllAssetsInPicker().GetAwaiter().GetResult();
                _gembaIntelligencePage.ExpandGembaIntelligenceTableRow(0).GetAwaiter().GetResult();
                _gembaIntelligencePage.ClickGembaIntelligenceSubTableElipsisButton(0, 0).GetAwaiter().GetResult();
                _gembaIntelligencePage.AssertAcknowledgeDropdownButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }
    }
}