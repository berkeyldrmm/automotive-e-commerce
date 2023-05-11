using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using DTOLayer.DTOs.SiparisDetay;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity_Framework
{
    public class EfSiparisDetay : GenericRepository<SiparisDetay>, ISiparisDetayDal
    {
        public List<SiparisDetayDTO> SiparisDetayOlustur(int id)
        {
            using var c = new Context();
            List<SiparisDetayDTO> siparisDetaylari = (from siparisdetay in c.SiparisDetaylari
                                                  join urun in c.Urunler on siparisdetay.UrunId equals urun.UrunId
                                                  where siparisdetay.SiparisId==id
                                                  select new SiparisDetayDTO()
                                                  {
                                                      UrunId=urun.UrunId,
                                                      UrunAdi=urun.UrunAdi,
                                                      Fiyat=urun.Fiyat,
                                                      Stok=urun.Stok,
                                                      Miktar=siparisdetay.Miktar
                                                  }).ToList();
            return siparisDetaylari;
        }
    }
}
