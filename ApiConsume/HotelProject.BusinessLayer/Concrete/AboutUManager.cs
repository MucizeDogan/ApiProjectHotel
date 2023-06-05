using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AboutUManager : IAboutService
    {
        private readonly IAboutUDal _aboutUDal;

        public AboutUManager(IAboutUDal aboutUDal)
        {
            _aboutUDal = aboutUDal;
        }

        public void TDelete(AboutU t)
        {
            _aboutUDal.Delete(t);
        }

        public AboutU TGetById(int id)
        {
            return _aboutUDal.GetById(id);
             
        }

        public List<AboutU> TGetList()
        {
            return _aboutUDal.GetList();
             
        }

        public void TInsert(AboutU t)
        {
            _aboutUDal.Insert(t);
        }

        public void TUpdate(AboutU t)
        {
            _aboutUDal.Update(t);
        }
    }
}
