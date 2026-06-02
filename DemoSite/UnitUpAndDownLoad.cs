using DemoSite.test;
using DemoSite.TestData;

namespace DemoSite
{
    public class UnitUpAndDownLoad
    {
        [Parallelizable(ParallelScope.Self)]
        [TestFixture]

        public class Tests : TestBases
        {
            [Test]
            public async Task GotoWebUpAndDownLoadAndCheckDownload()
            {
                var DemoSite = new PagesObjects.UpAndDownLoadPage(Page);

                await DemoSite.NavigateWeb();

                var fileName = await DemoSite.DownloadFile();

                Assert.That(fileName, Does.Contain("sampleFile"));
            }

            [Test]
            public async Task GotoWebUpAndDownLoadAndCheckUpload()
            {
                var DemoSite = new PagesObjects.UpAndDownLoadPage(Page);

                await DemoSite.NavigateWeb();

                await DemoSite.UploadFile(Paths.UploadFile);

                var uploadedFileName = await DemoSite.GetUploadedFileName();

                Assert.That(uploadedFileName, Does.Contain("file.txt"));
            }
        }
    }
}
    