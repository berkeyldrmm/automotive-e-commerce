using BusinessLayer.Abstract;
using DataAccessLayer.Abstraact;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        private readonly IKullaniciDal KullaniciDal;

        public KullaniciManager(IKullaniciDal kullaniciService)
        {
			KullaniciDal = kullaniciService;
        }
        public void TEkle(Kullanici entity)
        {
            throw new NotImplementedException();
        }

        public void TGunceller(Kullanici entity)
        {
            throw new NotImplementedException();
        }

        public List<Kullanici> TListeGetir()
        {
            throw new NotImplementedException();
        }

        public void TSil(Kullanici entity)
        {
            throw new NotImplementedException();
        }

        public Kullanici TItemGetir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
