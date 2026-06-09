using DemoSite.test;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSite
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class UnitAccordian
    {
        public class Tests : TestBases
        {
            [Test]
            public async Task VerifyAccordian()
            {
                var DemoSite = new PagesObjects.AccordianPage(Page);

                await DemoSite.AccessWidgets();

                //Verfy first section is expanded
                Assert.That(await DemoSite.IsAccordionExpanded(DemoSite.Map.FirstSection), Is.True);

                //Close first section
                await DemoSite.Map.FirstSection.ClickAsync();
                Assert.That(await DemoSite.IsAccordionExpanded(DemoSite.Map.FirstSection), Is.False);

                //open secound section
                await DemoSite.Map.SecoundSection.ClickAsync();
                Assert.That(await DemoSite.IsAccordionExpanded(DemoSite.Map.SecoundSection), Is.True);

                //Close secound section
                await DemoSite.Map.SecoundSection.ClickAsync();
                Assert.That(await DemoSite.IsAccordionExpanded(DemoSite.Map.SecoundSection), Is.False);

                //open third section
                await DemoSite.Map.ThirdSection.ClickAsync();
                Assert.That(await DemoSite.IsAccordionExpanded(DemoSite.Map.ThirdSection), Is.True);

                //Close third section
                await DemoSite.Map.ThirdSection.ClickAsync();
                Assert.That(await DemoSite.IsAccordionExpanded(DemoSite.Map.ThirdSection), Is.False);

            }
        }
    }
}
