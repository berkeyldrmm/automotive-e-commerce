using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SiparisDetay
    {
        public int SiparisDetayId { get; set; }
        [ForeignKey(nameof(Urun))]
        public int UrunId { get; set; }
        public Urun Urun { get; set; }
        public int Miktar { get; set; }
        public Siparis Siparis { get; set; }
    }
}
