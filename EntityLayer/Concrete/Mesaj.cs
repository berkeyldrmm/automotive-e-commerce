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
        public string MesajSahibiIsimSoyisim { get; set; }
		public string MesajSahibiMail { get; set; }
		public string MesajSahibiTelefon { get; set; }
		public string TextMesaj { get; set; }
		public DateTime MesajZamani { get; set; }
	}
}
