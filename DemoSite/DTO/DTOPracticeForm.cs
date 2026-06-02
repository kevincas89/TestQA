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
    }
}
