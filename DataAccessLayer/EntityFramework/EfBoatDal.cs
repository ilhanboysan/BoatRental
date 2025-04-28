using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entites;

namespace DataAccessLayer.EntityFramework
{
    public class EfBoatDal : GenericRepository<Boat>, IBoatDal
    {
        public EfBoatDal(Context context) : base(context)
        {
        }
    }
}
