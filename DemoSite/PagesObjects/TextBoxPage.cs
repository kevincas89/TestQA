using DemoSite.DTO;
using Microsoft.Playwright;


namespace DemoSite.PagesObjects
{
    public class TextBoxPage
    {
        IPage _page;
        public readonly TextBoxPageMap Map;

        public TextBoxPage(IPage page)
        {
            this._page = page;
            Map = new TextBoxPageMap(page);
        }

        public async Task ClickElementsBtn()
        {
            await Map.ElementsBtn.ClickAsync();
        }

        public async Task ClickTextBoxAndFillForm(TextBoxDTO dto)
        {
            await Map.TextBoxBtn.ClickAsync();
            await Map.BoxFullName.FillAsync(dto.FullName);
            await Map.BoxEmail.FillAsync(dto.Email);
            await Map.BoxCurrentAddres.FillAsync(dto.CurrentAddress);
            await Map.BoxPermanentAddress.FillAsync(dto.PermanentAddress);
            await Map.BtnSubmit.ClickAsync();
        }

        public async Task<DTOTextBoxResult> GetFormOutput(TextBoxDTO dto)
        {
            return new DTOTextBoxResult
            {
                FullName = await Map.FoundNameText(dto.FullName).InnerTextAsync(),
                Email = await Map.FoundEmailText(dto.Email).InnerTextAsync(),
                CurrentAddress = await Map.FoundCurrentAddressText(dto.CurrentAddress).InnerTextAsync(),
                PermanentAddress = await Map.FoundPermanentAddressText(dto.PermanentAddress).InnerTextAsync()
            };
        }

        public class TextBoxPageMap(IPage page)
        {
            //found text Elements
            public ILocator ElementsBtn => page.GetByText("Elements");
            //found textBox and fill the form
            public ILocator TextBoxBtn => page.GetByRole(AriaRole.Link, new() { Name = "Text Box" });
            public ILocator BoxFullName => page.GetByPlaceholder("Full Name");
            public ILocator BoxEmail => page.GetByPlaceholder("name@example.com");
            public ILocator BoxCurrentAddres => page.GetByPlaceholder("Current Address");
            public ILocator BoxPermanentAddress => page.Locator("#permanentAddress");
            public ILocator BtnSubmit => page.GetByRole(AriaRole.Button, new() { Name = "Submit" });

            public ILocator FoundNameText(string name) => page.GetByText($"Name:{name}");
            public ILocator FoundEmailText(string email) => page.GetByText($"Email:{email}");
            public ILocator FoundCurrentAddressText(string currentAddress) =>
                page.GetByText($"Current Address :{currentAddress}");

            public ILocator FoundPermanentAddressText(string permanentAddress) =>
                page.GetByText($"Permananet Address :{permanentAddress}");
        }

    }
}
