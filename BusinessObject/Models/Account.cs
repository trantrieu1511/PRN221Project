using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Account
    {
        public int? ProfileId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Isadmin { get; set; }
        public bool Ismanager { get; set; }
        public bool? Status { get; set; }

        public virtual Profile? Profile { get; set; }
    }
}
