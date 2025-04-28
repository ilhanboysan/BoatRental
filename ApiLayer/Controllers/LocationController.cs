using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.LocationDtos;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LocationsController : ControllerBase
	{
		private readonly ILocationService _LocationService;
		private readonly IMapper _mapper;

		public LocationsController(ILocationService LocationService, IMapper mapper)
		{
			_LocationService = LocationService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult LocationList()
		{
			var values = _LocationService.TGetListAll();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public IActionResult GetByIdLocation(int id)
		{
			var value = _LocationService.TGetByID(id);
			if (value == null)
				return NotFound();

			var dto = _mapper.Map<GetLocationDto>(value);
			return Ok(dto);
		}
		[HttpPost]
		public IActionResult CreateLocation(CreateLocationDto createLocationDto)
		{
			var Location = _mapper.Map<Location>(createLocationDto);
			_LocationService.TAdd(Location);
			return Ok("Konum Başarıyla Eklendi");
		}
		[HttpPut]
		public IActionResult UpdateLocation(UpdateLocationDto updateLocationDto)
		{
			var existing = _LocationService.TGetByID(updateLocationDto.Id);
			if (existing == null)
				return NotFound();

			_mapper.Map(updateLocationDto, existing); // Sadece gelen alanları günceller
			_LocationService.TUpdate(existing);
			return Ok("Konum Başarıyla Güncellendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteLocation(int id)
		{
			var value = _LocationService.TGetByID(id);
			if (value == null)
				return NotFound();

			_LocationService.TDelete(value);
			return Ok("Konum Silindi");
		}
	}
}
