using Barakas.Web.Models;
using Barakas.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Barakas.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService) { 
            _roomService = roomService;
        }
        public async Task<IActionResult> RoomIndex()
        {
            List<RoomDto?> list = new();

            ResponseDto? response = await _roomService.GetAllRoomsAssync();

            if(response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<RoomDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
        public async Task<IActionResult> RoomCreate() 
        {
            return View();
        }
    }
}
