using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Company
    {
        public Company()
        {
            Clients = new HashSet<Client>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
