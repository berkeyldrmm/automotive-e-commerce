using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.SiparisDetay;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SiparisDetayManager : ISiparisDetayService
    {
        public ISiparisDetayDal SiparisDetayDal { get; set; }

        public SiparisDetayManager(ISiparisDetayDal siparisDetayService)
        {
            SiparisDetayDal = siparisDetayService;
        }

        public void TEkle(SiparisDetay entity)
        {
            SiparisDetayDal.Ekle(entity);
        }

        public void TGunceller(SiparisDetay entity)
        {
            SiparisDetayDal.Guncelle(entity);
        }

        public SiparisDetay TItemGetir(int id)
        {
            return SiparisDetayDal.ItemGetir(id);
        }

        public List<SiparisDetay> TListeGetir()
        {
            return SiparisDetayDal.ListeGetir();
        }

        public void TSil(SiparisDetay entity)
        {
            SiparisDetayDal.Sil(entity);
        }

        public List<SiparisDetayDTO> SiparisDetayOlustur(int id)
        {
            return SiparisDetayDal.SiparisDetayOlustur(id);
        }
    }
}
