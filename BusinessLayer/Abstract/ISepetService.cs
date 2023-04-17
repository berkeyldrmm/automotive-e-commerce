using Otomativ_e_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISepetService
    {
        public SepetItemDTO SepetUrunGetir(int id);
        public void SepeteEkle(int UrunId, string miktar);
        public void SepettenCikar(int id);
        public void SepetUrunMiktarArttir(int id);
        public void SepetUrunMiktarAzalt(int id);
        public void SepetiBosalt();

    }
}
