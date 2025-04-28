using AutoMapper;
using DtoLayer.LocationDtos;
using EntityLayer.Entites;

namespace ApiLayer.Mapping
{
	public class LocationMapping : Profile
	{
		public LocationMapping()
		{
			CreateMap<Location, ResultLocationDto>().ReverseMap();
			CreateMap<Location, CreateLocationDto>().ReverseMap();
			CreateMap<Location, GetLocationDto>().ReverseMap();
			CreateMap<Location, UpdateLocationDto>().ReverseMap();
		}
	}
}
