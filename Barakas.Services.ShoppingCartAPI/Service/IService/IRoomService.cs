using Barakas.Services.ShoppingCartAPI.Models.Dto;

namespace Barakas.Services.ShoppingCartAPI.Service.IService
{
    public interface IRoomService
    {
        Task<RoomDto> GetProducts(string roomCode);
    }
}
