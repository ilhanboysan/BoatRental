using Newtonsoft.Json;
using System.Text;
using UILayer.Dtos.LocationDtos;

namespace UILayer.Services.LocationServices
{
	public class LocationService : ILocationService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public LocationService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<string> CreateLocationAsync(CreateLocationDto createLocationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonContent = JsonConvert.SerializeObject(createLocationDto);
			var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("https://localhost:7129/api/Locations", content);

			if (response.IsSuccessStatusCode)
			{
				return "Konum Başarıyla Eklendi";
			}
			return "Konum Ekleme Başarısız oldu";
		}

		public async Task<string> DeleteLocationAsync(int LocationId)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7129/api/Locations/{LocationId}");

			return response.IsSuccessStatusCode ? "Konum Başarıyla Silindi" : "Konum Silme Başarısız oldu";
		}

		public async Task<List<ResultLocationDto>> GetAllLocationAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7129/api/Locations");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var boats = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
				return boats ?? new List<ResultLocationDto>();
			}
			return new List<ResultLocationDto>();
		}

		public async Task<ResultLocationDto> GetByIdAForContentsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7129/api/Locations/{id}");

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				var boat = JsonConvert.DeserializeObject<ResultLocationDto>(json);
				return boat!;
			}
			return null!;
		}

		public async Task<UpdateLocationDto> GetByIdAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7129/api/Locations/{id}");

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				var boat = JsonConvert.DeserializeObject<UpdateLocationDto>(json);
				return boat!;
			}
			return null!;
		}

		public async Task<bool> UpdateLocationAsync(UpdateLocationDto updateLocationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(updateLocationDto);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PutAsync("https://localhost:7129/api/Locations", content);
			return response.IsSuccessStatusCode;
		}
	}
}
