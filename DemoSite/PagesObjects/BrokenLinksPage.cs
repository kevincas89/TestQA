using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using static DemoSite.PagesObjects.LinksPage;

namespace DemoSite.PagesObjects
{
    public class BrokenLinksPage
    {
        private readonly IPage _page;
        public readonly BrokenLinksPageMap Map;

        public BrokenLinksPage(IPage page)
        {
            _page = page;
            Map = new BrokenLinksPageMap(page);
        }

        public async Task GotoWebBrokenLinks()
        {
            await Map.ElementsBtn.ClickAsync();
            await Map.BrokenLinksBtn.ClickAsync();
        }

        public async Task CheckValidLink()
        {
            await Map.ValidLink.ClickAsync();
        }

        public async Task CheckBrokenLink()
        {
            await Map.BrokenLink.ClickAsync();
        }

        public async Task<string> GetCurrentUrl()
        {
            return _page.Url;
        }

        public class BrokenLinksPageMap(IPage page)
        {
            //found text Elements
            public ILocator ElementsBtn => page.GetByText("Elements");
            //Click in Web Links
            public ILocator BrokenLinksBtn => page.GetByRole(AriaRole.Link, new() { Name = "Broken Links - Images", Exact = true });
            public ILocator ValidLink => page.GetByRole(AriaRole.Link, new() { Name = "Click Here for Valid Link" });
            public ILocator BrokenLink => page.GetByRole(AriaRole.Link, new() { Name = "Click Here for Broken Link" });
        }
    }
}
