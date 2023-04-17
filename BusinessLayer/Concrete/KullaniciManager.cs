using BusinessLayer.Abstract;
using DataAccessLayer.Abstraact;
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
        private IUrunDal UrunDal { get; set; }

        public KullaniciManager(IUrunDal urunService)
        {
            UrunDal = urunService;
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
