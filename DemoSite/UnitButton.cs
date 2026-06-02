using DemoSite.Factory;
using DemoSite.test;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSite
{
    public class UnitButton
    {
        [Parallelizable(ParallelScope.Self)]
        [TestFixture]
        public class Tests : TestBases
        {
            [Test]
            public async Task AccessWebButtonsAndClick()
            {
                var DemoSite = new PagesObjects.ButtonPage(Page);
                await DemoSite.GotoWebButtonsAndClick();
                Assert.That(await DemoSite.Map.DoubleClickMessage.IsVisibleAsync(), Is.True);
                Assert.That(await DemoSite.Map.RightClickMessage.IsVisibleAsync(), Is.True);
                Assert.That(await DemoSite.Map.SingleClickMessage.IsVisibleAsync(), Is.True);
            }
        }
    }
}
