using System;
using System.Collections.Generic;

namespace DummyProject.Models
{
    public partial class Profile
    {
        public Profile()
        {
            InverseReportToNavigation = new HashSet<Profile>();
            Tasks = new HashSet<Task>();
        }

        public int ProfileId { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string HireDate { get; set; }
        public string Job { get; set; }
        public int? ReportTo { get; set; }

        public virtual Account Account { get; set; }
        public virtual Profile ReportToNavigation { get; set; }
        public virtual ICollection<Profile> InverseReportToNavigation { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
