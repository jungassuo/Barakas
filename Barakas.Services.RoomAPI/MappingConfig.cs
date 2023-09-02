using AutoMapper;
using Barakas.Services.RoomAPI.Models;
using Barakas.Services.RoomAPI.Models.DTO;

namespace Barakas.Services.RoomAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() {
            var mapping = new MapperConfiguration(config =>
            {
                config.CreateMap<RoomDto, Room>();
                config.CreateMap<Room, RoomDto>();
            });
            return mapping;
        }
    }
}
