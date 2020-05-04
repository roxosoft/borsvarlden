﻿using System.ComponentModel.DataAnnotations;

namespace borsvarlden.Models
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(32)]
        public string PasswordHash { get; set; }
    }
}
