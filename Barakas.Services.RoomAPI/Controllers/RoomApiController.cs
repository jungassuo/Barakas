using AutoMapper;
using Azure;
using Barakas.Services.RoomAPI.Data;
using Barakas.Services.RoomAPI.Models;
using Barakas.Services.RoomAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barakas.Services.RoomAPI.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomApiController : ControllerBase
    {
        private readonly AddDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public RoomApiController(AddDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get() {
            

            try
            {
                IEnumerable<Room> objList = _db.Rooms.ToList();
                _response.Result = _mapper.Map<IEnumerable<RoomDto>>(objList);
                
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {


            try
            {
                Room obj = _db.Rooms.FirstOrDefault(e=> e.RoomId == id);
                _response.Result =  _mapper.Map<RoomDto>(obj);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {


            try
            {
                Room obj = _db.Rooms.FirstOrDefault(e => e.Name.ToLower() == code.ToLower());
                if (obj == null) {
                    _response.IsSuccess = false;
                }
                _response.Result = _mapper.Map<RoomDto>(obj);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }


        [HttpPost]
        public ResponseDto Post([FromBody] RoomDto roomdto)
        {


            try
            {
                Room room = _mapper.Map<Room>(roomdto);
                _db.Rooms.Add(room);
                _db.SaveChanges();

                _response.Result = _mapper.Map<RoomDto>(room);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }


        [HttpPut]
        public ResponseDto Put([FromBody] RoomDto roomdto)
        {


            try
            {
                Room room = _mapper.Map<Room>(roomdto);
                _db.Rooms.Update(room);
                _db.SaveChanges();

                _response.Result = _mapper.Map<RoomDto>(room);

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }


        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Room room = _db.Rooms.First(u => u.RoomId == id);
                _db.Rooms.Remove(room);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }
    }
    

}

