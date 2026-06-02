using DemoSite.DTO;
using DemoSite.Factory;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using static DemoSite.PagesObjects.BrokenLinksPage;

namespace DemoSite.PagesObjects
{
    public class PracticeFromPage
    {
        private readonly IPage _page;
        public readonly PracticeFromPageMap Map;

        public PracticeFromPage(IPage page)
        {
            _page = page;
            Map = new PracticeFromPageMap(page);
        }

        public async Task ClickFormsBtnAndPracticeFormsButton()
        {
            await Map.FormsBtn.ClickAsync();
            await Map.PracticeFormsBtn.ClickAsync();
        }

        public async Task FillTextForm(DTOPracticeForm dto)
        {
            await Map.FirstNameInput.FillAsync(dto.FirstName);
            await Map.LastNameInput.FillAsync(dto.LastName);
            await Map.EmailInput.FillAsync(dto.Email);
            await Map.NumberPhone.FillAsync(dto.MovileNumber);
            await Map.CurrentAddress.FillAsync(dto.CurrentAddress);
        }

        public async Task FillDateOfBirth(DTOPracticeForm dto)
        {
            await Map.DateOfBirthInput.ClickAsync();
            await Map.MonthSelect.SelectOptionAsync(dto.MonthOfBirth); 
            await Map.YearSelect.SelectOptionAsync(dto.YearOfBirth);   
            await Map.DaySelect(dto.DayOfBirth).ClickAsync();          
        }

        public class PracticeFromPageMap(IPage page)
        {
            //Click in Forms
            public ILocator FormsBtn => page.GetByText("Forms");
            //Click in Web Practice Form
            public ILocator PracticeFormsBtn => page.GetByRole(AriaRole.Link, new() { Name = "Practice Form", Exact = true });
            #region DataStudent
            public ILocator FirstNameInput => page.GetByPlaceholder("First Name");
            public ILocator LastNameInput => page.GetByPlaceholder("Last Name");
            public ILocator EmailInput => page.GetByPlaceholder("name@example.com");
            public ILocator MaleRadio => page.GetByRole(AriaRole.Radio, new() { Name = "Male" });
            public ILocator FemaleRadio => page.GetByRole(AriaRole.Radio, new() { Name = "Female" });
            public ILocator OtherRadio => page.GetByRole(AriaRole.Radio, new() { Name = "Other" });
            public ILocator NumberPhone => page.GetByPlaceholder("Mobile Number");
            public ILocator DateOfBirthInput => page.Locator("#dateOfBirthInput");
            public ILocator MonthSelect => page.Locator(".react-datepicker__month-select");
            public ILocator YearSelect => page.Locator(".react-datepicker__year-select");
            public ILocator DaySelect(string day) =>
                page.Locator($".react-datepicker__day--0{day}:not(.react-datepicker__day--outside-month)");
            public ILocator SubjectsInput => page.Locator("#subjectsInput");
            public ILocator SportCheck => page.GetByRole(AriaRole.Checkbox, new() { Name = "Sports" });
            public ILocator ReadingCheck => page.GetByRole(AriaRole.Checkbox, new() { Name = "Reading" });
            public ILocator MusicCheck => page.GetByRole(AriaRole.Checkbox, new() { Name = "Music" });
            public ILocator Picture => page.GetByTestId("uploadPicture");
            public ILocator CurrentAddress => page.GetByPlaceholder("Current Address");
            public ILocator SelectState => page.Locator("Select State");
            public ILocator SelectCity => page.GetByTestId("city");
            public ILocator SubmitBtn => page.GetByRole(AriaRole.Button, new() { Name = "Submit" });
            #endregion
        }
    }
}
