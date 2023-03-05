using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Salary
    {
        public int PayslipNumber { get; set; }
        public int? ProfileId { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal? Da { get; set; }
        public decimal? Hra { get; set; }
        public decimal? Conveyance { get; set; }
        public decimal? Allowance { get; set; }
        public decimal? MedicalAllowance { get; set; }
        public decimal? Tds { get; set; }
        public decimal? Esi { get; set; }
        public decimal? Pf { get; set; }
        public decimal? Leave { get; set; }
        public decimal? Loan { get; set; }
        public decimal? ProfessionalTax { get; set; }
        public string CreateDate { get; set; } = null!;

        public virtual Profile? Profile { get; set; }
    }
}
