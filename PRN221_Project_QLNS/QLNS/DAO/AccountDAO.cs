using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLNS.DAO
{
    public class AccountDAO
    {

        public int AccountId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Isadmin { get; set; }
        public bool Ismanager { get; set; }
    }
}
