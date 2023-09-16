using Barakas.Services.ShoppingCartAPI.Models.Dto;
using Barakas.Services.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Barakas.Services.ShoppingCartAPI.Service
{
    public class RoomService : IRoomService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RoomService(IHttpClientFactory clientFactory)
        { 
            _httpClientFactory = clientFactory;
        }

        public async Task<RoomDto> GetProducts(string roomCode)
        {
            var client = _httpClientFactory.CreateClient("Room");
            var response = await client.GetAsync($"/api/room/GetByCode/{roomCode}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<RoomDto>(Convert.ToString(resp.Result));
            }
            return new RoomDto();
        }
    }
}
