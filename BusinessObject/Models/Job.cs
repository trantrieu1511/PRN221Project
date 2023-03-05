using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Job
    {
        public Job()
        {
            Profiles = new HashSet<Profile>();
        }

        public int JobId { get; set; }
        public string JobTitle { get; set; } = null!;
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
