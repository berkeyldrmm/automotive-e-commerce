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
    public class UrunManager : IUrunService
    {
        private readonly IUrunDal UrunDal;

        public UrunManager(IUrunDal urunService)
        {
            UrunDal = urunService;
        }

        public List<Urun> TListeGetir()
        {
            return UrunDal.ListeGetir();
        }

        public void TEkle(Urun entity)
        {
            UrunDal.Ekle(entity);
        }

        public void TGunceller(Urun entity)
        {
            UrunDal.Guncelle(entity);
        }

        public void TSil(Urun entity)
        {
            UrunDal.Sil(entity);
        }

        public List<Urun> KategoriUrun(string category)
        {
            return UrunDal.KategoriUrun(category);
        }

        public List<Urun> KategoriMarkaUrun(List<Urun> urunler, string marka)
        {
            return UrunDal.KategoriMarkaUrun(urunler, marka);
        }

        public List<Urun> FiyatFiltrele(List<Urun> urunler, double enaz, double enfazla)
        {
            return UrunDal.FiyatFiltreleme(urunler, enaz, enfazla);
        }

        public List<Urun> Sirala(List<Urun> urunler, string sira)
        {
            return UrunDal.Sirala(urunler, sira);
        }

        public List<Urun> ParcalariGetir()
        {
            return UrunDal.ParcalariGetir();
        }

        public Urun TItemGetir(int id)
        {
            return UrunDal.ItemGetir(id);
        }
    }
}
