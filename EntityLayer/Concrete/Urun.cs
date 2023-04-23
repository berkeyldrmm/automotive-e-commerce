using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string UstKategori { get; set; }
        public string Kategori { get; set; }
        public string Marka { get; set; }
        public string Aciklama { get; set; }
        public ICollection<SiparisDetay> Siparisler { get; set; }
        //public ICollection<SiparisDetay> Siparisler { get; set; }
    }
}
