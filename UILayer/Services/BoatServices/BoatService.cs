using Newtonsoft.Json;
using System.Text;
using UILayer.Dtos.BoatDtos;

namespace UILayer.Services.BoatServices
{
    public class BoatService : IBoatService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BoatService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<ResultBoatDto>> GetAllBoatAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7129/api/Boats");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var boats = JsonConvert.DeserializeObject<List<ResultBoatDto>>(jsonData);
                return boats ?? new List<ResultBoatDto>();
            }
            return new List<ResultBoatDto>();
        }

        public async Task<List<ResultBoatDto>> GetFeaturedBoatAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7129/api/Boats/FeaturedBoats");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var boats = JsonConvert.DeserializeObject<List<ResultBoatDto>>(jsonData);
                return boats ?? new List<ResultBoatDto>();
            }
            return new List<ResultBoatDto>();
        }
        public async Task<ResultBoatDto> GetByIdAForContentsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7129/api/Boats/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var boat = JsonConvert.DeserializeObject<ResultBoatDto>(json);
                return boat!;
            }
            return null!;
        }
        public async Task<string> CreateBoatAsync(CreateBoatDto createBoatDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonContent = JsonConvert.SerializeObject(createBoatDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7129/api/Boats", content);

            if (response.IsSuccessStatusCode)
            {
                return "Tekne Başarıyla Eklendi";
            }
            return "Tekne Ekleme Başarısız oldu";
        }
        public async Task<string> DeleteBoatAsync(int boatId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7129/api/Boats/{boatId}");

            return response.IsSuccessStatusCode ? "Tekne Başarıyla Silindi" : "Tekne Silme Başarısız oldu";
        }

        public async Task<UpdateBoatDto> GetByIdAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7129/api/Boats/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var boat = JsonConvert.DeserializeObject<UpdateBoatDto>(json);
                return boat!;
            }
            return null!;
        }

        public async Task<bool> UpdateBoatAsync(UpdateBoatDto updateBoatDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateBoatDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7129/api/Boats", content);
            return response.IsSuccessStatusCode;
        }

    }
}
