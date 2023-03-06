﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Profile
    {
        public Profile()
        {
            InverseReportToNavigation = new HashSet<Profile>();
            MyCompanies = new HashSet<MyCompany>();
            Projects = new HashSet<Project>();
            Tasks = new HashSet<Task>();
        }

        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string HireDate { get; set; }
        public int? JobId { get; set; }
        public int? DepartmentId { get; set; }
        public int? ReportTo { get; set; }
        public int AnnualLeave { get; set; }

        public virtual Department Department { get; set; }
        public virtual Job Job { get; set; }
        public virtual Profile ReportToNavigation { get; set; }
        public virtual Account Account { get; set; }
        public virtual Salary Salary { get; set; }
        public virtual ICollection<Profile> InverseReportToNavigation { get; set; }
        public virtual ICollection<MyCompany> MyCompanies { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
