using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronoClashDeckBuilder.Models
{
    public partial class UserAccount
    {
        [Key]
        [StringLength(80)]
        [Required]
        public string Username { get; set; }
        [StringLength(80)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(80)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
