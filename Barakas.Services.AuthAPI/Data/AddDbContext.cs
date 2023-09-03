using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Barakas.Services.AuthAPI.Data
{
    public class AddDbContext:IdentityDbContext<IdentityUser>
    {
        public AddDbContext(DbContextOptions<AddDbContext> options):base(options)
        {
               
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
