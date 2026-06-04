using DemoSite.test;


namespace DemoSite
{
    public class UnitBrowserWindows
    {
        [Parallelizable(ParallelScope.Self)]
        [TestFixture]

        public class Tests : TestBases
        {
            [Test]
            public async Task VerifyNewTab()
            {
                var DemoSite = new PagesObjects.BrowserWindowsPage(Page);

                await DemoSite.AccessToWebAndClickOnBrowserWindows();

                var newTab = await DemoSite.ClickNewTab();
                await newTab.WaitForLoadStateAsync();

                Assert.That(newTab.Url, Does.Contain("sample"));
            }

            [Test]
            public async Task VerifyNewWindows()
            {
                var DemoSite = new PagesObjects.BrowserWindowsPage(Page);

                await DemoSite.AccessToWebAndClickOnBrowserWindows();

                var newTab = await DemoSite.ClickNewWindow();
                await newTab.WaitForLoadStateAsync();

                Assert.That(newTab.Url, Does.Contain("sample"));
            }

            [Test]
            public async Task VerifyNewWindowMessage()
            {
                var DemoSite = new PagesObjects.BrowserWindowsPage(Page);
                await DemoSite.AccessToWebAndClickOnBrowserWindows();

                var newWindow = await DemoSite.ClickNewWindowMessage();
                await newWindow.WaitForLoadStateAsync();

                var message = await newWindow.Locator("body").InnerTextAsync();
                Assert.That(message, Does.Contain("Knowledge increases by sharing but not by saving"));
            }
        }
    }
}
