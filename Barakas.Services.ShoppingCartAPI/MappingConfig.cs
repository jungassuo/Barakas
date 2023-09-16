using AutoMapper;
using Barakas.Services.ShoppingCartAPI.Models;
using Barakas.Services.ShoppingCartAPI.Models.Dto;

namespace Barakas.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() {
            var mapping = new MapperConfiguration(config =>
            {
                config.CreateMap<CartDetailsDto, CartDetails>().ReverseMap();
                config.CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
            });
            return mapping;
        }
    }
}
