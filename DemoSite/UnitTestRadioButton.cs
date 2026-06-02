using DemoSite.test;
using Microsoft.Playwright;


namespace DemoSite
{
    public class UnitTestRadioButton
    {
        [Parallelizable(ParallelScope.Self)]
        [TestFixture]
        public class Tests : TestBases
        {
            [Test]
            public async Task CheckInRadioButtonAndVerificatedMessageYes()
            {
                var DemoSite = new PagesObjects.RadioButtonPage(Page);

                await DemoSite.GotoRadioButtonAndCheck();
                await DemoSite.CheckYesRadio();
                await Assertions.Expect(DemoSite.Map.SelectedYesMessage).ToBeVisibleAsync();
            }

            [Test]
            public async Task CheckInRadioButtonAndVerificatedMessageImpressive()
            {
                var DemoSite = new PagesObjects.RadioButtonPage(Page);

                await DemoSite.GotoRadioButtonAndCheck();
                await DemoSite.CheckImpressiveRadio();
                await Assertions.Expect(DemoSite.Map.SelectedImpressiveMessage).ToBeVisibleAsync();
            }
        }
    }
}
