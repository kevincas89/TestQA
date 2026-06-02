using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using static DemoSite.PagesObjects.BrokenLinksPage;

namespace DemoSite.PagesObjects
{
    public class UpAndDownLoadPage
    {
        private readonly IPage _page;
        public readonly UpAndDownLoadPageMap Map;

        public UpAndDownLoadPage(IPage page)
        {
            _page = page;
            Map = new UpAndDownLoadPageMap(page);
        }

        public async Task NavigateWeb()
        {
            await Map.ElementsBtn.ClickAsync();
            await Map.UpAndDownLoadBtn.ClickAsync();
        }

        // Download - espera a que el archivo se descargue
        public async Task<string> DownloadFile()
        {
            var download = await _page.RunAndWaitForDownloadAsync(async () =>
            {
                await Map.DownloadBtn.ClickAsync();
            });

            // Retorna el nombre del archivo descargado
            return download.SuggestedFilename;
        }

        // Upload - sube un archivo por su ruta
        public async Task UploadFile(string filePath)
        {
            await Map.UploadInput.SetInputFilesAsync(filePath);
        }

        // Obtiene el nombre del archivo subido que muestra la página
        public async Task<string> GetUploadedFileName()
        {
            return await Map.UploadedFileName.InnerTextAsync();
        }

        public class UpAndDownLoadPageMap(IPage page)
        {
            //found text Elements
            public ILocator ElementsBtn => page.GetByText("Elements");
            //Click in Web Links
            public ILocator UpAndDownLoadBtn => page.GetByRole(AriaRole.Link, new() { Name = "Upload and Download", Exact = true });
            public ILocator DownloadBtn => page.GetByRole(AriaRole.Button, new() { Name = "Download" });
            public ILocator UploadInput => page.Locator("#uploadFile");
            public ILocator UploadedFileName => page.Locator("#uploadedFilePath");
        }
    }
}
