using System;
using System.Collections.Generic;

namespace QLNS.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public int CompanyId { get; set; }

    public virtual Company Company { get; set; }

    public virtual ICollection<Project> Projects { get; } = new List<Project>();
}
