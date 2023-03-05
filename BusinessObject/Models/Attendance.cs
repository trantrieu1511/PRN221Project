using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Attendance
    {
        public int ShiftId { get; set; }
        public string Date { get; set; } = null!;
        public string TimeIn { get; set; } = null!;
        public string TimeOut { get; set; } = null!;
        public string ProductionTime { get; set; } = null!;
        public int? EmployeeId { get; set; }
        public string? Note { get; set; }
    }
}
