using Barakas.Services.AuthAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Barakas.Services.AuthAPI.Data
{
    public class AddDbContext:IdentityDbContext<ApplicationUser>
    {
        public AddDbContext(DbContextOptions<AddDbContext> options):base(options)
        {
               
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
