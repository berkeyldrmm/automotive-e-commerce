using DataAccessLayer.Abstraact;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity_Framework
{
    public class EfUrun : GenericRepository<Urun>, IUrunDal
    {
        public List<Urun> KategoriUrun(string category)
        {
            using var c = new Context();
            var urunler= (from urun in c.Urunler
                   where urun.kategori.KategoriKod == category
                    select urun).ToList();
            return urunler;
        }
        public List<Urun> KategoriMarkaUrun(string category, string marka)
        {
            using var c = new Context();
            var markaliurunler = (from urun in c.Urunler
                           where urun.kategori.KategoriKod == category && urun.marka.MarkaKod == marka
                           select urun).ToList();
            return markaliurunler;
        }

        public List<Urun> FiyatFiltreleme(List<Urun> urunler, double enaz, double enfazla)
        {
            var filtrelenmisurunler = urunler.Where(u => u.Fiyat <= enfazla).Where(u => u.Fiyat >= enaz).ToList();
            return filtrelenmisurunler;
        }

        public List<Urun> Sirala(List<Urun> urunler, string sira)
        {
            var siraliurunler=new List<Urun>();
            if (sira == "artan")
            {
                siraliurunler = urunler.OrderBy(u => u.Fiyat).ToList();
            }
            else
            {
                siraliurunler= urunler.OrderByDescending(u => u.Fiyat).ToList();
            }
            return siraliurunler;
        }

        public List<Urun> ParcalariGetir()
        {
            using var c = new Context();
            var parcalar= (from urun in c.Urunler
                           where urun.UrunCesidi.CesitKod == "parca"
                           select urun).ToList();
            return parcalar;
        }

    }
}
