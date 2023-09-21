namespace GembaCloud.PlaywrightTests.Pages
{
    public class TenMinuteMail : BasePage
    {
        private IPage _page;
        public ILocator locatorCopyEmailAddressButton;
        public ILocator locatorEmailAddressField;
        public ILocator locatorGembaConfirmationEmailRow;
        public ILocator locatorPopupAdDismissButton;
        public ILocator locatorAccountConfirmationLink;
        public string currentEmailAddress;

        public TenMinuteMail(IPage page) : base(page)
        {
            _page = page;
            locatorCopyEmailAddressButton = _page.Locator("button[id='copy-button']");
            locatorEmailAddressField = _page.Locator("input[class='mailtext']");
            locatorGembaConfirmationEmailRow = _page.Locator("css=a:contains('admin@gemba4cloud.com')");
            locatorPopupAdDismissButton = _page.Locator("#dismiss-button");
            locatorAccountConfirmationLink = _page.GetByRole(AriaRole.Link, new() { Name = "here" }).First;
        }

        public async Task GoToTenMinuteMail()
        {
            await _page.GotoAsync("https://10minutemail.net/");
        }

        public async Task CopyEmailAddress()
        {
            await locatorCopyEmailAddressButton.ClickAsync();
        }

        public async Task<string> GetEmailAddress()
        {
            return await locatorEmailAddressField.GetAttributeAsync("value");
        }

        public async Task ClickGembaConfirmationEmailRow()
        {
            await GetGembaConfirmationEmail().Result.ClickAsync();
        }

        public async Task DismissPopupAdvert()
        {
            //ok, this is pretty hacky but it works fo now. If it causes issues, I may have to look for another email solution
            await _page.GotoAsync("https://10minutemail.net/");
            await ClickGembaConfirmationEmailRow();
        }

        public async Task ClickAccountConfirmationLink()
        {
            await locatorAccountConfirmationLink.ClickAsync();
        }

        public async Task<IElementHandle> GetGembaConfirmationEmail()
        {
            await WaitUntilEmailsHaveArrived(2);
            var allEmails = await _page.QuerySelectorAllAsync("#maillist > tbody > tr > td > a");

            foreach (var email in allEmails)
            {
                if (await email.InnerTextAsync() == "\"Gemba 4.0. Cloud-DoNotReply\" <admin@gemba4cloud.com>")
                {
                    return email;
                }
            }

            throw new Exception("No such email exists");
        }

        public async Task WaitUntilEmailsHaveArrived(int numberOfEmails)//remember that this service always emails you once
        {
            for (int i = 0; i < 20; i++)
            {
                var allEmails = await _page.QuerySelectorAllAsync("#maillist > tbody > tr > td > a");

                if (allEmails.Count < numberOfEmails*3)//multiplied by 3 because this queries the number of cells, rather than rows
                {
                    Thread.Sleep(30000);
                }
                else
                {
                    return;
                }
            }
            throw new Exception("Not enough emails have arrived within 10 minutes");
        }
    }
}