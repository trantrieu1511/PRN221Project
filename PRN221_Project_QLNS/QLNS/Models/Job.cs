using System;
using System.Collections.Generic;

namespace QLNS.Models;

public partial class Job
{
    public int JobId { get; set; }

    public string JobTitle { get; set; }

    public decimal? MinSalary { get; set; }

    public decimal? MaxSalary { get; set; }

    public virtual ICollection<Profile> Profiles { get; } = new List<Profile>();
}
