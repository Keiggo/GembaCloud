namespace GembaCloud.PlaywrightTests.Pages
{
    public class ActionDashboardPage : BasePage
    {
        private IPage _page;

        public ActionDashboardPage(IPage page) : base(page)
        {
            _page = page;
        }

        public async Task GoToActionDashboardPage(bool isPageAccessTest = false)
        {
            await GoToUrl(isPageAccessTest, PageNames.actionDashboard);
        }

        public async Task AssertActionCardIsPresent(string actionTitle)
        {
            var allActionCards = await _page.QuerySelectorAllAsync("div.action-card");
            IElementHandle desiredCard = null;

            foreach (var card in allActionCards)
            {
                if (await card.QuerySelectorAsync("div[class='title']").Result.InnerTextAsync() == actionTitle)
                {
                    desiredCard = card;
                    break;
                }
                break;
            }
            Assert.That(desiredCard, Is.Not.Null);
        }
    }
}