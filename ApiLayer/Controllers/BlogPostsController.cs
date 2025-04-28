using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.BlogPostDtos;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogPostsController : ControllerBase
	{
		private readonly IBlogPostService _blogPostService;
		private readonly IMapper _mapper;

		public BlogPostsController(IBlogPostService blogPostService, IMapper mapper)
		{
			_blogPostService = blogPostService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult BlogPostList()
		{
			var values = _blogPostService.TGetListAll();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public IActionResult GetByIdBlogPost(int id)
		{
			var value = _blogPostService.TGetByID(id);
			if (value == null)
				return NotFound();

			var dto = _mapper.Map<GetBlogPostDto>(value);
			return Ok(dto);
		}
		[HttpPost]
		public IActionResult CreateBlogPost(CreateBlogPostDto createBlogPostDto)
		{
			var blogPost = _mapper.Map<BlogPost>(createBlogPostDto);
			_blogPostService.TAdd(blogPost);
			return Ok("Blog Yazısı Başarıyla Eklendi");
		}
		[HttpPut]
		public IActionResult UpdateBlogPost(UpdateBlogPostDto updateBlogPostDto)
		{
			var existing = _blogPostService.TGetByID(updateBlogPostDto.Id);
			if (existing == null)
				return NotFound();

			_mapper.Map(updateBlogPostDto, existing); // Sadece gelen alanları günceller
			_blogPostService.TUpdate(existing);
			return Ok("Blog Yazısı Başarıyla Güncellendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBlogPost(int id)
		{
			var value = _blogPostService.TGetByID(id);
			if (value == null)
				return NotFound();

			_blogPostService.TDelete(value);
			return Ok("Blog Yazısı Silindi");
		}
	}
}
