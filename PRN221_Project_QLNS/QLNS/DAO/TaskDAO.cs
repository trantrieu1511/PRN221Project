using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;

namespace QLNS.DAO
{
    public class TaskDAO
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public int? Status { get; set; }
        public int? Assigned { get; set; }
    }
}
