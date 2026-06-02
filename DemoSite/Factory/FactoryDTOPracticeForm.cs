using DemoSite.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSite.Factory
{
    public static class FactoryDTOPracticeForm
    {
        public static DTOPracticeForm Default => new PracticeFromDefaultDTO();
    }

    public class PracticeFromDefaultDTO : DTOPracticeForm
    {
        public override string FirstName => "John";
        public override string LastName => "Smith";
        public override string Email => "jhonSmith@test.com";
        public override string Subjects => "Computer Science";
        public override string MovileNumber => "1234567890";
        public override string CurrentAddress => "123 Main St, Anytown, USA";
        public override string DayOfBirth => "01";
        public override string MonthOfBirth => "June";
        public override string YearOfBirth => "1990";
    }
}
