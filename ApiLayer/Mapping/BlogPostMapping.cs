using AutoMapper;
using DtoLayer.BlogPostDtos;
using EntityLayer.Entites;

namespace ApiLayer.Mapping
{
	public class BlogPostMapping : Profile
	{
		public BlogPostMapping()
		{
			CreateMap<BlogPost, ResultBlogPostDto>().ReverseMap();
			CreateMap<BlogPost, CreateBlogPostDto>().ReverseMap();
			CreateMap<BlogPost, GetBlogPostDto>().ReverseMap();
			CreateMap<BlogPost, UpdateBlogPostDto>().ReverseMap();
		}
	}
}
