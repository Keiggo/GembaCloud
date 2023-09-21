using GembaCloud.Web.Models.DynamicChartViewModels.DataSource;

namespace GembaCloud.PlaywrightTests.Pages
{
    public class MemberManagementPage : BasePage
    {
        private IPage _page;
        public ILocator locatorAddMemberButton;
        public ILocator locatorEmailUsernameField;
        public ILocator locatorPasswordField;
        public ILocator locatorConfirmPasswordField;
        public ILocator locatorFirstNameField;
        public ILocator locatorLastNameField;
        public ILocator locatorAccountAdministrationModalCheckbox;
        public ILocator locatorAdvancedConfigurationModalCheckbox;
        public ILocator locatorAdvancedDataEntryModalCheckbox;
        public ILocator locatorAdvancedReportingModalCheckbox;
        public ILocator locatorBasicConfigurationModalCheckbox;
        public ILocator locatorDataEntryModalCheckbox;
        public ILocator locatorReportingModalCheckbox;
        public ILocator locatorRevenueModalCheckbox;
        public ILocator locatorMultipleAccountAccessCheckbox;
        public ILocator locatorPlantLevelAccessGroupDropdown;
        public ILocator locatorCreateMemberButton;
        public ILocator locatorSearchField;
        public ILocator locatorDeleteModalDeleteButton;
        public ILocator locatorTableRowDeleteUserButton;
        public ILocator locatorTableRowEditUserButton;
        public ILocator locatorSaveUserButton;
        private readonly PageGetByLabelOptions options;

        public MemberManagementPage(IPage page) : base(page)
        {
            _page = page;
            options = new PageGetByLabelOptions();
            options.Exact = true;

            locatorAddMemberButton = _page.GetByRole(AriaRole.Link, new() { Name = "+ Add" });
            locatorEmailUsernameField = _page.Locator("#Member_UserName");
            locatorPasswordField = _page.GetByLabel("Password", new() { Exact = true });
            locatorConfirmPasswordField = _page.GetByLabel("Confirm password");
            locatorFirstNameField = _page.GetByLabel("First Name", new() { Exact = true });
            locatorLastNameField = _page.GetByLabel("Last Name", new() { Exact = true });
            locatorAccountAdministrationModalCheckbox = _page.GetByLabel("Account Administration");
            locatorAdvancedConfigurationModalCheckbox = _page.GetByLabel("Advanced Configuration");
            locatorAdvancedDataEntryModalCheckbox = _page.GetByLabel("Advanced Data Entry");
            locatorAdvancedReportingModalCheckbox = _page.GetByLabel("Advanced Reporting");
            locatorBasicConfigurationModalCheckbox = _page.GetByLabel("Basic Configuration");
            locatorDataEntryModalCheckbox = _page.GetByLabel("Data Entry");
            locatorReportingModalCheckbox = _page.GetByLabel("Reporting", options);
            locatorRevenueModalCheckbox = _page.GetByLabel("Revenue");
            locatorMultipleAccountAccessCheckbox = _page.GetByLabel("Multiple Account Access");
            locatorPlantLevelAccessGroupDropdown = _page.GetByRole(AriaRole.Combobox, new() { Name = "Plant Level Access Group" });
            locatorCreateMemberButton = _page.GetByRole(AriaRole.Button, new() { Name = " Create" });
            locatorSearchField = _page.GetByLabel("Search:");
            locatorDeleteModalDeleteButton = _page.GetByRole(AriaRole.Button, new() { Name = " Delete" });
            locatorTableRowDeleteUserButton = _page.GetByRole(AriaRole.Link, new() { Name = " Delete" });
            locatorTableRowEditUserButton = _page.Locator("css=a[data-postback='/Member/Edit']");
            locatorSaveUserButton = _page.GetByRole(AriaRole.Button, new() { Name = " Save" });
        }

        public async Task GoToMemberManagementPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.memberManagement);
        }

        public async Task ClickAddMemberButton()
        {
            await locatorAddMemberButton.ClickAsync();
        }

        public async Task EnterEmailAddress(string emailAddress)
        {
            await EnterTextIntoTextField(locatorEmailUsernameField, emailAddress);
        }

        public async Task EnterPassword(string password)
        {
            await EnterTextIntoTextField(locatorPasswordField, password);
        }

        public async Task EnterConfirmPassword(string password)
        {
            await EnterTextIntoTextField(locatorConfirmPasswordField, password);
        }

        public async Task EnterFirstName(string firstName)
        {
            await EnterTextIntoTextField(locatorFirstNameField, firstName);
        }

        public async Task EnterLastName(string lastName)
        {
            await EnterTextIntoTextField(locatorLastNameField, lastName);
        }

        public async Task ClickReportingCheckbox()
        {
            await locatorReportingModalCheckbox.ClickAsync();
        }

        public async Task ClickCreateMemberButton()
        {
            await locatorCreateMemberButton.ClickAsync();
        }

        public async Task SearchMembers(string searchText)
        {
            await EnterTextIntoTextField(locatorSearchField, searchText);
            await WaitForPageLoad();
        }

        public async Task<ILocator> GetTableRow(int tableRowNumber)
        {
            ILocator tableRow = _page.Locator($"//*[@id='member-table']/tbody/tr[{tableRowNumber}]");
            return tableRow;
        }

        public async Task<ILocator> GetLoneTableRow()
        {
            ILocator tableRow = _page.Locator($"//*[@id='member-table']/tbody/tr");
            return tableRow;
        }

        public async Task ClickDeleteUserButton(int tableRowNumber)
        {
            var tableRow = await GetTableRow(tableRowNumber);
            var deleteUserButton = tableRow.Locator(GetElementSelector(locatorTableRowDeleteUserButton).ToString());
            await deleteUserButton.ClickAsync();
        }

        public async Task ClickDeleteModalDeleteButton()
        {
            await locatorDeleteModalDeleteButton.ClickAsync();
        }

        public async Task ClickEditUserButton()
        {
/*            var tableRow = await GetLoneTableRow();
            var editUserButton = tableRow.Locator(GetElementSelector(locatorTableRowEditUserButton).ToString());*/
            await locatorTableRowEditUserButton.ClickAsync();
            await WaitForPageLoad();
        }

        public async Task<List<ILocator>> GetAllRolesInModal()
        {
            List<ILocator> allRoles = new List<ILocator>()
            {
                locatorAccountAdministrationModalCheckbox,
                locatorAdvancedConfigurationModalCheckbox,
                locatorAdvancedDataEntryModalCheckbox,
                locatorAdvancedReportingModalCheckbox,
                locatorBasicConfigurationModalCheckbox,
                locatorDataEntryModalCheckbox,
                locatorReportingModalCheckbox,
                locatorRevenueModalCheckbox
                //TODO: before this can be used, we need to address the additional checkbox that has been added
            };

            return allRoles;
        }

        public async Task ClickAllUserRoles()
        {
            foreach(ILocator role in await GetAllRolesInModal())
            {
                await role.ClickAsync();
            }
        }

        public async Task ClickSaveUserButton()
        {
            await locatorSaveUserButton.ClickAsync();
        }

        public async Task SelectPlantLevelAccessGroupDropdownOptionByIndex(int optionIndex)
        {
            await SelectDropDownOptionByIndex(locatorPlantLevelAccessGroupDropdown, optionIndex);
        }

        public async Task SelectPlantLevelAccessGroupDropdownByText(string optionText)
        {
            await SelectDropDownOptionByText(locatorPlantLevelAccessGroupDropdown, optionText);
        }

        public async Task AssertMultipleAccountAccessCheckboxIsDisabled()
        {
            await AssertElementIsNotPresent(locatorMultipleAccountAccessCheckbox);
        }

        public async Task ClickMultipleAccountAccessCheckbox()
        {
            await locatorMultipleAccountAccessCheckbox.ClickAsync();
        }
    }
}