using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entites;

namespace DataAccessLayer.EntityFramework
{
	public class EfLocationDal : GenericRepository<Location>, ILocationDal
	{
		public EfLocationDal(Context context) : base(context)
		{
		}
	}
}
