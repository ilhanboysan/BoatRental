using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UILayer.Services.BlogPostServices;

namespace UILayer.Controllers
{
    [AllowAnonymous]
    public class BlogPostController : Controller
    {
        private readonly IBlogPostService _BlogPostService;

        public BlogPostController(IBlogPostService BlogPostService)
        {
            _BlogPostService = BlogPostService;
        }

        public async Task<IActionResult> Index()
        {
            var BlogPostList = await _BlogPostService.GetAllBlogPostAsync();
            var PublishedPosts = BlogPostList.Where(post => post.IsPublished).OrderByDescending(post => post.Date).ToList();
            return View(PublishedPosts);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var blogPost = await _BlogPostService.GetByIdAForContentsync(id);
            if (blogPost == null || !blogPost.IsPublished)
            {
                return NotFound();
            }
            return View(blogPost);
        }
    }
}
