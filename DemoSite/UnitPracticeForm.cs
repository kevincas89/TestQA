using DemoSite.Factory;
using DemoSite.test;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSite
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class UnitPracticeForm
    {
        

        public class Tests: TestBases
        {
            [Test]
            public async Task AccessWebPracticeForms()
            {
                var DemoSite = new PagesObjects.PracticeFromPage(Page);

                await DemoSite.ClickFormsBtnAndPracticeFormsButton();

                var defaultUser = FactoryDTOPracticeForm.Default;

                await DemoSite.FillTextForm(defaultUser);

                await DemoSite.CheckGender(defaultUser);

                await DemoSite.FillDateOfBirth(defaultUser); 

                await DemoSite.FillSubjects(defaultUser);

                await DemoSite.FillHobbies(defaultUser);

                await DemoSite.UploadPicture(defaultUser);

                var FileName = await DemoSite.GetNameUploadFile();

                await DemoSite.FillStateAndCity(defaultUser);
                
                await DemoSite.ClickSubmitBtn();

                var result = await DemoSite.GetFormResult();

                Assert.Multiple(() =>
                {
                    Assert.That(result.StudentName, Is.EqualTo($"{defaultUser.FirstName} {defaultUser.LastName}"));
                    Assert.That(result.StudentEmail, Is.EqualTo(defaultUser.Email));
                    Assert.That(result.Gender, Is.EqualTo(defaultUser.Gender));
                    Assert.That(result.Mobile, Is.EqualTo(defaultUser.MovileNumber));
                    Assert.That(result.Subjects, Is.EqualTo(defaultUser.Subjects));
                    Assert.That(result.Address, Is.EqualTo(defaultUser.CurrentAddress));
                    Assert.That(result.StateAndCity, Is.EqualTo($"{defaultUser.State} {defaultUser.City}"));
                });

                await DemoSite.ClickCloseBtn();
            }
        }
    }
}
