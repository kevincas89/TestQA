using DemoSite.test;

namespace DemoSite
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class UnitAlerts
    {
        public class Tests : TestBases
        {
            [Test]
            public async Task VerifyAlert()
            {
                var DemoSite = new PagesObjects.AlertsPage(Page);

                await DemoSite.AccessWebAndAlerts();

                await DemoSite.ClickAlertAndAccept();

            }

            [Test]
            public async Task VerfifyAlertTimer()
            {
                var DemoSite = new PagesObjects.AlertsPage(Page);

                await DemoSite.AccessWebAndAlerts();

                await DemoSite.ClickTimerAlertAndAccept();
            }

            [Test]
            public async Task VerifyAlertAcept()
            {
                var DemoSite = new PagesObjects.AlertsPage(Page);

                await DemoSite.AccessWebAndAlerts();

                await DemoSite.ClickConfirmAndAccept();

                await DemoSite.Map.ConfirmResult.WaitForAsync();
                var result = await DemoSite.Map.ConfirmResult.TextContentAsync();

                Assert.That(result, Does.Contain("Ok"));

            }

            [Test]
            public async Task VerifyAlertName()
            {
                var DemoSite = new PagesObjects.AlertsPage(Page);

                await DemoSite.AccessWebAndAlerts();

                await DemoSite.ClickPromptAndFill("Kevin");

                await DemoSite.Map.PromptResult.WaitForAsync();
                var resutl = await DemoSite.Map.PromptResult.TextContentAsync();

                Assert.That(resutl, Does.Contain("Kevin"));

            }
        }
    }
}