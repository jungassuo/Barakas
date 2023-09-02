using System.ComponentModel.DataAnnotations;

namespace Barakas.Services.RoomAPI.Models
{
    public class Room
    {
        [Key] 
        public int RoomId { get; set; } 
        public string Condition { get; set; }
        public bool IsActive { get; set; }
        public int FreeBedsAmmount { get; set; }
        public string Name { get; set; }
    }
}
