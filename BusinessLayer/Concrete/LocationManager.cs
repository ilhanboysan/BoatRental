using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;

namespace BusinessLayer.Concrete
{
	public class LocationManager : ILocationService
	{
		private readonly ILocationDal _LocationDal;

		public LocationManager(ILocationDal LocationDal)
		{
			_LocationDal = LocationDal;
		}

		public void TAdd(Location entity)
		{
			_LocationDal.Add(entity);
		}

		public void TDelete(Location entity)
		{
			_LocationDal.Delete(entity);
		}

		public Location TGetByID(int id)
		{
			return _LocationDal.GetByID(id);
		}

		public List<Location> TGetListAll()
		{
			return _LocationDal.GetListAll();
		}

		public void TUpdate(Location entity)
		{
			_LocationDal.Update(entity);
		}
	}
}
