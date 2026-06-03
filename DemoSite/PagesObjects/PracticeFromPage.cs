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

        public async Task CheckGender(DTOPracticeForm dto)
        {
            switch (dto.Gender)
            {
                case "Male": await Map.MaleRadio.CheckAsync(); break;
                case "Female": await Map.FemaleRadio.CheckAsync(); break;
                case "Other": await Map.OtherRadio.CheckAsync(); break;
            }
        }

        public async Task FillDateOfBirth(DTOPracticeForm dto)
        {
            await Map.DateOfBirthInput.ClickAsync();
            await Map.MonthSelect.SelectOptionAsync(dto.MonthOfBirth); 
            await Map.YearSelect.SelectOptionAsync(dto.YearOfBirth);   
            await Map.DaySelect(dto.DayOfBirth).ClickAsync();          
        }

        public async Task FillHobbies(DTOPracticeForm dto)
        {
            await Map.SportCheck.SetCheckedAsync(dto.Hobbies.Contains("Sport"));
            await Map.ReadingCheck.SetCheckedAsync(dto.Hobbies.Contains("Reading"));
            await Map.MusicCheck.SetCheckedAsync(dto.Hobbies.Contains("Music"));
        }

        public async Task FillSubjects(DTOPracticeForm dto)
        {
            await Map.SubjectsInput.FillAsync(dto.Subjects);
            await Map.SubjectsInput.PressAsync("Enter");
        }

        public async Task UploadPicture(DTOPracticeForm dto)
        {
            await Map.Picture.SetInputFilesAsync(dto.Picture);
        }

        public async Task<string> GetNameUploadFile()
        {
            return await Map.Picture.InnerTextAsync();
        }

        public async Task FillStateAndCity(DTOPracticeForm dto)
        {
            await Map.SelectState.ClickAsync();
            await Map.StateInput.FillAsync(dto.State);
            await _page.GetByRole(AriaRole.Option, new() { Name = dto.State, Exact = true }).ClickAsync();

            await Map.SelectCity.ClickAsync();
            await Map.CityInput.FillAsync(dto.City);
            await _page.GetByRole(AriaRole.Option, new() { Name = dto.City, Exact = true }).ClickAsync();
        }

        public async Task ClickSubmitBtn()
        {
            await Map.SubmitBtn.ClickAsync();
        }

        public async Task<DTOPracticeFormResult> GetFormResult()
        {
            return new DTOPracticeFormResult
            {
                StudentName = await Map.GetResultValue("Student Name").InnerTextAsync(),
                StudentEmail = await Map.GetResultValue("Student Email").InnerTextAsync(),
                Gender = await Map.GetResultValue("Gender").InnerTextAsync(),
                Mobile = await Map.GetResultValue("Mobile").InnerTextAsync(),
                DateOfBirth = await Map.GetResultValue("Date of Birth").InnerTextAsync(),
                Subjects = await Map.GetResultValue("Subjects").InnerTextAsync(),
                Hobbies = await Map.GetResultValue("Hobbies").InnerTextAsync(),
                Picture = await Map.GetResultValue("Picture").InnerTextAsync(),
                Address = await Map.GetResultValue("Address").InnerTextAsync(),
                StateAndCity = await Map.GetResultValue("State and City").InnerTextAsync()
            };
        }

        public async Task ClickCloseBtn()
        {
            await Map.CloseBtn.ClickAsync();
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
            public ILocator MaleRadio => page.GetByRole(AriaRole.Radio, new() { Name = "Male", Exact = true });
            public ILocator FemaleRadio => page.GetByRole(AriaRole.Radio, new() { Name = "Female", Exact = true });
            public ILocator OtherRadio => page.GetByRole(AriaRole.Radio, new() { Name = "Other", Exact = true });
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
            public ILocator Picture => page.Locator("#uploadPicture");
            public ILocator CurrentAddress => page.GetByPlaceholder("Current Address");
            public ILocator SelectState => page.Locator("#state");
            public ILocator SelectCity => page.Locator("#city");
            public ILocator StateInput => page.Locator("#state input");
            public ILocator CityInput => page.Locator("#city input");
            public ILocator SubmitBtn => page.GetByRole(AriaRole.Button, new() { Name = "Submit" });
            #endregion

            #region TableResult
            public ILocator TextTitle => page.GetByRole(AriaRole.Heading, new() { Name = "Thanks for submitting the form", Exact = true });
            public ILocator GetResultValue(string label) => page.Locator("tbody tr").Filter(new() { HasText = label }).Locator("td").Nth(1);
            public ILocator CloseBtn => page.GetByRole(AriaRole.Button, new() { Name = "Close" });
            #endregion
        }
    }
}
