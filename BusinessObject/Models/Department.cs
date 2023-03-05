using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Department
    {
        public Department()
        {
            Profiles = new HashSet<Profile>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
