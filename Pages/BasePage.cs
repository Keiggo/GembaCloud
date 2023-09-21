using GembaCloud.PlaywrightTests.Data;
using System.Linq.Expressions;
using Codeuctivity.ImageSharpCompare;
using SixLabors.ImageSharp;
using AngleSharp.Dom;

namespace GembaCloud.PlaywrightTests.Pages
{   
    public class BasePage
    {
        [ThreadStatic] private IPage _page;
        protected ConfigDataAccess _config;

        protected BasePage(IPage page)
        {
            _page = page;
            _config = new ConfigDataAccess();
        }

        protected async Task EnterTextIntoTextField(ILocator textField, string textToEnter)
        {
            await textField.ClickAsync();
            await _page.Keyboard.TypeAsync(textToEnter);
        }

        protected async Task<string> GetElementSelector(ILocator element)
        {
            //TODO: is the below selector the best way to do this? It's so ugly
            string selector = await element.EvaluateAsync<string>("e => e.tagName.toLowerCase() + (e.id ? '#' + e.id : '') + (e.className ? '.' + e.className.split(' ').join('.') : '')");
            return selector;
        }

        protected async Task EnterDateIntoHtml5DatePicker(ILocator datePicker, string yyyy, string mm, string dd)
        {
            string date;

            switch(TestContext.Parameters["Browser"])
            {
                case BrowserNames.firefox:
                    date = $"{yyyy}-{mm}-{dd}";
                    break;

                default:
                    date = $"{dd}/{mm}/{yyyy}";
                    break;
            }

            await datePicker.TypeAsync(date);
            await _page.Keyboard.PressAsync("Enter");
        }

        protected async Task EnterDateIntoJsDatePicker(ILocator datePicker, string yyyy, string mm, string dd)
        {
            string date = $"{yyyy}-{mm}-{dd}";
            await ClearTextField(datePicker);

            await datePicker.TypeAsync(date);
            await _page.Keyboard.PressAsync("Enter");
        }

        protected async Task GoToUrl(bool isPageAccessTest, string subdirectoryName = "")
        {
            string destinationUrl = await _config.GetUrl(subdirectoryName);

            await _page.GotoAsync(destinationUrl);
            await WaitForPageLoad();


            if (!isPageAccessTest)
            {
                await AssertNavigatedToCorrectPage(destinationUrl);
            }
        }

        protected async Task AssertNavigatedToCorrectPage(string destinationUrl)
        {
            Assert.That(_page.Url.Contains(destinationUrl), $"Was not navigated to correct page{Environment.NewLine}Was navigated to {_page.Url}{Environment.NewLine}Should be {destinationUrl}");
        }

        protected void AssertNotNavigatedToPage(string destinationUrl)
        {
            Assert.False(_page.Url.Contains(destinationUrl), "Was navigated to page, even though they shouldn't have been :(");
        }

        public List<string> GetUserAuthorisedPagesList(string userType)
        {
            switch(userType)
            {
                case CredentialNames.accountAdministration:
                case CredentialNames.guestAccountAdministration:
                    return PageNames.GetAccountAdministrationAuthorisedPagesList();

                case CredentialNames.advancedConfiguration:
                case CredentialNames.guestAdvancedConfiguration:
                    return PageNames.GetAdvancedConfigurationAuthorisedPagesList();

                case CredentialNames.advancedEntry:
                case CredentialNames.guestAdvancedEntry:
                    return PageNames.GetAdvancedEntryAuthorisedPagesList();

                case CredentialNames.advancedReporting:
                case CredentialNames.guestAdvancedReporting:
                    return PageNames.GetAdvancedReportingAuthorisedPagesList();

                case CredentialNames.basicConfiguration:
                case CredentialNames.guestBasicConfiguration:
                    return PageNames.GetBasicConfigurationAuthorisedPagesList();

                case CredentialNames.dataEntry:
                case CredentialNames.guestDataEntry:
                    return PageNames.GetDataEntryAuthorisedPagesList();

                case CredentialNames.reporting:
                case CredentialNames.guestReporting:
                    return PageNames.GetReportingAuthorisedPagesList();

                case CredentialNames.revenue:
                case CredentialNames.guestRevenue:
                    return PageNames.GetRevenueAuthorisedPagesList();

                case CredentialNames.sysAdmin:
                    return PageNames.GetSysAdminAuthorisedPagesList();

                case CredentialNames.loggedOut:
                    return PageNames.GetLoggedOutAuthorisedPagesList();

                default:
                    throw new Exception("Can't get page list as userType is not a recognised type of user. How did you even do that?");
            }
        }

        public string[] GetModuleAuthorisedPagesList(string user)
        {
            ModuleAuthorisedPages _moduleAuthorisedPages = new ModuleAuthorisedPages();

            switch(user)
            {
                case CredentialNames.actionManagementModuleOnly:
                    return _moduleAuthorisedPages.BaseAuthorisedPages.Concat(_moduleAuthorisedPages.ActionManagementModuleAuthorisedPagesList).ToArray();

                case CredentialNames.connectSystemsIntegrationModuleOnly:
                    return _moduleAuthorisedPages.BaseAuthorisedPages.Concat(_moduleAuthorisedPages.ConnectSystemsIntegrationModuleAuthorisedPagesList).ToArray();

                case CredentialNames.gembaIntelligenceModuleOnly:
                    return _moduleAuthorisedPages.BaseAuthorisedPages.Concat(_moduleAuthorisedPages.GembaIntelligenceModuleAuthorisedPagesList).ToArray();

                case CredentialNames.oeeModuleOnly:
                    return _moduleAuthorisedPages.BaseAuthorisedPages.Concat(_moduleAuthorisedPages.OeeModuleAuthorisedPagesList).ToArray();

                case CredentialNames.plantConnectionModuleOnly:
                    return _moduleAuthorisedPages.BaseAuthorisedPages.Concat(_moduleAuthorisedPages.PlantConnectionModuleAuthorisedPagesList).ToArray();

                case CredentialNames.recipesModuleOnly:
                    return _moduleAuthorisedPages.BaseAuthorisedPages.Concat(_moduleAuthorisedPages.RecipesModuleAuthorisedPagesList).ToArray();

                case CredentialNames.revenueModuleOnly:
                    return _moduleAuthorisedPages.BaseAuthorisedPages.Concat(_moduleAuthorisedPages.RevenueModuleAuthorisedPagesList).ToArray();

                case CredentialNames.formsModuleOnly:
                    return _moduleAuthorisedPages.BaseAuthorisedPages.Concat(_moduleAuthorisedPages.FormsModuleAuthorisedPagesList).ToArray();

                default:
                    throw new Exception("Can't get page list as that user isn't recognised. Are you sure there isn't a typo, or that someone hasn't messed with your environment?");
            }
        }

        public async Task AssertUserAuthorisationLevelIsCorrectForPage(string destinationPage, string user)
        {
            List<string> _authorisedPagesList = GetUserAuthorisedPagesList(user);

            if (_authorisedPagesList.Contains(destinationPage))
            {
                Assert.That(_page.Url, Is.EqualTo(await _config.GetUrl(destinationPage)), $"{user} user can't access {destinationPage} page, but they should be able to");
            }
            else switch(user)
            {
                case CredentialNames.loggedOut:
                    Assert.That(_page.Url.StartsWith($"{await _config.GetUrl()}Account/Login?ReturnUrl=%2F"), $"{user} user has access to {destinationPage} page, but they should NOT");
                    return;

                default:
                Assert.That(_page.Url.StartsWith($"{await _config.GetUrl()}Account/AccessDenied?ReturnUrl=%2F"), $"{user} user has access to {destinationPage} page, but they should NOT");
                return;
            }
        }

        public async Task AssertModuleAuthorisationLevelIsCorrectForPage(string page, string user)
        {
            string[] _authorisedPagesList = GetModuleAuthorisedPagesList(user);

            if (_authorisedPagesList.Contains(page))
            {
                Assert.That(_page.Url, Is.EqualTo(await _config.GetUrl(page)), $"{user} user can't access {page} page, but the module level should allow it");
            }

            else switch (page)
            {
                case PageNames.manageAdmin:
                    Assert.That(_page.Url == ($"{await _config.GetUrl()}Account/AccessDenied?ReturnUrl=%2FAdmin%2FManageAdmin"));
                    return;

                case PageNames.manageTenants:
                    Assert.That(_page.Url == ($"{await _config.GetUrl()}Account/AccessDenied?ReturnUrl=%2FTenant"));
                    return;

                default:
                    Assert.That(_page.Url, Is.Not.EqualTo(await _config.GetUrl(page)), $"{user} user has access to {page} page, but they should NOT with their module level");

                    switch (user)
                    {
                        case CredentialNames.oeeModuleOnly:
                            Assert.That(_page.Url == $"{await _config.GetUrl()}OeeDashboard?redirect=True");
                            return;

                        case CredentialNames.actionManagementModuleOnly:
                            Assert.That(_page.Url == $"{await _config.GetUrl()}Action/MyActions?redirect=True");
                            return;

                        case CredentialNames.formsModuleOnly:
                            Assert.That(_page.Url == $"{await _config.GetUrl()}Forms/MyForms?redirect=True");
                            return;

                            default:
                            Assert.That(_page.Url == $"{await _config.GetUrl()}Manage/Profile?redirect=True");
                            return;
                    }
            }
        }

        protected async Task<IReadOnlyList<IElementHandle>> GetDropdownOptionsAsync(ILocator handleDropdown)
        {
            var optionList = await handleDropdown.ElementHandleAsync().Result.QuerySelectorAllAsync("option");
            return optionList;
        }

        protected async Task SelectDropDownOptionByText(ILocator handleDropdown, string optionToSelect)
        {
            await handleDropdown.SelectOptionAsync(optionToSelect);
        }

        protected async Task SelectDropDownOptionByIndex(ILocator handleDropdown, int optionIndex)
        {
            await handleDropdown.EvaluateAsync($"(select) => select.selectedIndex = {optionIndex};");
        }

        public async Task SelectAssetPickerCheckBox(ILocator branch)
        {
            var checkbox = branch.Locator("i[class='jstree-icon jstree-checkbox']");
            await checkbox.ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        protected async Task<IElementHandle> GetAssetPickerTree()
        {
            IReadOnlyList<IElementHandle> tree = new List<IElementHandle>();

            IReadOnlyList<IElementHandle> possibleTrees1 = await _page.QuerySelectorAllAsync("css=div[id='Asset']");
            IReadOnlyList<IElementHandle> possibleTrees2 = await _page.QuerySelectorAllAsync("css=div[class='form-group tree-viewport']");

            tree = possibleTrees1.Concat(possibleTrees2).ToList();
            return tree[0];
        }

        protected async Task<IReadOnlyList<IElementHandle>> GetAllAssetTreeBranches()
        {
            IElementHandle tree = await GetAssetPickerTree();
            IReadOnlyList<IElementHandle> allBranches = await tree.QuerySelectorAllAsync("css=li[role='treeitem'][aria-expanded]");
                
            return allBranches;
        }

        protected async Task<IElementHandle> GetAssetTreeBranch(string branchName)
        {
            IReadOnlyList<IElementHandle> allBranches = await GetAllAssetTreeBranches();
            IElementHandle desiredBranch = null;
            foreach(IElementHandle branch in allBranches)
            {
                string innerText = await branch.InnerTextAsync();
                if (innerText == branchName)
                {
                    desiredBranch = branch;
                }
            }
            return desiredBranch;
        }

        protected async Task<IReadOnlyList<IElementHandle>> GetAllVisibleAssetTreeAssets()
        {
            IReadOnlyList<IElementHandle> allAssets = new List<IElementHandle>();
            IElementHandle tree = await GetAssetPickerTree();
            IReadOnlyList<IElementHandle> leaves = await tree.QuerySelectorAllAsync("css=li[class$='jstree-leaf']");
            IReadOnlyList<IElementHandle> lastLeaves = await tree.QuerySelectorAllAsync("css=li[class$='jstree-last']");

            allAssets = leaves.Concat(lastLeaves).ToList();
            return allAssets;
        }

        public async Task<IElementHandle> GetAssetTreeAsset(string assetName)
        {
            IReadOnlyList<IElementHandle> allAssets = await GetAllVisibleAssetTreeAssets();
            IElementHandle desiredAsset = null;
            foreach(IElementHandle asset in allAssets)
            {
                string innerText = await asset.InnerTextAsync();
                if (innerText == assetName)
                {
                    desiredAsset = asset;
                }
            }
            return desiredAsset;
        }

        public async Task SelectAssetTreeAsset(string assetName)
        {
            IElementHandle asset = await GetAssetTreeAsset(assetName);
            IElementHandle assetLink = await asset.QuerySelectorAsync("css=a[id$='_anchor']");

            await assetLink.ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        public async Task ExpandAssetTreeBranch(string branchName)
        {
            IElementHandle branchToExpand = await GetAssetTreeBranch(branchName);
            IElementHandle branchLink = await branchToExpand.QuerySelectorAsync("css=i[class='jstree-icon jstree-ocl']");

            await branchLink.ClickAsync();
        }

        public async Task SelectAssetTreeAssetCheckBox(string assetName)
        {
            IElementHandle asset = await GetAssetTreeAsset(assetName);
            IElementHandle assetCheckbox = await asset.QuerySelectorAsync("i[class='jstree-icon jstree-checkbox']");

            await assetCheckbox.ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        public async Task SelectAssetTreeBranchCheckBox(string branchName)
        {
            IElementHandle branch = await GetAssetTreeBranch(branchName);
            IElementHandle branchCheckbox = await branch.QuerySelectorAsync("i[class='jstree-icon jstree-checkbox']");

            await branchCheckbox.ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        protected async Task ClearTextField(ILocator locatorTextField)
        {
            await locatorTextField.FillAsync("");
        }

        protected string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }

        public async Task AssertElementIsNotPresent(ILocator locatorElement)
        {
            var pageTest = new PageTest();
            await pageTest.Expect(locatorElement).ToBeHiddenAsync();
        }

        public async Task AssertElementIsPresent(ILocator locatorElement)
        {
            var pageTest = new PageTest();
            await pageTest.Expect(locatorElement).ToBeVisibleAsync();
        }

        public async Task AssertElementIsDisabled(ILocator locatorElement)
        {
            var pageTest = new PageTest();
            await pageTest.Expect(locatorElement).ToBeDisabledAsync();
        }

        public async Task AssertElementIsEnabled(ILocator locatorElement)
        {
            var pageTest = new PageTest();
            await pageTest.Expect(locatorElement).ToBeEnabledAsync();
        }

        public async Task AssertAssetIsNotVisibleInTree(string assetName)
        {
            var tree = await GetAllVisibleAssetTreeAssets();
            IList<IElementHandle> unwantedAssets = new List<IElementHandle>();
            foreach(IElementHandle asset in tree)
            {
                if(await asset.InnerTextAsync() == assetName)
                {
                    unwantedAssets.Add(asset);
                }
            }

            Assert.That(unwantedAssets.Count == 0);
        }

        public async Task AssertAssetIsVisibleInTree(string assetName)
        {
            var tree = await GetAllVisibleAssetTreeAssets();
            IList<IElementHandle> desiredAsset = new List<IElementHandle>();
            foreach (IElementHandle asset in tree)
            {
                if (await asset.InnerTextAsync() == assetName)
                {
                    desiredAsset.Add(asset);
                }
            }

            Assert.That(desiredAsset.Count == 1);
        }

        protected async Task<IReadOnlyList<IElementHandle>> GetTable(string tableDataBind = "", string rowDataBind = "")
        {
            await _page.Locator($"css=tbody[data-bind='{tableDataBind}']").WaitForAsync();
            var table = await _page.QuerySelectorAsync($"css=tbody[data-bind='{tableDataBind}']");
            var rows = await table.QuerySelectorAllAsync($"css=tr:nth-child(1)[data-bind~='{rowDataBind}']");

            return rows;
        }

        protected async Task<IElementHandle> GetTableRow(IReadOnlyList<IElementHandle> table, int rowIndex)
        {
            var row = table[rowIndex];

            return row;
        }

        protected async Task ExpandTableRow(IReadOnlyList<IElementHandle> table, int rowIndex)
        {
            var row = await GetTableRow(table, rowIndex);
            var chevron = await row.QuerySelectorAsync("i[class='expand-icon fa fa-lg fa-chevron-down']");

            await chevron.ClickAsync();
        }

        public async Task AssertUserCanAccessAllPages(bool isAdminUser = false)
        {
            if (isAdminUser)
            {
                foreach(string page in PageNames.GetAllPageNamesMinusLoginPage())
                {
                    await GoToUrl(false, page);
                }
            }
            else
            {
                foreach(string page in PageNames.GetAllPageNamesMinusAdminPagesAndLoginPage())
                {
                    await GoToUrl(false, page);
                }
            }
        }

        public async Task AssertUserCantAccessPages(List<string> pages)
        {
            foreach(string page in pages)
            {
                await _page.GotoAsync(_config.GetUrl(page).ToString());
                Assert.False(_page.Url == _config.GetUrl(page).ToString());
            }
        }

        protected async Task WaitForPageLoad()
        {
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        protected async Task<string> GetDifferenceMaskFilename(string expectedFilename)
        {
            return $"{expectedFilename.Split('.')[0]}DifferenceMask.{expectedFilename.Split('.')[1]}";
        }

        protected async Task CompareCurrentPageToScreenshot(string expectedFilename)
        {
            Thread.Sleep(10000);//this is because the charts take so long to draw... I hate it
            var bytes = await _page.ScreenshotAsync(new()
            {
                Path = $"{TestContext.Parameters["ScreenshotSaveLocation"]}screenshot.png",
            });

            var maskedDiff = ImageSharpCompare.CalcDiff($"{TestContext.Parameters["ScreenshotSaveLocation"]}screenshot.png", $"{TestContext.Parameters["ReferenceImagesLocation"]}{expectedFilename}", $"{TestContext.Parameters["ReferenceImagesLocation"]}{await GetDifferenceMaskFilename(expectedFilename)}");
            Assert.That(maskedDiff.PixelErrorPercentage, Is.LessThanOrEqualTo(1));
        }

        public async Task ScrollToBottomOfPage()
        {
            await _page.Mouse.WheelAsync(0, _page.ViewportSize.Height);
        }
    }
}