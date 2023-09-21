using GembaCloud.PlaywrightTests.Pages;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]//this is different from other TestFixtures as I think these tests can interfere with each other
    public class LogBookPageUserRoleElementAuthorisationTests : BaseTests
    {
        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.guestReporting)]
        public async Task reporting_user_should_not_have_access_to_add_log_button(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            LogBookPage _logBookPage = new LogBookPage(page);
            
            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _logBookPage.GoToLogBookPage().GetAwaiter().GetResult();
                _logBookPage.AssertAddLogButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.guestReporting)]
        public async Task reporting_user_should_not_have_access_to_edit_log_button(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            LogBookPage _logBookPage = new LogBookPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _logBookPage.GoToLogBookPage().GetAwaiter().GetResult();
                _logBookPage.ClickGridViewButton().GetAwaiter().GetResult();
                _logBookPage.SetStartDateFilter("2022", "01", "01").GetAwaiter().GetResult();
                _logBookPage.SelectAllAssets().GetAwaiter().GetResult();
                _logBookPage.ClickViewLogButton(1).GetAwaiter().GetResult();
                _logBookPage.AssertEditLogButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.dataEntry)]
        [TestCase(CredentialNames.guestReporting)]
        [TestCase(CredentialNames.guestDataEntry)]
        public async Task user_should_not_have_access_to_delete_log_button(string userType)
        {
            LoginPage _loginPage = new LoginPage(page);
            LogBookPage _logBookPage = new LogBookPage(page);

            lock (userType)
            {
                _loginPage.LogIn(userType).GetAwaiter().GetResult();
                _logBookPage.GoToLogBookPage().GetAwaiter().GetResult();
                _logBookPage.ClickGridViewButton().GetAwaiter().GetResult();
                _logBookPage.SetStartDateFilter("2022", "01", "01").GetAwaiter().GetResult();
                _logBookPage.SelectAllAssets().GetAwaiter().GetResult();
                _logBookPage.AssertDeleteLogButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }

        [Test]
        public async Task data_entry_user_should_not_have_access_to_delete_log_book_category_button()
        {
            LoginPage _loginPage = new LoginPage(page);
            LogBookCategoriesPage _logBookCategoriesPage = new LogBookCategoriesPage(page);

            lock (CredentialNames.basicConfigurationAndDataEntry)
            {
                _loginPage.LogIn(CredentialNames.basicConfigurationAndDataEntry).GetAwaiter().GetResult(); //Basic Config is needed to access the page. It adds no extra relevent permissions
                _logBookCategoriesPage.GoToLogBookCategoriesPage().GetAwaiter().GetResult();
                _logBookCategoriesPage.AssertDeleteLogBookCategoryButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }
    }
}