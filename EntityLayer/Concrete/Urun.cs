using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int Stok { get; set; }
        public double Fiyat { get; set; }
        public string? GorselUrl { get; set; }
        [ForeignKey(nameof(UrunCesit))]
        public int UrunCesitId { get; set; }
        public UrunCesit UrunCesidi { get; set; }
        [ForeignKey(nameof(Kategori))]
        public int KategoriId { get; set; }
        public Kategori kategori { get; set; }
        [ForeignKey(nameof(Marka))]
        public int MarkaId { get; set; }
        public Marka marka { get; set; }
        public string? Aciklama { get; set; }
        public ICollection<SiparisDetay>? Siparisler { get; set; }
    }
}
