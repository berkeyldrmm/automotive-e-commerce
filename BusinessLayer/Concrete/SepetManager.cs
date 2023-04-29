using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
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
        private readonly SepetDTO Sepet;
        private readonly IUrunService UrunManager;
        public SepetManager(SepetDTO sepet, IUrunService urunManager) {
            Sepet=sepet;
            UrunManager = urunManager;
		}
        public void SepeteEkle(UrunDTO sepetitem)
        {
            foreach (var sepeturun in Sepet.sepetUrunler)
            {
                if(sepeturun.Urun.UrunId == sepetitem.UrunId)
                {
                    SepetUrunMiktarArttir(sepeturun.Urun.UrunId);
                    return;
                }
            } 
            var urun= UrunManager.TItemGetir(sepetitem.UrunId);
            var SepetItemDTO = new SepetItemDTO() { Urun = urun, miktar = Convert.ToInt32(sepetitem.miktar) };
            ValidateMiktar.MiktarValidator(SepetItemDTO);
			Sepet.sepetUrunler.Add(SepetItemDTO);
        }

        public void SepetiBosalt()
        {
			Sepet.sepetUrunler = new List<SepetItemDTO>();
        }

        public void SepettenCikar(int id)
        {
            SepetItemDTO silinecekurun = SepetUrunGetir(id);
			Sepet.sepetUrunler.Remove(silinecekurun);
        }

        public SepetItemDTO SepetUrunGetir(int id)
        {
            SepetItemDTO urun = Sepet.sepetUrunler.SingleOrDefault(sepetItem => sepetItem.Urun.UrunId == id);
            return urun;
        }

        public void SepetUrunMiktarArttir(int id)
        {
            SepetItemDTO urun = SepetUrunGetir(id);
            urun.miktar++;
            ValidateMiktar.MiktarValidator(SepetUrunGetir(id));
        }

        public void SepetUrunMiktarAzalt(int id)
        {
			SepetItemDTO urun = this.SepetUrunGetir(id);
            urun.miktar--;
            ValidateMiktar.MiktarValidator(SepetUrunGetir(id));
        }
    }
}
