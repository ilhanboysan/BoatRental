using Newtonsoft.Json;
using System.Text;
using UILayer.Dtos.BlogPostDtos;

namespace UILayer.Services.BlogPostServices
{
	public class BlogPostService : IBlogPostService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BlogPostService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<string> CreateBlogPostAsync(CreateBlogPostDto createBlogPostDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonContent = JsonConvert.SerializeObject(createBlogPostDto);
			var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("https://localhost:7129/api/BlogPosts", content);

			if (response.IsSuccessStatusCode)
			{
				return "Blog Yazısı Başarıyla Eklendi";
			}
			return "Blog Yazısı Ekleme Başarısız oldu";
		}

		public async Task<string> DeleteBlogPostAsync(int BlogPostId)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7129/api/BlogPosts/{BlogPostId}");

			return response.IsSuccessStatusCode ? "Blog Yazısı Başarıyla Silindi" : "Blog Yazısı Silme Başarısız oldu";
		}

		public async Task<List<ResultBlogPostDto>> GetAllBlogPostAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7129/api/BlogPosts");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var boats = JsonConvert.DeserializeObject<List<ResultBlogPostDto>>(jsonData);
				return boats ?? new List<ResultBlogPostDto>();
			}
			return new List<ResultBlogPostDto>();
		}

		public async Task<ResultBlogPostDto> GetByIdAForContentsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7129/api/BlogPosts/{id}");

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				var boat = JsonConvert.DeserializeObject<ResultBlogPostDto>(json);
				return boat!;
			}
			return null!;
		}

		public async Task<UpdateBlogPostDto> GetByIdAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7129/api/BlogPosts/{id}");

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				var boat = JsonConvert.DeserializeObject<UpdateBlogPostDto>(json);
				return boat!;
			}
			return null!;
		}

		public async Task<bool> UpdateBlogPostAsync(UpdateBlogPostDto updateBlogPostDto)
		{
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(updateBlogPostDto);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PutAsync("https://localhost:7129/api/BlogPosts", content);
			return response.IsSuccessStatusCode;
		}
	}
}
