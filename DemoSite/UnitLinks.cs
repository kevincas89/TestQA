using DemoSite.test;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSite
{
    public class UnitLinks
    {
        [Parallelizable(ParallelScope.Self)]
        [TestFixture]
        public class Tests : TestBases
        {
            [Test]
            public async Task AccessWebLinksAndCheckApiCreate()
            {
                var DemoSite = new PagesObjects.LinksPage(Page);

                await DemoSite.AccessWebLink();

                var response = await DemoSite.ClickLinkAndGetResponse(DemoSite.Map.CreatedLink);

                Assert.That(response, Does.Contain("201"));
                Assert.That(response, Does.Contain("Created"));
            }

            [Test]
            public async Task AccessWebLinksAndCheckApiNoContent()
            {
                var DemoSite = new PagesObjects.LinksPage(Page);

                await DemoSite.AccessWebLink();

                var response = await DemoSite.ClickLinkAndGetResponse(DemoSite.Map.NoContentLink);

                Assert.That(response, Does.Contain("204"));
                Assert.That(response, Does.Contain("No Content"));
            }

            [Test]
            public async Task AccessWebLinksAndCheckApiMoved()
            {
                var Demosite = new PagesObjects.LinksPage(Page);

                await Demosite.AccessWebLink();

                var response = await Demosite.ClickLinkAndGetResponse(Demosite.Map.MovedLink);

                Assert.That(response, Does.Contain("301"));
                Assert.That(response, Does.Contain("Moved Permanently"));
            }

            [Test]
            public async Task AccessWebLinksAndCheckApiBadRequest()
            {
                var Demosite = new PagesObjects.LinksPage(Page);

                await Demosite.AccessWebLink();

                var response = await Demosite.ClickLinkAndGetResponse(Demosite.Map.BadRequestLink);

                Assert.That(response, Does.Contain("400"));
                Assert.That(response, Does.Contain("Bad Request"));
            }

            [Test]
            public async Task AccessWebLinksAndCheckApiUnauthorized()
            {
                var Demosite = new PagesObjects.LinksPage(Page);

                await Demosite.AccessWebLink();

                var response = await Demosite.ClickLinkAndGetResponse(Demosite.Map.UnauthorizedLink);

                Assert.That(response, Does.Contain("401"));
                Assert.That(response, Does.Contain("Unauthorized"));
            }

            [Test]
            public async Task AccessWebLinksAndCheckApiForbidden()
            {
                var Demosite = new PagesObjects.LinksPage(Page);

                await Demosite.AccessWebLink();

                var response = await Demosite.ClickLinkAndGetResponse(Demosite.Map.ForbiddenLink);

                Assert.That(response, Does.Contain("403"));
                Assert.That(response, Does.Contain("Forbidden"));
            }

            [Test]
            public async Task AccessWebLinksAndCheckApiNotFound()
            {
                var Demosite = new PagesObjects.LinksPage(Page);

                await Demosite.AccessWebLink();

                var response = await Demosite.ClickLinkAndGetResponse(Demosite.Map.NotFoundLink);

                Assert.That(response, Does.Contain("404"));
                Assert.That(response, Does.Contain("Not Found"));
            }
        }
    }
}
