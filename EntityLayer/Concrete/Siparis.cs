using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Siparis
    {
        public Siparis()
        {
            SiparisDetayi = new HashSet<SiparisDetay>();
        }
        public int SiparisId { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Adres { get; set; }
        public string TelefonNo { get; set; }
        public string? Mail { get; set; }
        public ICollection<SiparisDetay> SiparisDetayi { get; set; }
        public DateTime SiparisZamani { get; set; }
        public double SiparisTutari { get; set; }
        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
