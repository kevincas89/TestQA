using DemoSite.test;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSite
{
    public class UnitTestCheckBox
    {
        [Parallelizable(ParallelScope.Self)]
        [TestFixture]
        public class Tests : TestBases
        {
            [Test]
            public async Task GoToHomePageCheckBoxAndDeploy()
            {
                var DemoSite = new PagesObjects.CheckBoxPage(Page);

                await DemoSite.DeployAndCheck();
            }
        }
    }
}
