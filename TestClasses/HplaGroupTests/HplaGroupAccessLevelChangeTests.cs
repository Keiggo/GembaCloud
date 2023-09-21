namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    [NonParallelizable]
    public class HplaGroupAccessLevelChangeTests : BaseTests
    {
        // protected MasterBrowsers _browser;

        // protected HplaGroupAccessLevelChangeTests(MasterBrowsers browser) : base(browser)
        // {
        //     _browser = browser;
        // }

        [SetUp]
        public void SetPlantLevelAccessGroupUserToGroup2AndSetToCorrectAccessLevel()
        {
            //I need an api or DB query to do this!!!
            //also this
        }

        [TearDown]
        public void ResetGroup2AccessLevel()
        {
            //I need an api or DB query to do this!!!
        }

        // [Test]
        // public void users_can_access_correct_entities_on_oee_dashboard_page_when_the_access_level_of_their_hpla_group_is_changed()
        // {
        //     string plaGroupUser = page.CurrentWindowHandle;

        //     //asserts that roleupdate user has correct starting access
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _oeeDashboardPage.GoToOeeDashboardPage();
        //     _oeeDashboardPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
        //     _oeeDashboardPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset001);
        //     _oeeDashboardPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset002);
        //     _oeeDashboardPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset007);
        //     _oeeDashboardPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset008);
        //     _oeeDashboardPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset003);
        //     _oeeDashboardPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset004);
        //     _oeeDashboardPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset005);
        //     _oeeDashboardPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset006);
        //     _navigationBar.LogOutOfCurrentUser();

        //     page.SwitchTo().NewWindow(WindowType.Window);
        //     string adminwindow = page.CurrentWindowHandle;

        //     //admin user changes HPLA group's access level 
        //     _loginPage.GoToLoginPage();
        //     _loginPage.LogInAsAccountAdministration();
        //     _plantLevelAccessGroupPage.GoToPlantLevelAccessGroupPage();
        //     _plantLevelAccessGroupPage.ClickPlantLevelAccessGroup2Button();
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset001);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset002);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset003);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset004);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset005);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset006);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset007);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset008);
        //     _plantLevelAccessGroupPage.ClickModalSaveButton();

        //     page.SwitchTo().Window(plaGroupUser);

        //     //asserts roleupdate user's access has updated correctly
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _oeeDashboardPage.GoToOeeDashboardPage();
        //     _oeeDashboardPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset003);
        //     _oeeDashboardPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset004);
        //     _oeeDashboardPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset005);
        //     _oeeDashboardPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset006);
        //     _oeeDashboardPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset001);
        //     _oeeDashboardPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset002);
        //     _oeeDashboardPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset007);
        //     _oeeDashboardPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset008);
        // }

        // [Test]
        // public void users_can_access_correct_entities_on_map_overview_page_when_the_access_level_of_their_hpla_group_is_changed()
        // {
        //     string plaGroupUser = page.CurrentWindowHandle;

        //     //asserts that roleupdate user has correct starting access
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _mapOverviewPage.GoToMapOverviewPage();
        //     _mapOverviewPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
        //     _mapOverviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset001);
        //     _mapOverviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset002);
        //     _mapOverviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset007);
        //     _mapOverviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset008);
        //     _mapOverviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset003);
        //     _mapOverviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset004);
        //     _mapOverviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset005);
        //     _mapOverviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset006);
        //     _navigationBar.LogOutOfCurrentUser();

        //     page.SwitchTo().NewWindow(WindowType.Window);
        //     string adminwindow = page.CurrentWindowHandle;

        //     //admin user changes HPLA group's access level 
        //     _loginPage.GoToLoginPage();
        //     _loginPage.LogInAsAccountAdministration();
        //     _plantLevelAccessGroupPage.GoToPlantLevelAccessGroupPage();
        //     _plantLevelAccessGroupPage.ClickPlantLevelAccessGroup2Button();
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset001);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset002);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset003);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset004);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset005);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset006);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset007);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset008);
        //     _plantLevelAccessGroupPage.ClickModalSaveButton();

        //     page.SwitchTo().Window(plaGroupUser);

        //     //asserts roleupdate user's access has updated correctly
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _mapOverviewPage.GoToMapOverviewPage();
        //     _mapOverviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset003);
        //     _mapOverviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset004);
        //     _mapOverviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset005);
        //     _mapOverviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset006);
        //     _mapOverviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset001);
        //     _mapOverviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset002);
        //     _mapOverviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset007);
        //     _mapOverviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset008);
        // }

        // [Test]
        // public void users_can_access_correct_entities_on_oee_reporting_page_when_the_access_level_of_their_hpla_group_is_changed()
        // {
        //     string plaGroupUser = page.CurrentWindowHandle;

        //     //asserts that roleupdate user has correct starting access
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _oeeReportingPage.GoToOeeReportingPage();
        //     _oeeReportingPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
        //     _oeeReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset001);
        //     _oeeReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset002);
        //     _oeeReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset007);
        //     _oeeReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset008);
        //     _oeeReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset003);
        //     _oeeReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset004);
        //     _oeeReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset005);
        //     _oeeReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset006);
        //     _navigationBar.LogOutOfCurrentUser();

        //     page.SwitchTo().NewWindow(WindowType.Window);
        //     string adminwindow = page.CurrentWindowHandle;

        //     //admin user changes HPLA group's access level 
        //     _loginPage.GoToLoginPage();
        //     _loginPage.LogInAsAccountAdministration();
        //     _plantLevelAccessGroupPage.GoToPlantLevelAccessGroupPage();
        //     _plantLevelAccessGroupPage.ClickPlantLevelAccessGroup2Button();
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset001);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset002);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset003);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset004);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset005);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset006);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset007);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset008);
        //     _plantLevelAccessGroupPage.ClickModalSaveButton();

        //     page.SwitchTo().Window(plaGroupUser);

        //     //asserts roleupdate user's access has updated correctly
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _oeeReportingPage.GoToOeeReportingPage();
        //     _oeeReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset003);
        //     _oeeReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset004);
        //     _oeeReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset005);
        //     _oeeReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset006);
        //     _oeeReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset001);
        //     _oeeReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset002);
        //     _oeeReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset007);
        //     _oeeReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset008);
        // }

        // [Test]
        // public void users_can__access_correct_entities_on_daily_production_review_page_when_the_access_level_of_their_hpla_group_is_changed()
        // {
        //     string plaGroupUser = page.CurrentWindowHandle;

        //     //asserts that roleupdate user has correct starting access
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _dailyProductionReviewPage.GoToDailyProductionReviewPage();
        //     _dailyProductionReviewPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
        //     _dailyProductionReviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset001);
        //     _dailyProductionReviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset002);
        //     _dailyProductionReviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset007);
        //     _dailyProductionReviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset008);
        //     _dailyProductionReviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset003);
        //     _dailyProductionReviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset004);
        //     _dailyProductionReviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset005);
        //     _dailyProductionReviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset006);
        //     _navigationBar.LogOutOfCurrentUser();

        //     page.SwitchTo().NewWindow(WindowType.Window);
        //     string adminwindow = page.CurrentWindowHandle;

        //     //admin user changes HPLA group's access level 
        //     _loginPage.GoToLoginPage();
        //     _loginPage.LogInAsAccountAdministration();
        //     _plantLevelAccessGroupPage.GoToPlantLevelAccessGroupPage();
        //     _plantLevelAccessGroupPage.ClickPlantLevelAccessGroup2Button();
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset001);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset002);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset003);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset004);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset005);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset006);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset007);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset008);
        //     _plantLevelAccessGroupPage.ClickModalSaveButton();

        //     page.SwitchTo().Window(plaGroupUser);

        //     //asserts roleupdate user's access has updated correctly
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _dailyProductionReviewPage.GoToDailyProductionReviewPage();
        //     _dailyProductionReviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset003);
        //     _dailyProductionReviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset004);
        //     _dailyProductionReviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset005);
        //     _dailyProductionReviewPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset006);
        //     _dailyProductionReviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset001);
        //     _dailyProductionReviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset002);
        //     _dailyProductionReviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset007);
        //     _dailyProductionReviewPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset008);
        // }

        // [Test]
        // public void users_can_access_correct_entities_on_shit_editor_page_when_the_access_level_of_their_hpla_group_is_changed()
        // {
        //     string plaGroupUser = page.CurrentWindowHandle;

        //     //asserts that roleupdate user has correct starting access
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _shiftEditorPage.GoToShiftEditorPage();
        //     _shiftEditorPage.SetShiftDate("2022","01","01");
        //     _shiftEditorPage.SelectShiftDropDownOptionByText("Example Shift");
        //     _shiftEditorPage.ClickAssetEllipsisButton();
        //     _shiftEditorPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
        //     _shiftEditorPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset001);
        //     _shiftEditorPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset002);
        //     _shiftEditorPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset007);
        //     _shiftEditorPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset008);
        //     _shiftEditorPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset003);
        //     _shiftEditorPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset004);
        //     _shiftEditorPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset005);
        //     _shiftEditorPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset006);
        //     _navigationBar.LogOutOfCurrentUser();

        //     page.SwitchTo().NewWindow(WindowType.Window);
        //     string adminwindow = page.CurrentWindowHandle;

        //     //admin user changes HPLA group's access level 
        //     _loginPage.GoToLoginPage();
        //     _loginPage.LogInAsAccountAdministration();
        //     _plantLevelAccessGroupPage.GoToPlantLevelAccessGroupPage();
        //     _plantLevelAccessGroupPage.ClickPlantLevelAccessGroup2Button();
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset001);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset002);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset003);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset004);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset005);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset006);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset007);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset008);
        //     _plantLevelAccessGroupPage.ClickModalSaveButton();

        //     page.SwitchTo().Window(plaGroupUser);

        //     //asserts roleupdate user's access has updated correctly
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _shiftEditorPage.GoToShiftEditorPage();
        //     _shiftEditorPage.SetShiftDate("2022","01","01");
        //     _shiftEditorPage.SelectShiftDropDownOptionByText("Example Shift");
        //     _shiftEditorPage.ClickAssetEllipsisButton();
        //     _shiftEditorPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset003);
        //     _shiftEditorPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset004);
        //     _shiftEditorPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset005);
        //     _shiftEditorPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset006);
        //     _shiftEditorPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset001);
        //     _shiftEditorPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset002);
        //     _shiftEditorPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset007);
        //     _shiftEditorPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset008);
        // }

        // [Test]
        // public void users_can_access_correct_entities_on_gemba_intelligence_page_when_the_access_level_of_their_hpla_group_is_changed()
        // {
        //     string plaGroupUser = page.CurrentWindowHandle;

        //     //asserts that roleupdate user has correct starting access
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _gembaIntelligencePage.GoToGembaIntelligencePage();
        //     _gembaIntelligencePage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
        //     _gembaIntelligencePage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset001);
        //     _gembaIntelligencePage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset002);
        //     _gembaIntelligencePage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset007);
        //     _gembaIntelligencePage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset008);
        //     _gembaIntelligencePage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset003);
        //     _gembaIntelligencePage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset004);
        //     _gembaIntelligencePage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset005);
        //     _gembaIntelligencePage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset006);
        //     _navigationBar.LogOutOfCurrentUser();

        //     page.SwitchTo().NewWindow(WindowType.Window);
        //     string adminwindow = page.CurrentWindowHandle;

        //     //admin user changes HPLA group's access level 
        //     _loginPage.GoToLoginPage();
        //     _loginPage.LogInAsAccountAdministration();
        //     _plantLevelAccessGroupPage.GoToPlantLevelAccessGroupPage();
        //     _plantLevelAccessGroupPage.ClickPlantLevelAccessGroup2Button();
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset001);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset002);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset003);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset004);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset005);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset006);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset007);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset008);
        //     _plantLevelAccessGroupPage.ClickModalSaveButton();

        //     page.SwitchTo().Window(plaGroupUser);

        //     //asserts roleupdate user's access has updated correctly
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _gembaIntelligencePage.GoToGembaIntelligencePage();
        //     _gembaIntelligencePage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset003);
        //     _gembaIntelligencePage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset004);
        //     _gembaIntelligencePage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset005);
        //     _gembaIntelligencePage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset006);
        //     _gembaIntelligencePage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset001);
        //     _gembaIntelligencePage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset002);
        //     _gembaIntelligencePage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset007);
        //     _gembaIntelligencePage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset008);
        // }

        // [Test]
        // public void users_can_access_correct_entities_on_log_book_page_when_the_access_level_of_their_hpla_group_is_changed()
        // {
        //     string plaGroupUser = page.CurrentWindowHandle;

        //     //asserts that roleupdate user has correct starting access
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _logBookPage.GoToLogBookPage();
        //     _logBookPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
        //     _logBookPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset001);
        //     _logBookPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset002);
        //     _logBookPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset007);
        //     _logBookPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset008);
        //     _logBookPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset003);
        //     _logBookPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset004);
        //     _logBookPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset005);
        //     _logBookPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset006);
        //     _navigationBar.LogOutOfCurrentUser();

        //     page.SwitchTo().NewWindow(WindowType.Window);
        //     string adminwindow = page.CurrentWindowHandle;

        //     //admin user changes HPLA group's access level 
        //     _loginPage.GoToLoginPage();
        //     _loginPage.LogInAsAccountAdministration();
        //     _plantLevelAccessGroupPage.GoToPlantLevelAccessGroupPage();
        //     _plantLevelAccessGroupPage.ClickPlantLevelAccessGroup2Button();
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset001);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset002);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset003);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset004);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset005);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset006);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset007);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset008);
        //     _plantLevelAccessGroupPage.ClickModalSaveButton();

        //     page.SwitchTo().Window(plaGroupUser);

        //     //asserts roleupdate user's access has updated correctly
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _logBookPage.GoToLogBookPage();
        //     _logBookPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset003);
        //     _logBookPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset004);
        //     _logBookPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset005);
        //     _logBookPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset006);
        //     _logBookPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset001);
        //     _logBookPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset002);
        //     _logBookPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset007);
        //     _logBookPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset008);
        // }

        // [Test]
        // public void users_can_access_correct_entities_on_dynamic_reporting_page_when_the_access_level_of_their_hpla_group_is_changed()
        // {
        //     string plaGroupUser = page.CurrentWindowHandle;

        //     //asserts that roleupdate user has correct starting access
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _dynamicReportingPage.GoToDynamicReportingPage();
        //     _dynamicReportingPage.ClickCustomReportModalTab();
        //     _dynamicReportingPage.ClickAssetsRowHeaderModal();
        //     _dynamicReportingPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
        //     _dynamicReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset001);
        //     _dynamicReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset002);
        //     _dynamicReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset007);
        //     _dynamicReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset008);
        //     _dynamicReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset003);
        //     _dynamicReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset004);
        //     _dynamicReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset005);
        //     _dynamicReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset006);
        //     _dynamicReportingPage.ClickModalCloseButton();
        //     _navigationBar.LogOutOfCurrentUser();

        //     page.SwitchTo().NewWindow(WindowType.Window);
        //     string adminwindow = page.CurrentWindowHandle;

        //     //admin user changes HPLA group's access level 
        //     _loginPage.GoToLoginPage();
        //     _loginPage.LogInAsAccountAdministration();
        //     _plantLevelAccessGroupPage.GoToPlantLevelAccessGroupPage();
        //     _plantLevelAccessGroupPage.ClickPlantLevelAccessGroup2Button();
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset001);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset002);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset003);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset004);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset005);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset006);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset007);
        //     _plantLevelAccessGroupPage.ClickAssetPickerAsset(MasterTestEntities.intAsset008);
        //     _plantLevelAccessGroupPage.ClickModalSaveButton();

        //     page.SwitchTo().Window(plaGroupUser);

        //     //asserts roleupdate user's access has updated correctly
        //     _loginPage.LoginAsPlantLevelAccessGroups();
        //     _dynamicReportingPage.GoToDynamicReportingPage();
        //     _dynamicReportingPage.ClickCustomReportModalTab();
        //     _dynamicReportingPage.ClickAssetsRowHeaderModal();
        //     _dynamicReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset003);
        //     _dynamicReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset004);
        //     _dynamicReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset005);
        //     _dynamicReportingPage.AssertAssetIsPresentInPicker(MasterTestEntities.intAsset006);
        //     _dynamicReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset001);
        //     _dynamicReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset002);
        //     _dynamicReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset007);
        //     _dynamicReportingPage.AssertAssetIsNotPresentInPicker(MasterTestEntities.intAsset008);
        // }
    }
}