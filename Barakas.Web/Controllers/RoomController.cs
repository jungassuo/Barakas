using Barakas.Web.Models;
using Barakas.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

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
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }
        public async Task<IActionResult> RoomCreate() 
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> RoomCreate(RoomDto roomDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _roomService.CreateRoomsAsync(roomDto);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Room created successfully";
                    return RedirectToAction(nameof(RoomIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }

            }
            return View(roomDto);
        }

        public async Task<IActionResult> RoomDelete(int id)
        {
            ResponseDto? response = await _roomService.GetRoomByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                RoomDto? model = JsonConvert.DeserializeObject<RoomDto>(Convert.ToString(response.Result));
               

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> RoomDelete(RoomDto room)
        {
            ResponseDto? response = await _roomService.DeleteRoomsAsync(room.RoomId);

            if (response != null && response.IsSuccess)
            {
                RoomDto? model = JsonConvert.DeserializeObject<RoomDto>(Convert.ToString(response.Result));
                TempData["success"] = "Room deleted successfully";
                return RedirectToAction(nameof(RoomIndex));
            }
            else {
                TempData["error"] = response?.Message;
            }

            return View(room);
        }

    }
}
