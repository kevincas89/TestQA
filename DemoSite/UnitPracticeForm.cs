using DemoSite.Factory;
using DemoSite.test;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSite
{
    public class UnitPracticeForm
    {
        [Parallelizable(ParallelScope.Self)]
        [TestFixture]

        public class Tests: TestBases
        {
            [Test]
            public async Task AccessWebPracticeForms()
            {
                var DemoSite = new PagesObjects.PracticeFromPage(Page);

                await DemoSite.ClickFormsBtnAndPracticeFormsButton();

                var defaultUser = FactoryDTOPracticeForm.Default;

                await DemoSite.FillTextForm(defaultUser);

                await DemoSite.FillDateOfBirth(defaultUser);
            }
        }
    }
}
