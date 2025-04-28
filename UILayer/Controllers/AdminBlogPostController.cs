using Microsoft.AspNetCore.Mvc;
using UILayer.Dtos.BlogPostDtos;
using UILayer.Services.BlogPostServices;

namespace UILayer.Controllers
{
    public class AdminBlogPostController : Controller
    {
        private readonly IBlogPostService _BlogPostService;

        public AdminBlogPostController(IBlogPostService BlogPostService)
        {
            _BlogPostService = BlogPostService;
        }

        public async Task<IActionResult> Index()
        {
            var BlogPostList = await _BlogPostService.GetAllBlogPostAsync();
            return View(BlogPostList);
        }
        [HttpGet]
        public IActionResult CreateBlogPost()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogPost(CreateBlogPostDto createBlogPostDto)
        {
            var responseMessage = await _BlogPostService.CreateBlogPostAsync(createBlogPostDto);

            if (responseMessage == "Blog Yazısı Başarıyla Eklendi")
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            var message = await _BlogPostService.DeleteBlogPostAsync(id);
            TempData["DeleteMessage"] = message;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBlogPost(int id)
        {
            var BlogPost = await _BlogPostService.GetByIdAsync(id);
            if (BlogPost == null)
            {
                return NotFound();
            }
            return View(BlogPost);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlogPost(UpdateBlogPostDto updateBlogPostDto)
        {

            var result = await _BlogPostService.UpdateBlogPostAsync(updateBlogPostDto);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(updateBlogPostDto);
        }

    }
}
