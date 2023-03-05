using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Client
    {
        public Client()
        {
            Projects = new HashSet<Project>();
        }

        public int ClientId { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<Project> Projects { get; set; }
    }
}
