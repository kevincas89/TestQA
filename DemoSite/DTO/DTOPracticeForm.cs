using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DemoSite.DTO
{
    public abstract class DTOPracticeForm
    {
        public abstract string FirstName { get; }
        public abstract string LastName { get; } 
        public abstract string Email { get; }
        public abstract string Subjects { get; }
        public abstract string MovileNumber { get; }
        public abstract string CurrentAddress { get; }
        public abstract string DayOfBirth { get; }
        public abstract string MonthOfBirth { get; }
        public abstract string YearOfBirth { get; }
        public abstract string Hobbies { get; }
        public abstract string Picture { get; }
        public abstract string State { get; }
        public abstract string City { get; }
        public abstract string Gender { get; }
    }
}
