using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.SiparisDetay
{
    public class SiparisDetayDTO
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public double Fiyat { get; set; }
        public int Miktar { get; set; }
        public int Stok { get; set; }
    }
}
