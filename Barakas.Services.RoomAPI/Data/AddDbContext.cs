using Barakas.Services.RoomAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Barakas.Services.RoomAPI.Data
{
    public class AddDbContext:DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options):base(options)
        {
               
        }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>().HasData(new Room { 
                RoomId = 1,
                Condition="Good",
                IsActive=true,
                FreeBedsAmmount=1,
                Name="405"
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                RoomId = 2,
                Condition = "Good",
                IsActive = true,
                FreeBedsAmmount = 1,
                Name = "406"
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                RoomId = 3,
                Condition = "Good",
                IsActive = true,
                FreeBedsAmmount = 1,
                Name = "407"
            });
        }
    }
}
