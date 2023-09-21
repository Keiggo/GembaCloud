using GembaCloud.PlaywrightTests.Pages;

namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]//this is different from other TestFixtures as I think these tests can interfere with each other
    public class ShiftEditorPageUserRoleElementAuthorisationTests : BaseTests
    {
        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.guestReporting)]
        public async Task reporting_user_should_not_have_access_to_create_shift_button(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ShiftEditorPage _shiftEditorPage = new ShiftEditorPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _shiftEditorPage.GoToShiftEditorPage().GetAwaiter().GetResult();
                _shiftEditorPage.SetShiftDate("2022", "01", "02").GetAwaiter().GetResult();
                _shiftEditorPage.SelectShiftDropDownOptionByText("Example Shift").GetAwaiter().GetResult();
                _shiftEditorPage.ClickAssetEllipsisButton().GetAwaiter().GetResult();
                _shiftEditorPage.ExpandAssetTreeBranch(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _shiftEditorPage.SelectAssetTreeAsset(TestEntityNames.asset001).GetAwaiter().GetResult();
                _shiftEditorPage.AssertCreateShiftButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.guestReporting)]
        public async Task reporting_user_should_not_have_access_to_save_shift_button(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ShiftEditorPage _shiftEditorPage = new ShiftEditorPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _shiftEditorPage.GoToShiftEditorPage().GetAwaiter().GetResult();
                _shiftEditorPage.SetShiftDate("2022", "01", "01").GetAwaiter().GetResult();
                _shiftEditorPage.SelectShiftDropDownOptionByText("Example Shift").GetAwaiter().GetResult();
                _shiftEditorPage.ClickAssetEllipsisButton().GetAwaiter().GetResult();
                _shiftEditorPage.ExpandAssetTreeBranch(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _shiftEditorPage.ExpandAssetTreeBranch(TestEntityNames.branch001).GetAwaiter().GetResult();
                _shiftEditorPage.SelectAssetTreeAsset(TestEntityNames.asset002).GetAwaiter().GetResult();
                _shiftEditorPage.AssertSaveShiftButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.guestReporting)]
        public async Task reporting_user_should_not_have_access_to_delete_shift_button(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ShiftEditorPage _shiftEditorPage = new ShiftEditorPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _shiftEditorPage.GoToShiftEditorPage().GetAwaiter().GetResult();
                _shiftEditorPage.SetShiftDate("2022", "01", "01").GetAwaiter().GetResult();
                _shiftEditorPage.SelectShiftDropDownOptionByText("Example Shift").GetAwaiter().GetResult();
                _shiftEditorPage.ClickAssetEllipsisButton().GetAwaiter().GetResult();
                _shiftEditorPage.ExpandAssetTreeBranch(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _shiftEditorPage.ExpandAssetTreeBranch(TestEntityNames.branch001).GetAwaiter().GetResult();
                _shiftEditorPage.SelectAssetTreeAsset(TestEntityNames.asset002).GetAwaiter().GetResult();
                _shiftEditorPage.AssertDeleteShiftButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }

        [TestCase(CredentialNames.reporting)]
        [TestCase(CredentialNames.guestReporting)]
        public async Task reporting_user_should_not_have_access_to_cancel_edit_button(string user)
        {
            LoginPage _loginPage = new LoginPage(page);
            ShiftEditorPage _shiftEditorPage = new ShiftEditorPage(page);

            lock (user)
            {
                _loginPage.LogIn(user).GetAwaiter().GetResult();
                _shiftEditorPage.GoToShiftEditorPage().GetAwaiter().GetResult();
                _shiftEditorPage.SetShiftDate("2022", "01", "01").GetAwaiter().GetResult();
                _shiftEditorPage.SelectShiftDropDownOptionByText("Example Shift").GetAwaiter().GetResult();
                _shiftEditorPage.ClickAssetEllipsisButton().GetAwaiter().GetResult();
                _shiftEditorPage.ExpandAssetTreeBranch(TestEntityNames.systemTopLevelBranch).GetAwaiter().GetResult();
                _shiftEditorPage.ExpandAssetTreeBranch(TestEntityNames.branch001).GetAwaiter().GetResult();
                _shiftEditorPage.SelectAssetTreeAsset(TestEntityNames.asset002).GetAwaiter().GetResult();
                _shiftEditorPage.AssertCancelEditButtonIsNotOnPage().GetAwaiter().GetResult();
            }
        }
    }
}