using BusinessLayer.Abstract;
using DtoLayer.BoatDtos;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Mvc;
namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatsController : ControllerBase
    {
        private readonly IBoatService _BoatService;

        public BoatsController(IBoatService BoatService)
        {
            _BoatService = BoatService;
        }
        [HttpGet]
        public IActionResult BoatList()
        {
            var values = _BoatService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBoat(CreateBoatDto createBoatDto)
        {
            Boat Boat = new Boat()
            {
                Name = createBoatDto.Name,
                Location = createBoatDto.Location,
                Category = createBoatDto.Category,
                Size = createBoatDto.Size,
                Capacity = createBoatDto.Capacity,
                MasterKabin = createBoatDto.MasterKabin,
                WcBanyo = createBoatDto.WcBanyo,
                Captain = createBoatDto.Captain,
                Chef = createBoatDto.Chef,
                Price = createBoatDto.Price,
                Equipment = createBoatDto.Equipment,
                Images = createBoatDto.Images,
                feature = createBoatDto.feature
            };
            _BoatService.TAdd(Boat);
            return Ok("Tekne Başarıyla Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBoat(int id)
        {
            var value = _BoatService.TGetByID(id);
            _BoatService.TDelete(value);
            return Ok("Tekne Başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateBoat(UpdateBoatDto updateBoatDto)
        {
            Boat Boat = new Boat()
            {
                Id = updateBoatDto.Id,
                Name = updateBoatDto.Name,
                Location = updateBoatDto.Location,
                Category = updateBoatDto.Category,
                Size = updateBoatDto.Size,
                Capacity = updateBoatDto.Capacity,
                MasterKabin = updateBoatDto.MasterKabin,
                WcBanyo = updateBoatDto.WcBanyo,
                Captain = updateBoatDto.Captain,
                Chef = updateBoatDto.Chef,
                Price = updateBoatDto.Price,
                Equipment = updateBoatDto.Equipment,
                Images = updateBoatDto.Images,
                feature = updateBoatDto.feature

            };
            _BoatService.TUpdate(Boat);
            return Ok("Tekne Başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBoat(int id)
        {
            var value = _BoatService.TGetByID(id);
            return Ok(value);
        }
        [HttpGet("FeaturedBoats")]
        public IActionResult FeaturedBoats()
        {
            var values = _BoatService.TGetListAll()
                .Where(x => x.feature == true)
                .ToList();

            return Ok(values);
        }
    }
}

