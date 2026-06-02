using Microsoft.Playwright;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;
using static DemoSite.PagesObjects.ButtonPage;

namespace DemoSite.PagesObjects
{
    public class LinksPage
    {
        private readonly IPage _page;
        public readonly LinksPageMap Map;

        public LinksPage(IPage page)
        {
            _page = page;
            Map = new LinksPageMap(page);
        }

        public async Task AccessWebLink()
        {
            await Map.ElementsBtn.ClickAsync();
            await Map.WebLinksBtn.ClickAsync();
        }

        /*public async Task TestApiCreate()
        {
            await Map.CreatedLink.ClickAsync();
        }*/

        public async Task<string> ClickLinkAndGetResponse(ILocator link)
        {
            await link.ClickAsync();
            return await Map.LinkResponseMessage.InnerTextAsync();
        }

        public class LinksPageMap(IPage page)
        {
            //found text Elements
            public ILocator ElementsBtn => page.GetByText("Elements");
            //Click in Web Links
            public ILocator WebLinksBtn => page.GetByRole(AriaRole.Link, new() { Name = "Links", Exact = true });
            #region LinksApi
            public ILocator CreatedLink => page.GetByRole(AriaRole.Link, new() { Name = "Created" });
            public ILocator NoContentLink => page.GetByRole(AriaRole.Link, new() { Name = "No Content" });
            public ILocator MovedLink => page.GetByRole(AriaRole.Link, new() { Name = "Moved" });
            public ILocator BadRequestLink => page.GetByRole(AriaRole.Link, new() { Name = "Bad Request" });
            public ILocator UnauthorizedLink => page.GetByRole(AriaRole.Link, new() { Name = "Unauthorized" });
            public ILocator ForbiddenLink => page.GetByRole(AriaRole.Link, new() { Name = "Forbidden" });
            public ILocator NotFoundLink => page.GetByRole(AriaRole.Link, new() { Name = "Not Found" });
            #endregion
            public ILocator LinkResponseMessage => page.Locator("#linkResponse");
        }
    }
}
