﻿using System.ComponentModel.DataAnnotations;

namespace Barakas.Web.Models
{
    public class LoginRequestDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
