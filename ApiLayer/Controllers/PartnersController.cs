using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.PartnerDtos;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PartnersController : ControllerBase
	{
		private readonly IPartnerService _PartnerService;
		private readonly IMapper _mapper;

		public PartnersController(IPartnerService PartnerService, IMapper mapper)
		{
			_PartnerService = PartnerService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult PartnerList()
		{
			var values = _PartnerService.TGetListAll();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public IActionResult GetByIdPartner(int id)
		{
			var value = _PartnerService.TGetByID(id);
			if (value == null)
				return NotFound();

			var dto = _mapper.Map<GetPartnerDto>(value);
			return Ok(dto);
		}
		[HttpPost]
		public IActionResult CreatePartner(CreatePartnerDto createPartnerDto)
		{
			var Partner = _mapper.Map<Partner>(createPartnerDto);
			_PartnerService.TAdd(Partner);
			return Ok("Partner Başarıyla Eklendi");
		}
		[HttpPut]
		public IActionResult UpdatePartner(UpdatePartnerDto updatePartnerDto)
		{
			var existing = _PartnerService.TGetByID(updatePartnerDto.Id);
			if (existing == null)
				return NotFound();

			_mapper.Map(updatePartnerDto, existing); // Sadece gelen alanları günceller
			_PartnerService.TUpdate(existing);
			return Ok("Partner Başarıyla Güncellendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeletePartner(int id)
		{
			var value = _PartnerService.TGetByID(id);
			if (value == null)
				return NotFound();

			_PartnerService.TDelete(value);
			return Ok("Partner Silindi");
		}
	}
}
