using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Kategori
    {
        public Kategori()
        {
            Urunler = new HashSet<Urun>();
        }
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string KategoriKod { get; set; }
        [ForeignKey(nameof(UrunCesit))]
        public int UrunCesitId { get; set; }
        public UrunCesit? UrunCesidi { get; set; }
        public ICollection<Urun> Urunler { get; set; }
    }
}
