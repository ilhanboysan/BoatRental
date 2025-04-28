using AutoMapper;
using DtoLayer.PartnerDtos;
using EntityLayer.Entites;

namespace ApiLayer.Mapping
{
	public class PartnerMapping : Profile
	{
		public PartnerMapping()
		{
			CreateMap<Partner, ResultPartnerDto>().ReverseMap();
			CreateMap<Partner, CreatePartnerDto>().ReverseMap();
			CreateMap<Partner, GetPartnerDto>().ReverseMap();
			CreateMap<Partner, UpdatePartnerDto>().ReverseMap();
		}
	}
}
