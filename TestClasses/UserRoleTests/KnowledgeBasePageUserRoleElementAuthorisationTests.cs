using GembaCloud.PlaywrightTests.Pages;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]//this is different from other TestFixtures as I think these tests can interfere with each other
    public class KnowledgeBasePageUserRoleElementAuthorisationTests : BaseTests
    {
        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.guestReporting)]
        public async Task reporting_user_should_not_have_access_to_knowledge_base_page_show_all_checkbox(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            KnowledgeBasePage _knowledgeBasePage = new KnowledgeBasePage(page);
            
            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _knowledgeBasePage.GoToKnowledgeBasePage().GetAwaiter().GetResult();
                _knowledgeBasePage.AssertShowAllCheckboxIsNotOnPage().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.guestReporting)]
        public async Task reporting_user_should_not_have_access_to_knowledge_base_add_article_button(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            KnowledgeBasePage _knowledgeBasePage = new KnowledgeBasePage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _knowledgeBasePage.GoToKnowledgeBasePage().GetAwaiter().GetResult();
                _knowledgeBasePage.AssertAddArticleButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.guestReporting)]
        public async Task reporting_user_should_not_have_access_to_knowledge_base_page_edit_article_button(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            KnowledgeBasePage _knowledgeBasePage = new KnowledgeBasePage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _knowledgeBasePage.GoToKnowledgeBasePage().GetAwaiter().GetResult();
                _knowledgeBasePage.ClickExampleEventCategoryEntityPickerPlusButton().GetAwaiter().GetResult();
                _knowledgeBasePage.ClickExampleEventReasonEntityPickerEntity().GetAwaiter().GetResult();
                _knowledgeBasePage.ExpandSavedAndPublishedPanel().GetAwaiter().GetResult();
                _knowledgeBasePage.AssertEditSavedAndPublishedArticleButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.guestReporting)]
        public async Task reporting_user_should_not_have_access_to_draft_articles(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            KnowledgeBasePage _knowledgeBasePage = new KnowledgeBasePage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _knowledgeBasePage.GoToKnowledgeBasePage().GetAwaiter().GetResult();
                _knowledgeBasePage.ClickExampleEventCategoryEntityPickerPlusButton().GetAwaiter().GetResult();
                _knowledgeBasePage.ClickExampleEventReasonEntityPickerEntity().GetAwaiter().GetResult();
                _knowledgeBasePage.AssertDraftPaneIsNotOnPage().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.dataEntry)]
        [TestCase(CredentialNames.guestReporting)]
        [TestCase(CredentialNames.guestDataEntry)]
        public async Task user_should_not_have_access_to_knowledge_base_page_delete_article_button(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            KnowledgeBasePage _knowledgeBasePage = new KnowledgeBasePage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _knowledgeBasePage.GoToKnowledgeBasePage().GetAwaiter().GetResult();
                _knowledgeBasePage.ClickExampleEventCategoryEntityPickerPlusButton().GetAwaiter().GetResult();
                _knowledgeBasePage.ClickExampleEventReasonEntityPickerEntity().GetAwaiter().GetResult();
                _knowledgeBasePage.ExpandSavedAndPublishedPanel().GetAwaiter().GetResult();
                _knowledgeBasePage.AssertDeleteSavedAndPublishedArticleButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }
    }
}