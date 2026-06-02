using DemoSite.test;
using DemoSite.DTO;

namespace DemoSite
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : TestBases
    {
        [Test]
        public async Task GotoHomePage()
        {
            var DemoSite = new PagesObjects.TextBoxPage(Page);

            await DemoSite.ClickElementsBtn();
        }

        [Test]
        public async Task GotoTextBoxAndFillFrom()
        {
            var DemoSite = new PagesObjects.TextBoxPage(Page);

            await DemoSite.ClickElementsBtn();
            await DemoSite.ClickTextBoxAndFillForm(TextBoxDTO.Profiles.Default);
        }

        [Test]
        public async Task FillForm_WithDefaultData()
        {
            var DemoSite = new PagesObjects.TextBoxPage(Page);
            await DemoSite.ClickElementsBtn();
            await DemoSite.ClickTextBoxAndFillForm(TextBoxDTO.Profiles.Default);

        }

        [Test]
        public async Task FillForm_WithSpecialChars()
        {
            var DemoSite = new PagesObjects.TextBoxPage(Page);
            await DemoSite.ClickElementsBtn();
            await DemoSite.ClickTextBoxAndFillForm(TextBoxDTO.Profiles.SpecialChars);
        }

        [Test]
        public async Task FillForm_WithInvalidData()
        {
            var DemoSite = new PagesObjects.TextBoxPage(Page);
            await DemoSite.ClickElementsBtn();
            await DemoSite.ClickTextBoxAndFillForm(TextBoxDTO.Profiles.Invalid);
        }

        [Test]
        public async Task FillForm_WithEmptyFields()
        {
            var DemoSite = new PagesObjects.TextBoxPage(Page);
            await DemoSite.ClickElementsBtn();
            await DemoSite.ClickTextBoxAndFillForm(TextBoxDTO.Profiles.Empty);
        }

        [Test]
        public async Task FillForm_AndVerifyOutput()
        {
            var DemoSite = new PagesObjects.TextBoxPage(Page);
            var dto = TextBoxDTO.Profiles.Default;

            await DemoSite.ClickElementsBtn();
            await DemoSite.ClickTextBoxAndFillForm(dto);

            var result = await DemoSite.GetFormOutput(dto);

            Assert.That(result.FullName, Is.EqualTo($"Name:{dto.FullName}"));
            Assert.That(result.Email, Is.EqualTo($"Email:{dto.Email}"));
            Assert.That(result.CurrentAddress, Is.EqualTo($"Current Address :{dto.CurrentAddress}"));
            Assert.That(result.PermanentAddress, Is.EqualTo($"Permananet Address :{dto.PermanentAddress}"));
        }
    }
}
