using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Schedule
    {
        public int? ProfileId { get; set; }
        public string ShiftName { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
