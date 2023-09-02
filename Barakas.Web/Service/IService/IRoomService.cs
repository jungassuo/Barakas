using Barakas.Web.Models;

namespace Barakas.Web.Service.IService
{
    public interface IRoomService
    {
        Task<ResponseDto> GetRoomAsync(string roomCode);
        Task<ResponseDto> GetAllRoomsAssync();
        Task<ResponseDto> GetRoomByIdAsync(int id);
        Task<ResponseDto> CreateRoomsAsync(RoomDto roomDto);
        Task<ResponseDto> UpdateRoomsAsync(RoomDto roomDto);
        Task<ResponseDto> DeleteRoomsAsync(int id);

    }
}
