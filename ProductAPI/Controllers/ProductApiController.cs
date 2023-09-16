using AutoMapper;
using Azure;
using Barakas.Services.ProductAPI.Models;
using Barakas.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Models.Dto;

namespace Barakas.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    //[Authorize]
    public class ProductApiController : ControllerBase
    {
        private readonly AddDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public ProductApiController(AddDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get() {
            

            try
            {
                IEnumerable<Product> objList = _db.Products.ToList();
                _response.Result = _mapper.Map<IEnumerable<ProductDto>>(objList);
                
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
                Product obj = _db.Products.FirstOrDefault(e=> e.ProductId == id);
                _response.Result =  _mapper.Map<ProductDto>(obj);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] ProductDto roomdto)
        {


            try
            {
                Product room = _mapper.Map<Product>(roomdto);
                _db.Products.Add(room);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ProductDto>(room);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }


        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] ProductDto roomdto)
        {


            try
            {
                Product room = _mapper.Map<Product>(roomdto);
                _db.Products.Update(room);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ProductDto>(room);

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
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Product room = _db.Products.First(u => u.ProductId == id);
                _db.Products.Remove(room);
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

