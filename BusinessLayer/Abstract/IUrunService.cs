using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUrunService : IGenericService<Urun>
    {
        public List<Urun> KategoriUrun(string category);
        public List<Urun> KategoriMarkaUrun(string category, string marka);
        public List<Urun> FiyatFiltrele(List<Urun> urunler, double enaz, double enfazla);
        public List<Urun> Sirala(List<Urun> urunler, string sira);
        public List<Urun> ParcalariGetir();

    }
}
