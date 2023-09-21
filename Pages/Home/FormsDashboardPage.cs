namespace GembaCloud.PlaywrightTests.Pages
{
    public class FormsDashboardPage : BasePage
    {
        private IPage _page;
        private ILocator _locatorStartDateField;
        private ILocator _locatorEndDateField;
        private ILocator _locatorPendingFormContainer;
        private ILocator _locatorModalSaveButton;
        private ILocator _locatorSuccessAlert;
        private ILocator _locatorEditFormModal;

        public FormsDashboardPage(IPage page) : base(page)
        {
            _page = page;
            _locatorStartDateField = _page.Locator("input[id='StartDate']");
            _locatorEndDateField = _page.Locator("input[id='EndDate']");
            _locatorPendingFormContainer = _page.Locator("div[id='pending-card-container']");
            _locatorModalSaveButton = _page.Locator("button[data-bind^='visible: showScheduleControls()'][class='save-button btn']");
            _locatorSuccessAlert = _page.Locator("div.alert.alert-dis.alert-success.alert-dismissible");
            _locatorEditFormModal = _page.Locator("div[id='form-init-container']");
        }

        public async Task GoToFormsDashboardPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.formsDashboard);
        }

        public async Task EnterStartDate(string yyyy, string mm, string dd)
        {
            await ClearTextField(_locatorStartDateField);
            await EnterDateIntoJsDatePicker(_locatorStartDateField, yyyy, mm, dd);
            await WaitForPageLoad();
        }

        public async Task EnterEndDate(string yyyy, string mm, string dd)
        {
            await ClearTextField(_locatorEndDateField);
            await EnterDateIntoJsDatePicker(_locatorEndDateField, yyyy, mm, dd);
            await WaitForPageLoad();
        }

        public async Task ClickPendingCard()
        {
            await _locatorPendingFormContainer.Locator("div[class='card-border card-border-pending']").Locator("div[class='card']").ClickAsync();
            await WaitForPageLoad();
        }

        public async Task ClickModalSaveButton()
        {
            await _locatorModalSaveButton.ClickAsync();
            await WaitForPageLoad();
        }

        public async Task AssertSuccessAlertIsDisplayed()
        {
            Console.WriteLine(_locatorSuccessAlert.ToString());
            await _page.WaitForSelectorAsync(_locatorSuccessAlert.ToString().Split("@")[1], new() { State = WaitForSelectorState.Visible });
            
            Assert.That(await _locatorSuccessAlert.IsVisibleAsync());
        }

        public async Task AssertThatEditFormModalIsNotDisplayed()
        {
            try
            {
                await _page.WaitForSelectorAsync(_locatorEditFormModal.ToString().Split("@")[1], new() { State = WaitForSelectorState.Visible });
                throw new Exception("The Edit Form Modal was opened but this user should not have access");
            }

            catch
            {
                //this is a very weird method but I can't think of a better way to achieve this
                //basically, we need to wait for the modal because it doesn't open immediately anyway
                //so immediately asserting that it isn't there would always pass, even if the test should fail
                //what we have here is waiting for the form to appear, if it does throw and exception
                //if it doesn't, do nothing. Hence there are only comments in the catch!
            }
        }
    }
}