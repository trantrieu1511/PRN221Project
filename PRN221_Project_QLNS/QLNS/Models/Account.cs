using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLNS.Models;

public partial class Account
{
    public int ProfileId { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }

    public bool Isadmin { get; set; }

    public bool Ismanager { get; set; }

    public bool? Status { get; set; }

    [ValidateNever]
    public virtual Profile Profile { get; set; }
}
