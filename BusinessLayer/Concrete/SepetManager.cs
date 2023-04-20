using BusinessLayer.Abstract;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.Sepet;
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
        public UrunManager urunManager { get {
                return new UrunManager(new EfUrun());
			} 
        }
        public SepetManager(SepetDTO sepet) {
            this.sepet=sepet;
        }
        public void SepeteEkle(UrunDTO sepetitem)
        {
            var urun=urunManager.TItemGetir(sepetitem.UrunId);
            var SepetItemDTO = new SepetItemDTO() { Urun = urun, miktar = Convert.ToInt32(sepetitem.miktar) };
            sepet.sepetUrunler.Add(SepetItemDTO);
        }

        public void SepetiBosalt()
        {
            sepet.sepetUrunler = new List<SepetItemDTO>();
        }

        public void SepettenCikar(int id)
        {
            SepetItemDTO silinecekurun=sepet.sepetUrunler.SingleOrDefault(sepetItem=>sepetItem.Urun.UrunId== id);
            sepet.sepetUrunler.Remove(silinecekurun);
        }

        public SepetItemDTO SepetUrunGetir(int id)
        {
            SepetItemDTO urun = sepet.sepetUrunler.SingleOrDefault(sepetItem => sepetItem.Urun.UrunId == id);
            return urun;
        }

        public void SepetUrunMiktarArttir(int id)
        {
            SepetItemDTO urun = sepet.sepetUrunler.SingleOrDefault(sepetItem => sepetItem.Urun.UrunId == id);
            if (urun.miktar <= 10)
            {
				urun.miktar++;
			}
            else
            {
                //throw new Error();
            }

        }

        public void SepetUrunMiktarAzalt(int id)
        {
			SepetItemDTO urun = sepet.sepetUrunler.SingleOrDefault(sepetItem => sepetItem.Urun.UrunId == id);
			if (urun.miktar != 1)
			{
				urun.miktar--;
			}
			else
			{
				throw new Exception();
			}
		}
    }
}
