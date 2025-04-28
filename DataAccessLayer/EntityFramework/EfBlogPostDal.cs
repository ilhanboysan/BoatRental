using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entites;

namespace DataAccessLayer.EntityFramework
{
	public class EfBlogPostDal : GenericRepository<BlogPost>, IBlogPostDal
	{
		public EfBlogPostDal(Context context) : base(context)
		{
		}
	}
}
