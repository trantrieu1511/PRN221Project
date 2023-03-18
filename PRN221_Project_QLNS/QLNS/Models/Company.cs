using System;
using System.Collections.Generic;

namespace QLNS.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; }

    public virtual ICollection<Client> Clients { get; } = new List<Client>();
}
