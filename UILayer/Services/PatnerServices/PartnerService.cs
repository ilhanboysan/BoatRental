using Newtonsoft.Json;
using System.Text;
using UILayer.Dtos.PartnerDtos;

namespace UILayer.Services.PatnerServices
{
	public class PartnerService : IPartnerService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public PartnerService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<string> CreatePartnerAsync(CreatePartnerDto createPartnerDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonContent = JsonConvert.SerializeObject(createPartnerDto);
			var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("https://localhost:7129/api/Partners", content);

			if (response.IsSuccessStatusCode)
			{
				return "Blog Yazısı Başarıyla Eklendi";
			}
			return "Blog Yazısı Ekleme Başarısız oldu";
		}

		public async Task<string> DeletePartnerAsync(int PartnerId)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7129/api/Partners/{PartnerId}");

			return response.IsSuccessStatusCode ? "Blog Yazısı Başarıyla Silindi" : "Blog Yazısı Silme Başarısız oldu";
		}

		public async Task<List<ResultPartnerDto>> GetAllPartnerAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7129/api/Partners");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var boats = JsonConvert.DeserializeObject<List<ResultPartnerDto>>(jsonData);
				return boats ?? new List<ResultPartnerDto>();
			}
			return new List<ResultPartnerDto>();
		}



		public async Task<UpdatePartnerDto> GetByIdAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7129/api/Partners/{id}");

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				var boat = JsonConvert.DeserializeObject<UpdatePartnerDto>(json);
				return boat!;
			}
			return null!;
		}

		public async Task<bool> UpdatePartnerAsync(UpdatePartnerDto updatePartnerDto)
		{
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(updatePartnerDto);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PutAsync("https://localhost:7129/api/Partners", content);
			return response.IsSuccessStatusCode;
		}
	}
}
