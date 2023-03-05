using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ProfileDetail
    {
        public int? ProfileId { get; set; }
        public string Dob { get; set; } = null!;
        public string Address { get; set; } = null!;
        public bool Gender { get; set; }
        public string Country { get; set; } = null!;
        public string Religion { get; set; } = null!;
        public bool IsMarried { get; set; }
        public int? Children { get; set; }
        public string BankName { get; set; } = null!;
        public string BankNumber { get; set; } = null!;

        public virtual Profile? Profile { get; set; }
    }
}
