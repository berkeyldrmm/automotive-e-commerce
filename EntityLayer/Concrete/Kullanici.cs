using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }
        public string Kullaniciadi { get; set; }
        public string Sifre { get; set; }
        public string Siparisler { get; set; }
    }
}
