using System;
using System.Collections.Generic;

namespace QLNS.Models;

public partial class Profile
{
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

    public virtual Account Account { get; set; }

    public virtual Department Department { get; set; }

    public virtual ICollection<Profile> InverseReportToNavigation { get; } = new List<Profile>();

    public virtual Job Job { get; set; }

    public virtual ICollection<MyCompany> MyCompanies { get; } = new List<MyCompany>();

    public virtual ICollection<Project> Projects { get; } = new List<Project>();

    public virtual Profile ReportToNavigation { get; set; }

    public virtual Salary Salary { get; set; }

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
