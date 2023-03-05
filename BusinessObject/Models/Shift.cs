using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Shift
    {
        public string Name { get; set; } = null!;
        public string StartTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;
    }
}
