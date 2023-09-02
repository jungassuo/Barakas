using Barakas.Web.Models;
using Barakas.Web.Service.IService;
using Barakas.Web.Utility;

namespace Barakas.Web.Service
{
    public class RoomService : IRoomService
    {
        private readonly IBaseService _baseService;

        public RoomService(IBaseService baseService) { 
            _baseService = baseService;
        }


        public async Task<ResponseDto> CreateRoomsAsync(RoomDto roomDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data=roomDto,
                Url = SD.RoomAPIBase + "/api/room"
            });
        }

        public async Task<ResponseDto> DeleteRoomsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.RoomAPIBase + "/api/room/" + id
            });
        }

        public async Task<ResponseDto> GetAllRoomsAssync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RoomAPIBase + "/api/room"
            });
        }

        public async Task<ResponseDto> GetRoomAsync(string roomCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RoomAPIBase + "/api/room/GetByCode"+roomCode
            });
        }

        public async Task<ResponseDto> GetRoomByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RoomAPIBase + "/api/room/" + id
            });
        }

        public async Task<ResponseDto> UpdateRoomsAsync(RoomDto roomDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data=roomDto,
                Url = SD.RoomAPIBase + "/api/room"
            });
        }
    }
}
