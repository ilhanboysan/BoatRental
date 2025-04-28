using UILayer.Dtos.LocationDtos;

namespace UILayer.Services.LocationServices
{
	public interface ILocationService
	{
		Task<List<ResultLocationDto>> GetAllLocationAsync();
		Task<string> CreateLocationAsync(CreateLocationDto createLocationDto);
		Task<string> DeleteLocationAsync(int LocationId);
		Task<UpdateLocationDto> GetByIdAsync(int id);
		Task<bool> UpdateLocationAsync(UpdateLocationDto updateLocationDto);
		Task<ResultLocationDto> GetByIdAForContentsync(int id);
	}
}
