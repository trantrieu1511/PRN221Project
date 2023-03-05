using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class MyCompany
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public int ProfileId { get; set; }
        public string CompanyAddress { get; set; } = null!;
        public string CompanyCountry { get; set; } = null!;
        public string CompanyProvince { get; set; } = null!;
        public string CompanyCity { get; set; } = null!;
        public int PostalCode { get; set; }
        public string CompanyEmail { get; set; } = null!;
        public int CompanyPnumber { get; set; }
        public int Fax { get; set; }
        public string WebsiteUrl { get; set; } = null!;

        public virtual Profile Profile { get; set; } = null!;
    }
}
