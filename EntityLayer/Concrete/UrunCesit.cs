using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UrunCesit
    {
        public int UrunCesitId { get; set; }
        public string CesitAdi { get; set; }
        public string CesitKod { get; set; }
        public List<Kategori> Kategoriler { get; set; }
        public List<Urun> Urunler { get; set; }
    }
}
