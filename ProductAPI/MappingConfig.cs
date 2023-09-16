using AutoMapper;
using Barakas.Services.ProductAPI.Models;
using ProductAPI.Models;
using ProductAPI.Models.Dto;

namespace Barakas.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() {
            var mapping = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return mapping;
        }
    }
}
