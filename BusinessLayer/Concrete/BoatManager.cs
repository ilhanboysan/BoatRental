using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;

namespace BusinessLayer.Concrete
{

    public class BoatManager : IBoatService
    {
        private readonly IBoatDal _BoatDal;

        public BoatManager(IBoatDal BoatDal)
        {
            _BoatDal = BoatDal;
        }

        public void TAdd(Boat entity)
        {
            _BoatDal.Add(entity);
        }

        public void TDelete(Boat entity)
        {
            _BoatDal.Delete(entity);
        }

        public Boat TGetByID(int id)
        {
            return _BoatDal.GetByID(id);
        }

        public List<Boat> TGetListAll()
        {
            return _BoatDal.GetListAll();
        }

        public void TUpdate(Boat entity)
        {
            _BoatDal.Update(entity);
        }
    }
}

