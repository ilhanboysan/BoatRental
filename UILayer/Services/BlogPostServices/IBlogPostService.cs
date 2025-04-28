using UILayer.Dtos.BlogPostDtos;

namespace UILayer.Services.BlogPostServices
{
    public interface IBlogPostService
    {
        Task<List<ResultBlogPostDto>> GetAllBlogPostAsync();
        Task<string> CreateBlogPostAsync(CreateBlogPostDto createBlogPostDto);
        Task<string> DeleteBlogPostAsync(int BlogPostId);
        Task<UpdateBlogPostDto> GetByIdAsync(int id);
        Task<bool> UpdateBlogPostAsync(UpdateBlogPostDto updateBlogPostDto);
        Task<ResultBlogPostDto> GetByIdAForContentsync(int id);
    }
}
