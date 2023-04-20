using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Siparis
    {
        public int SiparisId { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Adres { get; set; }
        public string TelefonNo { get; set; }
        public string Mail { get; set; }
        public ICollection<Urun> Urunler { get; set; }
        public string Adet { get; set; }
        public string SiparisZamani { get; set; }
        public double SiparisTutari { get; set; }
    }
}
