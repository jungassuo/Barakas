namespace Barakas.Services.RoomAPI.Models.DTO
{
    public class RoomDto
    {
        public int RoomId { get; set; }
        public string Condition { get; set; }
        public bool IsActive { get; set; }
        public int FreeBedsAmmount { get; set; }
        public string Name { get; set; }
    }
}
