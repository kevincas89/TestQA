using DemoSite.DTO;
using Microsoft.Playwright;

namespace DemoSite.PagesObjects
{
    public class WebTablesPage
    {
        private readonly IPage _page;
        public readonly WebTablesPageMap Map;

        public WebTablesPage(IPage page)
        {
            _page = page;
            Map = new WebTablesPageMap(page);
        }

        public async Task AccessWebTablesAndAddUser(DTOWebTables dto)
        {
            await Map.ElementsBtn.ClickAsync();
            await Map.WebTablesBtn.ClickAsync();
            await Map.AddUSerBtn.ClickAsync();
            await Map.FillFirstName.FillAsync(dto.FirstName);
            await Map.FillLastName.FillAsync(dto.LastName);
            await Map.FillEmail.FillAsync(dto.Email);
            await Map.FillAge.FillAsync(dto.Age.ToString());
            await Map.FillSalary.FillAsync(dto.Salary.ToString());
            await Map.FillDepartment.FillAsync(dto.Department);
            await Map.BtnSubmit.ClickAsync();

        }

        public async Task AccessWebTablesAndDeleteUser(string email)
        {
            await Map.ElementsBtn.ClickAsync();
            await Map.WebTablesBtn.ClickAsync();
            await Map.DeleteButton(email).ClickAsync();
        }

        public async Task AccessWebTablesAndSearchUser(DTOWebTables dto)
        {
            await Map.ElementsBtn.ClickAsync();
            await Map.WebTablesBtn.ClickAsync();
            await Map.SearchUserText.FillAsync(dto.Email);
        }

        public async Task AccessWebTablesAndEditUser(DTOWebTables UsertoFind, DTOWebTables newData )
        {
            await Map.ElementsBtn.ClickAsync();
            await Map.WebTablesBtn.ClickAsync();
            await Map.EditButton(UsertoFind.Email).ClickAsync();

            //Clear data
            await Map.FillFirstName.ClearAsync();
            await Map.FillLastName.ClearAsync();
            await Map.FillEmail.ClearAsync();
            await Map.FillAge.ClearAsync();
            await Map.FillSalary.ClearAsync();
            await Map.FillDepartment.ClearAsync();

            //Fill new data 
            await Map.FillFirstName.FillAsync(newData.FirstName);
            await Map.FillLastName.FillAsync(newData.LastName);
            await Map.FillEmail.FillAsync(newData.Email);
            await Map.FillAge.FillAsync(newData.Age.ToString());
            await Map.FillSalary.FillAsync(newData.Salary.ToString());
            await Map.FillDepartment.FillAsync(newData.Department);
            await Map.BtnSubmit.ClickAsync();

        }

        public async Task<DTOWebTablesResult> GetFormOutput(DTOWebTables dto)
        {
            var row = _page.Locator("tbody tr").Filter(new() { HasText = dto.Email });

            return new DTOWebTablesResult
            {
                FirstName = await row.Locator("td").Nth(0).InnerTextAsync(),
                LastName = await row.Locator("td").Nth(1).InnerTextAsync(),
                Age = await row.Locator("td").Nth(2).InnerTextAsync(),
                Email = await row.Locator("td").Nth(3).InnerTextAsync(),
                Salary = await row.Locator("td").Nth(4).InnerTextAsync(),
                Department = await row.Locator("td").Nth(5).InnerTextAsync(),
            };
        }

        //found user email
        public async Task<int> GetRowCountByEmail(string email)
        {
            return await _page.Locator("tbody tr")
                .Filter(new() { HasText = email })
                .CountAsync();
        }


        public class WebTablesPageMap(IPage page)
        {
            //found text Elements
            public ILocator ElementsBtn => page.GetByText("Elements");
            //Click in Web Tables
            public ILocator WebTablesBtn => page.GetByRole(AriaRole.Link, new() { Name = "Web Tables" });
            //AddUSerBTN
            public ILocator AddUSerBtn => page.GetByRole(AriaRole.Button, new() { Name = "Add" });
            //VerifyFormRegistrationUser
            public ILocator VeriryRegistrationUser => page.Locator("Registration Form");
            #region FillUser
            public ILocator FillFirstName => page.GetByPlaceholder("First Name");
            public ILocator FillLastName => page.GetByPlaceholder("Last Name");
            public ILocator FillEmail => page.GetByPlaceholder("name@example.com");
            public ILocator FillAge => page.GetByPlaceholder("Age");
            public ILocator FillSalary => page.GetByPlaceholder("Salary");
            public ILocator FillDepartment => page.GetByPlaceholder("Department");
            public ILocator BtnSubmit => page.GetByRole(AriaRole.Button, new() { Name = "Submit" });
            #endregion

            #region FoundNewData
            public ILocator FoundFirstNameText(string Fristname) => page.GetByRole(AriaRole.Cell, new() { Name = Fristname, Exact = true });
            public ILocator FoundLassNameText(string LastName) => page.GetByRole(AriaRole.Cell, new() { Name = LastName, Exact = true });
            public ILocator FoundEmailText(string Email) => page.GetByRole(AriaRole.Cell, new() { Name = Email, Exact = true });
            public ILocator FoundAgeText(string Age) => page.GetByRole(AriaRole.Cell, new() { Name = Age, Exact = true });
            public ILocator FoundSalaryText(string Salary) => page.GetByRole(AriaRole.Cell, new() { Name = Salary, Exact = true });
            public ILocator FoundDepartmentText(string Department) => page.GetByRole(AriaRole.Cell, new() { Name = Department, Exact = true });
            #endregion

            #region DeleteUser
            public ILocator DeleteButton(string email) =>
                page.Locator("tbody tr")
                    .Filter(new() { HasText = email })
                    .Locator("[title='Delete']");
            #endregion

            #region SearchUser
            public ILocator SearchUserText => page.GetByPlaceholder("Type to search");
            #endregion

            #region EditUser
            public ILocator EditButton(string email) =>
                page.Locator("tbody tr")
                    .Filter(new() { HasText = email })
                    .Locator("span[title='Edit']");
            #endregion
        }
    }
}