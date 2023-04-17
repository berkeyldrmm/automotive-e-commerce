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
    internal class SiparisManager : ISiparisService
    {
        private IUrunDal UrunDal { get; set; }

        public SiparisManager(IUrunDal urunService)
        {
            UrunDal = urunService;
        }
        public void TEkle(Siparis entity)
        {
            throw new NotImplementedException();
        }

        public void TGunceller(Siparis entity)
        {
            throw new NotImplementedException();
        }

        public List<Siparis> TListeGetir()
        {
            throw new NotImplementedException();
        }

        public void TSil(Siparis entity)
        {
            throw new NotImplementedException();
        }

        public Siparis TItemGetir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
