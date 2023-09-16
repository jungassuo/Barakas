using Barakas.Services.ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Barakas.Services.ShoppingCartAPI.Data
{
    public class AddDbContext:DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options):base(options)
        {
               
        }

        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
    }
}
