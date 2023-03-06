using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Attendance
    {
        public int ShiftId { get; set; }
        public string Date { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string ProductionTime { get; set; }
        public int? EmployeeId { get; set; }
        public string Note { get; set; }
    }
}
