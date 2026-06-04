using Microsoft.Playwright;

namespace DemoSite.PagesObjects
{
    public class BrowserWindowsPage
    {
        private readonly IPage _page;
        public readonly BrowserWindowsPageMap Map;

        public BrowserWindowsPage(IPage page)
        {
            _page = page;
            Map = new BrowserWindowsPageMap(page);
        }
       
        public async Task AccessToWebAndClickOnBrowserWindows()
        {
            await Map.AlertFrameWindowsBtn.ClickAsync();
            await Map.BrowserWindowsBtn.ClickAsync();
        }

        public async Task<IPage> ClickNewTab()
        {
            var newPage = await _page.Context.RunAndWaitForPageAsync(async () =>
            {
                await Map.NewTabBtn.ClickAsync();
            });
            return newPage;
        }

        public async Task<IPage> ClickNewWindow()
        {
            var newPage = await _page.Context.RunAndWaitForPageAsync(async () =>
            {
                await Map.NewWindowBtn.ClickAsync();
            });
            return newPage;
        }

        public async Task<IPage> ClickNewWindowMessage()
        {
            var newPage = await _page.Context.RunAndWaitForPageAsync(async () =>
            {
                await Map.NewWindowMessageBtn.ClickAsync();
            });
            return newPage;
        }

        public class BrowserWindowsPageMap(IPage page)
        {
            //Click in Alerts, Frame & Windows
            public ILocator AlertFrameWindowsBtn => page.GetByText("Alerts, Frame & Windows");
            //Click in Web Browser Windows
            public ILocator BrowserWindowsBtn => page.GetByRole(AriaRole.Link, new() { Name = "Browser Windows", Exact = true });
            #region
            public ILocator NewTabBtn => page.GetByRole(AriaRole.Button, new() { Name = "New Tab" });
            public ILocator NewWindowBtn => page.GetByRole(AriaRole.Button, new() { Name = "New Window", Exact = true });
            public ILocator NewWindowMessageBtn => page.GetByRole(AriaRole.Button, new() { Name = "New Window Message" });
            #endregion
        }
    }
}