using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class FamilyInfo
    {
        public int? ProfileId { get; set; }
        public string Name { get; set; } = null!;
        public string Relationship { get; set; } = null!;
        public string? Dob { get; set; }
        public string Phone { get; set; } = null!;

        public virtual Profile? Profile { get; set; }
    }
}
