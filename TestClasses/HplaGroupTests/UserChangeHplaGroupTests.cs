namespace GembaCloud.PlaywrightTests.TestClasses
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class UserChangeHplaGroupTests : BaseTests
    {
        // protected MasterBrowsers _browser;

        // protected UserChangeHplaGroupTests(MasterBrowsers browser) : base(browser)
        // {
        //     _browser = browser;
        // }

        [SetUp]
        public void SetPlantLevelAccessGroupUserToGroup2()
        {
            //I need an api or DB query to do this!!!
        }

    //    [Test]
    //     public void users_can_access_correct_entities_on_oee_dashboard_page_when_their_hpla_group_is_changed()
    //     {
    //         string plaGroupUser = page.CurrentWindowHandle;

    //         //asserts that roleupdate user has correct starting access
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _oeeDashboardPage.GoToOeeDashboardPage();
    //         _oeeDashboardPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
    //         _oeeDashboardPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset001);
    //         _oeeDashboardPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset002);
    //         _oeeDashboardPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset007);
    //         _oeeDashboardPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset008);
    //         _oeeDashboardPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset003);
    //         _oeeDashboardPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset004);
    //         _oeeDashboardPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset005);
    //         _oeeDashboardPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset006);
    //         _navigationBar.LogOutOfCurrentUser();

    //         page.SwitchTo().NewWindow(WindowType.Window);
    //         string adminwindow = page.CurrentWindowHandle;

    //         //admin user changes roleupdate user's assigned HPLA group 
    //         _loginPage.GoToLoginPage();
    //         _loginPage.LogInAsAccountAdministration();
    //         _memberManagementPage.GoToMemberManagementPage();
    //         _memberManagementPage.SearchMembers("e2eplantlevelaccessgroups");
    //         _memberManagementPage.ClickEditUserButton();
    //         _memberManagementPage.SelectPlantLevelAccessGroupDropdownByText("Example Plant Level Access Group 1");
    //         _memberManagementPage.ClickSaveUserButton();

    //         page.SwitchTo().Window(plaGroupUser);

    //         //asserts roleupdate user's access has updated correctly
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _oeeDashboardPage.GoToOeeDashboardPage();
    //         _oeeDashboardPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset003);
    //         _oeeDashboardPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset004);
    //         _oeeDashboardPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset005);
    //         _oeeDashboardPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset006);
    //         _oeeDashboardPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset001);
    //         _oeeDashboardPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset002);
    //         _oeeDashboardPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset007);
    //         _oeeDashboardPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset008);
    //     }

    //     [Test]
    //     public void users_can_access_correct_entities_on_map_overview_page_when_their_hpla_group_is_changed()
    //     {
    //         string plaGroupUser = page.CurrentWindowHandle;

    //         //asserts that roleupdate user has correct starting access
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _mapOverviewPage.GoToMapOverviewPage();
    //         _mapOverviewPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
    //         _mapOverviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset001);
    //         _mapOverviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset002);
    //         _mapOverviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset007);
    //         _mapOverviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset008);
    //         _mapOverviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset003);
    //         _mapOverviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset004);
    //         _mapOverviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset005);
    //         _mapOverviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset006);
    //         _navigationBar.LogOutOfCurrentUser();

    //         page.SwitchTo().NewWindow(WindowType.Window);
    //         string adminwindow = page.CurrentWindowHandle;

    //         //admin user changes roleupdate user's assigned HPLA group 
    //         _loginPage.GoToLoginPage();
    //         _loginPage.LogInAsAccountAdministration();
    //         _memberManagementPage.GoToMemberManagementPage();
    //         _memberManagementPage.SearchMembers("e2eplantlevelaccessgroups");
    //         _memberManagementPage.ClickEditUserButton();
    //         _memberManagementPage.SelectPlantLevelAccessGroupDropdownByText("Example Plant Level Access Group 1");
    //         _memberManagementPage.ClickSaveUserButton();

    //         page.SwitchTo().Window(plaGroupUser);

    //         //asserts roleupdate user's access has updated correctly
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _mapOverviewPage.GoToMapOverviewPage();
    //         _mapOverviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset003);
    //         _mapOverviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset004);
    //         _mapOverviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset005);
    //         _mapOverviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset006);
    //         _mapOverviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset001);
    //         _mapOverviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset002);
    //         _mapOverviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset007);
    //         _mapOverviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset008);
    //     }

    //     [Test]
    //     public void users_can_access_correct_entities_on_oee_reporting_page_when_their_hpla_group_is_changed()
    //     {
    //         string plaGroupUser = page.CurrentWindowHandle;

    //         //asserts that roleupdate user has correct starting access
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _oeeReportingPage.GoToOeeReportingPage();
    //         _oeeReportingPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
    //         _oeeReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset001);
    //         _oeeReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset002);
    //         _oeeReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset007);
    //         _oeeReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset008);
    //         _oeeReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset003);
    //         _oeeReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset004);
    //         _oeeReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset005);
    //         _oeeReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset006);
    //         _navigationBar.LogOutOfCurrentUser();

    //         page.SwitchTo().NewWindow(WindowType.Window);
    //         string adminwindow = page.CurrentWindowHandle;

    //         //admin user changes roleupdate user's assigned HPLA group 
    //         _loginPage.GoToLoginPage();
    //         _loginPage.LogInAsAccountAdministration();
    //         _memberManagementPage.GoToMemberManagementPage();
    //         _memberManagementPage.SearchMembers("e2eplantlevelaccessgroups");
    //         _memberManagementPage.ClickEditUserButton();
    //         _memberManagementPage.SelectPlantLevelAccessGroupDropdownByText("Example Plant Level Access Group 1");
    //         _memberManagementPage.ClickSaveUserButton();

    //         page.SwitchTo().Window(plaGroupUser);

    //         //asserts roleupdate user's access has updated correctly
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _oeeReportingPage.GoToOeeReportingPage();
    //         _oeeReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset003);
    //         _oeeReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset004);
    //         _oeeReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset005);
    //         _oeeReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset006);
    //         _oeeReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset001);
    //         _oeeReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset002);
    //         _oeeReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset007);
    //         _oeeReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset008);
    //     }

    //     [Test]
    //     public void users_can__access_correct_entities_on_daily_production_review_page_when_their_hpla_group_is_changed()
    //     {
    //         string plaGroupUser = page.CurrentWindowHandle;

    //         //asserts that roleupdate user has correct starting access
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _dailyProductionReviewPage.GoToDailyProductionReviewPage();
    //         _dailyProductionReviewPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
    //         _dailyProductionReviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset001);
    //         _dailyProductionReviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset002);
    //         _dailyProductionReviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset007);
    //         _dailyProductionReviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset008);
    //         _dailyProductionReviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset003);
    //         _dailyProductionReviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset004);
    //         _dailyProductionReviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset005);
    //         _dailyProductionReviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset006);
    //         _navigationBar.LogOutOfCurrentUser();

    //         page.SwitchTo().NewWindow(WindowType.Window);
    //         string adminwindow = page.CurrentWindowHandle;

    //         //admin user changes roleupdate user's assigned HPLA group 
    //         _loginPage.GoToLoginPage();
    //         _loginPage.LogInAsAccountAdministration();
    //         _memberManagementPage.GoToMemberManagementPage();
    //         _memberManagementPage.SearchMembers("e2eplantlevelaccessgroups");
    //         _memberManagementPage.ClickEditUserButton();
    //         _memberManagementPage.SelectPlantLevelAccessGroupDropdownByText("Example Plant Level Access Group 1");
    //         _memberManagementPage.ClickSaveUserButton();

    //         page.SwitchTo().Window(plaGroupUser);

    //         //asserts roleupdate user's access has updated correctly
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _dailyProductionReviewPage.GoToDailyProductionReviewPage();
    //         _dailyProductionReviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset003);
    //         _dailyProductionReviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset004);
    //         _dailyProductionReviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset005);
    //         _dailyProductionReviewPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset006);
    //         _dailyProductionReviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset001);
    //         _dailyProductionReviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset002);
    //         _dailyProductionReviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset007);
    //         _dailyProductionReviewPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset008);
    //     }

    //     [Test]
    //     public void users_can_access_correct_entities_on_shift_editor_page_when_their_hpla_group_is_changed()
    //     {
    //         string plaGroupUser = page.CurrentWindowHandle;

    //         //asserts that roleupdate user has correct starting access
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _shiftEditorPage.GoToShiftEditorPage();
    //         _shiftEditorPage.SetShiftDate("2022","01","01");
    //         _shiftEditorPage.SelectShiftDropDownOptionByText("Example Shift");
    //         _shiftEditorPage.ClickAssetEllipsisButton();
    //         _shiftEditorPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
    //         _shiftEditorPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset001);
    //         _shiftEditorPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset002);
    //         _shiftEditorPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset007);
    //         _shiftEditorPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset008);
    //         _shiftEditorPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset003);
    //         _shiftEditorPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset004);
    //         _shiftEditorPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset005);
    //         _shiftEditorPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset006);
    //         _navigationBar.LogOutOfCurrentUser();

    //         page.SwitchTo().NewWindow(WindowType.Window);
    //         string adminwindow = page.CurrentWindowHandle;

    //         //admin user changes roleupdate user's assigned HPLA group 
    //         _loginPage.GoToLoginPage();
    //         _loginPage.LogInAsAccountAdministration();
    //         _memberManagementPage.GoToMemberManagementPage();
    //         _memberManagementPage.SearchMembers("e2eplantlevelaccessgroups");
    //         _memberManagementPage.ClickEditUserButton();
    //         _memberManagementPage.SelectPlantLevelAccessGroupDropdownByText("Example Plant Level Access Group 1");
    //         _memberManagementPage.ClickSaveUserButton();

    //         page.SwitchTo().Window(plaGroupUser);

    //         //asserts roleupdate user's access has updated correctly
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _shiftEditorPage.GoToShiftEditorPage();
    //         _shiftEditorPage.SetShiftDate("2022","01","01");
    //         _shiftEditorPage.SelectShiftDropDownOptionByText("Example Shift");
    //         _shiftEditorPage.ClickAssetEllipsisButton();
    //         _shiftEditorPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset003);
    //         _shiftEditorPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset004);
    //         _shiftEditorPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset005);
    //         _shiftEditorPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset006);
    //         _shiftEditorPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset001);
    //         _shiftEditorPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset002);
    //         _shiftEditorPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset007);
    //         _shiftEditorPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset008);
    //     }

    //     [Test]
    //     public void users_can_access_correct_entities_on_gemba_intelligence_page_when_their_hpla_group_is_changed()
    //     {
    //         string plaGroupUser = page.CurrentWindowHandle;

    //         //asserts that roleupdate user has correct starting access
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _gembaIntelligencePage.GoToGembaIntelligencePage();
    //         _gembaIntelligencePage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
    //         _gembaIntelligencePage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset001);
    //         _gembaIntelligencePage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset002);
    //         _gembaIntelligencePage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset007);
    //         _gembaIntelligencePage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset008);
    //         _gembaIntelligencePage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset003);
    //         _gembaIntelligencePage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset004);
    //         _gembaIntelligencePage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset005);
    //         _gembaIntelligencePage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset006);
    //         _navigationBar.LogOutOfCurrentUser();

    //         page.SwitchTo().NewWindow(WindowType.Window);
    //         string adminwindow = page.CurrentWindowHandle;

    //         //admin user changes roleupdate user's assigned HPLA group 
    //         _loginPage.GoToLoginPage();
    //         _loginPage.LogInAsAccountAdministration();
    //         _memberManagementPage.GoToMemberManagementPage();
    //         _memberManagementPage.SearchMembers("e2eplantlevelaccessgroups");
    //         _memberManagementPage.ClickEditUserButton();
    //         _memberManagementPage.SelectPlantLevelAccessGroupDropdownByText("Example Plant Level Access Group 1");
    //         _memberManagementPage.ClickSaveUserButton();

    //         page.SwitchTo().Window(plaGroupUser);

    //         //asserts roleupdate user's access has updated correctly
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _gembaIntelligencePage.GoToGembaIntelligencePage();
    //         _gembaIntelligencePage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset003);
    //         _gembaIntelligencePage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset004);
    //         _gembaIntelligencePage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset005);
    //         _gembaIntelligencePage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset006);
    //         _gembaIntelligencePage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset001);
    //         _gembaIntelligencePage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset002);
    //         _gembaIntelligencePage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset007);
    //         _gembaIntelligencePage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset008);
    //     }

    //     [Test]
    //     public void users_can_access_correct_entities_on_log_book_page_when_their_hpla_group_is_changed()
    //     {
    //         string plaGroupUser = page.CurrentWindowHandle;

    //         //asserts that roleupdate user has correct starting access
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _logBookPage.GoToLogBookPage();
    //         _logBookPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
    //         _logBookPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset001);
    //         _logBookPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset002);
    //         _logBookPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset007);
    //         _logBookPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset008);
    //         _logBookPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset003);
    //         _logBookPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset004);
    //         _logBookPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset005);
    //         _logBookPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset006);
    //         _navigationBar.LogOutOfCurrentUser();

    //         page.SwitchTo().NewWindow(WindowType.Window);
    //         string adminwindow = page.CurrentWindowHandle;

    //         //admin user changes roleupdate user's assigned HPLA group 
    //         _loginPage.GoToLoginPage();
    //         _loginPage.LogInAsAccountAdministration();
    //         _memberManagementPage.GoToMemberManagementPage();
    //         _memberManagementPage.SearchMembers("e2eplantlevelaccessgroups");
    //         _memberManagementPage.ClickEditUserButton();
    //         _memberManagementPage.SelectPlantLevelAccessGroupDropdownByText("Example Plant Level Access Group 1");
    //         _memberManagementPage.ClickSaveUserButton();

    //         page.SwitchTo().Window(plaGroupUser);

    //         //asserts roleupdate user's access has updated correctly
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _logBookPage.GoToLogBookPage();
    //         _logBookPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset003);
    //         _logBookPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset004);
    //         _logBookPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset005);
    //         _logBookPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset006);
    //         _logBookPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset001);
    //         _logBookPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset002);
    //         _logBookPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset007);
    //         _logBookPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset008);
    //     }

    //     [Test]
    //     public void users_can_access_correct_entities_on_dynamic_reporting_page_when_their_hpla_group_is_changed()
    //     {
    //         string plaGroupUser = page.CurrentWindowHandle;

    //         //asserts that roleupdate user has correct starting access
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _dynamicReportingPage.GoToDynamicReportingPage();
    //         _dynamicReportingPage.ClickCustomReportModalTab();
    //         _dynamicReportingPage.ClickAssetsRowHeaderModal();
    //         _dynamicReportingPage.ExpandAssetPickerBranch(MasterTestEntities.bylocatorBranch003);
    //         _dynamicReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset001);
    //         _dynamicReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset002);
    //         _dynamicReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset007);
    //         _dynamicReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset008);
    //         _dynamicReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset003);
    //         _dynamicReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset004);
    //         _dynamicReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset005);
    //         _dynamicReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset006);
    //         _dynamicReportingPage.ClickModalCloseButton();
    //         _navigationBar.LogOutOfCurrentUser();

    //         page.SwitchTo().NewWindow(WindowType.Window);
    //         string adminwindow = page.CurrentWindowHandle;

    //         //admin user changes roleupdate user's assigned HPLA group 
    //         _loginPage.GoToLoginPage();
    //         _loginPage.LogInAsAccountAdministration();
    //         _memberManagementPage.GoToMemberManagementPage();
    //         _memberManagementPage.SearchMembers("e2eplantlevelaccessgroups");
    //         _memberManagementPage.ClickEditUserButton();
    //         _memberManagementPage.SelectPlantLevelAccessGroupDropdownByText("Example Plant Level Access Group 1");
    //         _memberManagementPage.ClickSaveUserButton();

    //         page.SwitchTo().Window(plaGroupUser);

    //         //asserts roleupdate user's access has updated correctly
    //         _loginPage.LoginAsPlantLevelAccessGroups();
    //         _dynamicReportingPage.GoToDynamicReportingPage();
    //         _dynamicReportingPage.ClickCustomReportModalTab();
    //         _dynamicReportingPage.ClickAssetsRowHeaderModal();
    //         _dynamicReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset003);
    //         _dynamicReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset004);
    //         _dynamicReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset005);
    //         _dynamicReportingPage.AssertAssetisPresentInPicker(MasterTestEntities.intAsset006);
    //         _dynamicReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset001);
    //         _dynamicReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset002);
    //         _dynamicReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset007);
    //         _dynamicReportingPage.AssertAssetisNotPresentInPicker(MasterTestEntities.intAsset008);
    //     }
    }
}