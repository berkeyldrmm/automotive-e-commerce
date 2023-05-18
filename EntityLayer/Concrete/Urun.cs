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
        [Required(ErrorMessage ="Bu kısım boş geçilemez.")]
        public string UrunAdi { get; set; }
		[Required(ErrorMessage = "Bu kısım boş geçilemez.")]
		[Range(0, 250, ErrorMessage = "Stok bilgisi 0'dan küçük, 250'den büyük girilemez.")]
		public int Stok { get; set; }
        [Required(ErrorMessage = "Bu kısım boş geçilemez.")]
		[Range(0, double.MaxValue, ErrorMessage = "Fiyat bilgisi 0'dan küçük girilemez.")]
		public double Fiyat { get; set; }
        public string? GorselUrl { get; set; }
        [ForeignKey(nameof(UrunCesit))]
        public int UrunCesitId { get; set; }
        public UrunCesit? UrunCesidi { get; set; }
        [ForeignKey(nameof(Kategori))]
        public int KategoriId { get; set; }
        public Kategori? kategori { get; set; }
        [ForeignKey(nameof(Marka))]
        public int MarkaId { get; set; }
        public Marka? marka { get; set; }
        public string? Aciklama { get; set; }
        public ICollection<SiparisDetay>? Siparisler { get; set; }
    }
}
