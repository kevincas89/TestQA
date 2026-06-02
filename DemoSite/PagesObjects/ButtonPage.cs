using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using static DemoSite.PagesObjects.WebTablesPage;

namespace DemoSite.PagesObjects
{
    public class ButtonPage
    {
        private readonly IPage _page;
        public readonly ButtonPageMap Map;

        public ButtonPage(IPage page)
        {
            _page = page;
            Map = new ButtonPageMap(page);
        }

        public async Task GotoWebButtonsAndClick()
        {
            await Map.ElementsBtn.ClickAsync();
            await Map.WebButtonsBtn.ClickAsync();
            await Map.DoubleClickBtn.DblClickAsync();
            await Map.RightClickBtn.ClickAsync(new() { Button = MouseButton.Right });
            await Map.OneClickBtn.ClickAsync();
        }

        public class ButtonPageMap (IPage page)
        {
            //found text Elements
            public ILocator ElementsBtn => page.GetByText("Elements");
            //Click in Web Buttons
            public ILocator WebButtonsBtn => page.GetByRole(AriaRole.Link, new() { Name = "Buttons" });
            #region Buttons
            public ILocator DoubleClickBtn => page.GetByRole(AriaRole.Button, new() { Name = "Double Click Me" });
            public ILocator RightClickBtn => page.GetByRole(AriaRole.Button, new() { Name = "Right Click Me" });
            public ILocator OneClickBtn => page.GetByRole(AriaRole.Button, new() { Name = "Click Me", Exact = true });
            #endregion
            #region Messages
            public ILocator DoubleClickMessage => page.GetByText("You have done a double click");
            public ILocator RightClickMessage => page.GetByText("You have done a right click");
            public ILocator SingleClickMessage => page.GetByText("You have done a dynamic click");
            #endregion
        }
    }
}
