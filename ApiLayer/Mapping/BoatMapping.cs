using AutoMapper;
using DtoLayer.BoatDtos;
using EntityLayer.Entites;

namespace ApiLayer.Mapping
{
    public class BoatMapping : Profile
    {
        public BoatMapping()
        {
            CreateMap<Boat, ResultBoatDto>().ReverseMap();
            CreateMap<Boat, CreateBoatDto>().ReverseMap();
            CreateMap<Boat, GetBoatDto>().ReverseMap();
            CreateMap<Boat, UpdateBoatDto>().ReverseMap();
        }
    }
}
