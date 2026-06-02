using DemoSite.test;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSite
{
    public class UnitBrokenLinks
    {
        [Parallelizable(ParallelScope.Self)]
        [TestFixture]
        public class Tests: TestBases
        {
            [Test]
            public async Task GotoWebBrokenLinksAndCheckLinkBad()
            {
                var DemoSite = new PagesObjects.BrokenLinksPage(Page);

                await DemoSite.GotoWebBrokenLinks();

                await DemoSite.CheckValidLink();

                Assert.That(Page.Url, Does.Contain("demoqa.com"));
            }

            [Test]
            public async Task GotoWebBrokenLinksAndCheckLinkBroken()
            {
                var DemoSite = new PagesObjects.BrokenLinksPage(Page);

                await DemoSite.GotoWebBrokenLinks();

                await DemoSite.CheckBrokenLink();

                Assert.That(Page.Url, Does.Contain("status_codes/500"));
            }
        }
    }
}
