using System;
using System.Collections.Generic;

namespace QLNS.Models;

public partial class MyCompany
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; }

    public int ProfileId { get; set; }

    public string CompanyAddress { get; set; }

    public string CompanyCountry { get; set; }

    public string CompanyProvince { get; set; }

    public string CompanyCity { get; set; }

    public int PostalCode { get; set; }

    public string CompanyEmail { get; set; }

    public int CompanyPnumber { get; set; }

    public int Fax { get; set; }

    public string WebsiteUrl { get; set; }

    public virtual Profile Profile { get; set; }
}
