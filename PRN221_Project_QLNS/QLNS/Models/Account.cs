using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class Account
    {
        public Account()
        {
            Profiles = new HashSet<Profile>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Isadmin { get; set; }
        public bool Ismanager { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
