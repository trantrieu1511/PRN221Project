using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Priority { get; set; }
        public string Deadline { get; set; }
        public int? Status { get; set; }
        public int? Assigned { get; set; }
        public string Project { get; set; }

        public virtual Profile AssignedNavigation { get; set; }
        public virtual Project ProjectNavigation { get; set; }
    }
}
