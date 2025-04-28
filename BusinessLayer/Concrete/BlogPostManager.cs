using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;

namespace BusinessLayer.Concrete
{
	public class BlogPostManager : IBlogPostService
	{
		private readonly IBlogPostDal _blogPostDal;

		public BlogPostManager(IBlogPostDal blogPostDal)
		{
			_blogPostDal = blogPostDal;
		}

		public void TAdd(BlogPost entity)
		{
			_blogPostDal.Add(entity);
		}

		public void TDelete(BlogPost entity)
		{
			_blogPostDal.Delete(entity);
		}

		public BlogPost TGetByID(int id)
		{
			return _blogPostDal.GetByID(id);
		}

		public List<BlogPost> TGetListAll()
		{
			return _blogPostDal.GetListAll();
		}

		public void TUpdate(BlogPost entity)
		{
			_blogPostDal.Update(entity);
		}
	}
}
