namespace UILayer.Dtos.BlogPostDtos
{
    public class GetBlogPostDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string? Author { get; set; }
        public bool IsPublished { get; set; }
    }
}
