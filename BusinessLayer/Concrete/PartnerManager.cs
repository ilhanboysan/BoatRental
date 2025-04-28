using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;

namespace BusinessLayer.Concrete
{
	public class PartnerManager : IPartnerService
	{

		private readonly IPartnerDal _PartnerDal;

		public PartnerManager(IPartnerDal PartnerDal)
		{
			_PartnerDal = PartnerDal;
		}

		public void TAdd(Partner entity)
		{
			_PartnerDal.Add(entity);
		}

		public void TDelete(Partner entity)
		{
			_PartnerDal.Delete(entity);
		}

		public Partner TGetByID(int id)
		{
			return _PartnerDal.GetByID(id);
		}

		public List<Partner> TGetListAll()
		{
			return _PartnerDal.GetListAll();
		}

		public void TUpdate(Partner entity)
		{
			_PartnerDal.Update(entity);
		}
	}
}
