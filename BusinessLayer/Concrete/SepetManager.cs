using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Otomativ_e_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SepetManager : ISepetService
    {
        public SepetDTO sepet { get; set; }
        public SepetManager(SepetDTO sepet) {
            this.sepet=sepet;
        }
        public void SepeteEkle(int UrunId,string miktar)
        {
            var SepetItemDTO = new SepetItemDTO() { UrunId = UrunId, miktar = Convert.ToInt32(miktar) };
            sepet.sepetUrunler.Add(SepetItemDTO);
        }

        public void SepetiBosalt()
        {
            sepet.sepetUrunler = new List<SepetItemDTO>();
        }

        public void SepettenCikar(int id)
        {
            SepetItemDTO silinecekurun=sepet.sepetUrunler.SingleOrDefault(sepetItem=>sepetItem.UrunId== id);
            sepet.sepetUrunler.Remove(silinecekurun);
        }

        public SepetItemDTO SepetUrunGetir(int id)
        {
            SepetItemDTO urun = sepet.sepetUrunler.SingleOrDefault(sepetItem => sepetItem.UrunId == id);
            return urun;
        }

        public void SepetUrunMiktarArttir(int id)
        {
            SepetItemDTO urun = sepet.sepetUrunler.SingleOrDefault(sepetItem => sepetItem.UrunId == id);
            urun.miktar++;

        }

        public void SepetUrunMiktarAzalt(int id)
        {
            SepetItemDTO urun = sepet.sepetUrunler.SingleOrDefault(sepetItem => sepetItem.UrunId == id);
            urun.miktar--;
        }
    }
}
