using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSite.test
{
    public class TestBases
    {
        private IPlaywright _playwright;
        public IBrowser Browser;
        public IBrowserContext Context;
        public IPage Page;

        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Playwright.CreateAsync();

            Browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,  // true para correr sin interfaz
                SlowMo = 500       // ms entre acciones, útil para debug
            });

            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();

            await Page.GotoAsync("https://demoqa.com/");
        }

        [TearDown]
        public async Task TearDown()
        {
            await Context.CloseAsync();
            await Browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}
