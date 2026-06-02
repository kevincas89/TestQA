using DemoSite.Factory;
using DemoSite.test;


namespace DemoSite
{
    public class UnitWebTables
    {
        [Parallelizable(ParallelScope.Self)]
        [TestFixture]
        public class Tests : TestBases
        {
            [Test]
            public async Task AccessWebTablesAndAddUserWithValidData()
            {
                var DemoSite = new PagesObjects.WebTablesPage(Page);

                var defaultUser = FactoryDtoWebTables.Default;
                await DemoSite.AccessWebTablesAndAddUser(defaultUser);

                var informationShowedInTableDto = await DemoSite.GetFormOutput(defaultUser);

                Assert.Multiple(() =>
                {
                    Assert.That(informationShowedInTableDto.FirstName, Is.EqualTo(defaultUser.FirstName));
                    Assert.That(informationShowedInTableDto.LastName, Is.EqualTo(defaultUser.LastName));
                    Assert.That(informationShowedInTableDto.Email, Is.EqualTo(defaultUser.Email));
                    Assert.That(informationShowedInTableDto.Age, Is.EqualTo(defaultUser.Age));
                    Assert.That(informationShowedInTableDto.Salary, Is.EqualTo(defaultUser.Salary));
                    Assert.That(informationShowedInTableDto.Department, Is.EqualTo(defaultUser.Department));
                }
                );
            }

            [Test]
            public async Task AccessWebTablesAndAddUserWithInvalidData()
            {
                var DemoSite = new PagesObjects.WebTablesPage(Page);

                await DemoSite.AccessWebTablesAndAddUser(FactoryDtoWebTables.Invalid);
            }

            [Test]
            public async Task AccessWebTablesAndAddUserWithSpecialData()
            {
                var DemoSite = new PagesObjects.WebTablesPage(Page);

                await DemoSite.AccessWebTablesAndAddUser(FactoryDtoWebTables.SpecialChars);
            }

            [Test]
            public async Task AccessWebTablesAndAddUserWithoutData()
            {
                var DemoSite = new PagesObjects.WebTablesPage(Page);

                await DemoSite.AccessWebTablesAndAddUser(FactoryDtoWebTables.Empty);
            }

            [Test]
            public async Task AccessWebTablesAndDeleteUser()
            {
                var DemoSite = new PagesObjects.WebTablesPage(Page);
                await DemoSite.AccessWebTablesAndDeleteUser(FactoryDtoWebTables.UserDelete.Email);

                var rowCount = await DemoSite.GetRowCountByEmail(FactoryDtoWebTables.UserDelete.Email);

                Assert.That(rowCount, Is.EqualTo(0));
            }

            [Test]
            public async Task AccessWebTablesAndSearchUser()
            {
                var DemoSite = new PagesObjects.WebTablesPage(Page);

                await DemoSite.AccessWebTablesAndSearchUser(FactoryDtoWebTables.UserSearch);

                var rowCount = await DemoSite.GetRowCountByEmail(FactoryDtoWebTables.UserSearch.Email);

                Assert.That(rowCount, Is.EqualTo(1));

            }

            [Test]
            public async Task AccessWebTablesAndEditUser()
            {
                var DemoSite = new PagesObjects.WebTablesPage(Page);
                var defaultUser = FactoryDtoWebTables.Default;

                await DemoSite.AccessWebTablesAndEditUser(FactoryDtoWebTables.UserSearch, FactoryDtoWebTables.EditUser);

                var informationShowedInTableDto = await DemoSite.GetFormOutput(FactoryDtoWebTables.EditUser);
                Assert.Multiple(() =>
                {
                    Assert.That(informationShowedInTableDto.FirstName, Is.EqualTo(FactoryDtoWebTables.EditUser.FirstName));
                    Assert.That(informationShowedInTableDto.LastName, Is.EqualTo(FactoryDtoWebTables.EditUser.LastName));
                    Assert.That(informationShowedInTableDto.Email, Is.EqualTo(FactoryDtoWebTables.EditUser.Email));
                    Assert.That(informationShowedInTableDto.Age, Is.EqualTo(FactoryDtoWebTables.EditUser.Age));
                    Assert.That(informationShowedInTableDto.Salary, Is.EqualTo(FactoryDtoWebTables.EditUser.Salary));
                    Assert.That(informationShowedInTableDto.Department, Is.EqualTo(FactoryDtoWebTables.EditUser.Department));
                }
                );
            }
        }
    }
}
