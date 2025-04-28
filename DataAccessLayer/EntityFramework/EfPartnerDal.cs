using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entites;

namespace DataAccessLayer.EntityFramework
{
	public class EfPartnerDal : GenericRepository<Partner>, IPartnerDal
	{
		public EfPartnerDal(Context context) : base(context)
		{
		}
	}
}
