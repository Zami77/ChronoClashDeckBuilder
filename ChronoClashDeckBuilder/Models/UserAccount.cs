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
        public string Username { get; set; }
        [StringLength(80)]
        public string Email { get; set; }
        [StringLength(80)]
        public string Password { get; set; }
    }
}
