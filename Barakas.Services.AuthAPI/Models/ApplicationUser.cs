﻿using Microsoft.AspNetCore.Identity;

namespace Barakas.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
