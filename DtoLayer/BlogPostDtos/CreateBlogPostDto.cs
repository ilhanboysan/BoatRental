namespace DtoLayer.BlogPostDtos
{
	public class CreateBlogPostDto
	{
		public string Image { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime Date { get; set; }
		public string? Author { get; set; }
		public bool IsPublished { get; set; }
	}
}
