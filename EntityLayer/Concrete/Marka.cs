using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Marka
    {
        public int MarkaId { get; set; }
        public string? MarkaAdi { get; set; }
        public string? MarkaKod { get; set; }
        [ForeignKey(nameof(UrunCesit))]
        public int UrunCesitId { get; set; }
        public UrunCesit? UrunCesidi { get; set; }
        public List<Urun> Urunler { get; set; }
    }
}
