using Microsoft.Playwright;

namespace DemoSite.PagesObjects
{
    public class RadioButtonPage
    {
        private readonly IPage _page;
        public readonly RadioButtonPageMap Map;

        public RadioButtonPage(IPage page)
        {
            _page = page;
            Map = new RadioButtonPageMap(page);
        }

        public async Task GotoRadioButtonAndCheck()
        {
            await Map.ElementsBtn.ClickAsync();
            await Map.RadioButtonBtn.ClickAsync();
        }

        public async Task CheckYesRadio()
        {
            await Map.YesRadio.ClickAsync();
        }

        public async Task CheckImpressiveRadio()
        {
            await Map.ImpressiveRadio.ClickAsync();
        }


        public class RadioButtonPageMap(IPage page)
        {
            //found text Elements
            public ILocator ElementsBtn => page.GetByText("Elements");
            //Click in RadioButton
            public ILocator RadioButtonBtn => page.GetByRole(AriaRole.Link, new() { Name = "Radio Button" });
            // locators for the radio buttons
            public ILocator YesRadio => page.GetByRole(AriaRole.Radio, new() { Name = "Yes" });
            public ILocator ImpressiveRadio => page.GetByRole(AriaRole.Radio, new() { Name = "Impressive" });
            //public ILocator NoRadio => page.GetByRole(AriaRole.Radio, new() { Name = "No" });
            //Found Message of the selected radio button yes
            public ILocator SelectedYesMessage => page.Locator("p.mt-3 span.text-success", new() { HasText = "Yes" });
            public ILocator SelectedImpressiveMessage => page.Locator("p.mt-3 span.text-success", new() { HasText = "Impressive" });
        }
    }
}