using UILayer.Dtos.BoatDtos;

namespace UILayer.Services.BoatServices
{
    public interface IBoatService
    {
        Task<List<ResultBoatDto>> GetAllBoatAsync();
        Task<List<ResultBoatDto>> GetFeaturedBoatAsync();
        Task<string> CreateBoatAsync(CreateBoatDto createBoatDto);
        Task<string> DeleteBoatAsync(int boatId);
        Task<UpdateBoatDto> GetByIdAsync(int id); // GET methodu
        Task<bool> UpdateBoatAsync(UpdateBoatDto updateBoatDto); // PUT methodu
        Task<ResultBoatDto> GetByIdAForContentsync(int id);
    }
}
