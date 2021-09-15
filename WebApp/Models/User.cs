﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Role { get; set; }
        public DateTime CreatedAT { get; set; } = DateTime.Now;

    }
}
