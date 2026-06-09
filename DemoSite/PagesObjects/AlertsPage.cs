using Microsoft.Playwright;

namespace DemoSite.PagesObjects
{
    public class AlertsPage
    {
        private readonly IPage _page;
        public readonly AlertsPageMap Map;

        public AlertsPage(IPage page)
        {
            _page = page;
            Map = new AlertsPageMap(page);
        }

        public async Task AccessWebAndAlerts()
        {
            await Map.AlertFrameWindowsBtn.ClickAsync();
            await Map.AlertsBtn.ClickAsync();
        }

        public async Task ClickAlertAndAccept()
        {
            _page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await Map.SeeAlertBtn.ClickAsync();
        }

        public async Task ClickTimerAlertAndAccept()
        {
            _page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await Map.TimerAlertBtn.ClickAsync();
            await _page.WaitForTimeoutAsync(6000);
        }

        public async Task ClickConfirmAndAccept()
        {
            _page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await Map.ConfirmBtn.ClickAsync();
        }

        public async Task ClickConfirmAndDismiss()
        {
            _page.Dialog += async (_, dialog) => await dialog.DismissAsync();
            await Map.ConfirmBtn.ClickAsync();
        }

        public async Task ClickPromptAndFill(string text)
        {
            _page.Dialog += async (_, dialog) => await dialog.AcceptAsync(text);
            await Map.PromptBtn.ClickAsync();
        }

        public class AlertsPageMap(IPage page)
        {
            //Click in Alerts, Frame & Windows
            public ILocator AlertFrameWindowsBtn => page.GetByText("Alerts, Frame & Windows");
            //Click in Web Alerts
            public ILocator AlertsBtn => page.GetByRole(AriaRole.Link, new() { Name = "Alerts", Exact = true });
            public ILocator SeeAlertBtn => page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).Nth(0);
            public ILocator TimerAlertBtn => page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).Nth(1);
            public ILocator ConfirmBtn => page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).Nth(2);
            public ILocator PromptBtn => page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).Nth(3);

            public ILocator ConfirmResult => page.Locator("#confirmResult");
            public ILocator PromptResult => page.Locator("#promptResult");
        }
    }
}
