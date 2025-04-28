using UILayer.Dtos.BoatDtos;
using UILayer.Dtos.LocationDtos;

namespace UILayer.Models
{
    public class HomeViewModel
    {
        public List<ResultBoatDto> Boats { get; set; }
        public List<ResultLocationDto> Locations { get; set; }
    }
}
