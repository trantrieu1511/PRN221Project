using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Experience
    {
        public int? ProfileId { get; set; }
        public string Role { get; set; } = null!;
        public string StartDate { get; set; } = null!;
        public string? EndDate { get; set; }

        public virtual Profile? Profile { get; set; }
    }
}
