namespace GembaCloud.PlaywrightTests.TestClasses
{
    public class DriverFactory
    {
        private IBrowser _browser;
        private IPlaywright _playwright;

        public IBrowser BrowserDriver(string browserName, bool headlessState = true)
        {
            switch (browserName)
            {
                case BrowserNames.chromium:
                    _browser = ChromiumDriver(headlessState);
                    break;

                case BrowserNames.webkit:
                    _browser = WebkitDriver(headlessState);
                    break;

                case BrowserNames.firefox:
                    _browser = FirefoxDriver(headlessState);
                    break;

                default:
                    throw new Exception("An unknown browser type has been requested");
            }

            return _browser;
        }
        
        //TODO: should be an if, you wally
        private IBrowser ChromiumDriver(bool headlessState = true)
        {
            _playwright = Playwright.CreateAsync().GetAwaiter().GetResult();

            switch (headlessState)
            {
                case true:
                    _browser = _playwright.Chromium.LaunchAsync().GetAwaiter().GetResult();
                    break;

                case false:
                    var options = new BrowserTypeLaunchOptions
                    {
                        Headless = false
                    };

                    _browser = _playwright.Chromium.LaunchAsync(options).GetAwaiter().GetResult();
                    break;
            }

            return _browser;
        }

        private IBrowser FirefoxDriver(bool headlessState = true)
        {
            _playwright = Playwright.CreateAsync().GetAwaiter().GetResult();

            switch (headlessState)
            {
                case true:
                    _browser = _playwright.Firefox.LaunchAsync().GetAwaiter().GetResult();
                    break;

                case false:
                    var options = new BrowserTypeLaunchOptions
                    {
                        Headless = false
                    };

                    _browser = _playwright.Firefox.LaunchAsync(options).GetAwaiter().GetResult();
                    break;
            }

            return _browser;
        }

        private IBrowser WebkitDriver(bool headlessState = true)
        {
            _playwright = Playwright.CreateAsync().GetAwaiter().GetResult();

            switch (headlessState)
            {
                case true:
                    _browser = _playwright.Webkit.LaunchAsync().GetAwaiter().GetResult();
                    break;

                case false:
                    var options = new BrowserTypeLaunchOptions
                    {
                        Headless = false
                    };

                    _browser = _playwright.Webkit.LaunchAsync(options).GetAwaiter().GetResult();
                    break;
            }

            return _browser;
        }
    }
}