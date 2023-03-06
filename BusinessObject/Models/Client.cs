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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
