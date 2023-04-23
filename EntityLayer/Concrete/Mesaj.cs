using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Mesaj
    {
        public int MesajId { get; set; }
        public string MesajSahibiIsim { get;}
        public string MesajSahibiSoyisim { get;}
        public string? MesajSahibiTelefon { get;}
        public string MesajSahibiMail { get;}
        public string TextMesaj { get;}
    }
}
