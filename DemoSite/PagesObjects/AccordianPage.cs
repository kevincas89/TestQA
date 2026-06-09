using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using static DemoSite.PagesObjects.AlertsPage;

namespace DemoSite.PagesObjects
{
    public class AccordianPage
    {
        private readonly IPage _page;
        public readonly AccordianPageMap Map;

        public AccordianPage(IPage page)
        {
            _page = page;
            Map = new AccordianPageMap(page);
        }

        public async Task AccessWidgets()
        {
            await Map.WidgetsBtn.ClickAsync();
            await Map.AccordianBtn.ClickAsync();
        }

        public async Task<bool> IsAccordionExpanded(ILocator accordion)
        {
            var value = await accordion.GetAttributeAsync("aria-expanded");
            return value == "true";
        }

        public class AccordianPageMap(IPage page)
        {

            //Click in Widgets
            public ILocator WidgetsBtn => page.GetByText("Widgets");
            //Click in Accordian
            public ILocator AccordianBtn => page.GetByText("Accordian");

            #region Accordian
            public ILocator FirstSection => page.GetByRole(AriaRole.Button, new() { Name = "What is Lorem Ipsum?" });
            public ILocator SecoundSection => page.GetByRole(AriaRole.Button, new() { Name = "Where does it come from?" });
            public ILocator ThirdSection => page.GetByRole(AriaRole.Button, new() { Name = "Why do we use it?" });
            #endregion
        }
    }
}
