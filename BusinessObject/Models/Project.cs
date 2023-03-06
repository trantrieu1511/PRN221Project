using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        public string Title { get; set; }
        public int? ClientId { get; set; }
        public string Period { get; set; }
        public decimal? Rate { get; set; }
        public int? ManagerId { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }

        public virtual Client Client { get; set; }
        public virtual Profile Manager { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
