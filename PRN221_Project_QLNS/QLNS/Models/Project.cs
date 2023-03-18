using System;
using System.Collections.Generic;

namespace QLNS.Models;

public partial class Project
{
    public string Title { get; set; }

    public int? ClientId { get; set; }

    public string Period { get; set; }

    public decimal? Rate { get; set; }

    public int? ManagerId { get; set; }

    public string Description { get; set; }

    public int? Status { get; set; }

    public virtual Client Client { get; set; }

    public virtual Profile Manager { get; set; }

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
