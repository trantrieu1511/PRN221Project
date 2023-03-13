using System;
using System.Collections.Generic;

namespace QLNS.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; }

    public virtual ICollection<Profile> Profiles { get; } = new List<Profile>();
}
