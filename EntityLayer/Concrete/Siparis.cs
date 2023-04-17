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
        public string UrunId { get; set; }
        public string SiparisMiktari { get; set; }
        public string Adres { get; set; }
        public string SiparisZamani { get; set; }
        public double SiparisTutari { get; set; }
    }
}
