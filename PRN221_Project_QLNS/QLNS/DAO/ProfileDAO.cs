using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLNS.DAO
{
    public class ProfileDAO
    {
        public int ProfileId { get; set; }
        public int AccountId { get; set; }
        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(40)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        public string HireDate { get; set; }
        [Required]
        [MaxLength(40)]
        public string Job { get; set; }
        [Required]
        public int? ReportTo { get; set; }

    }
}
