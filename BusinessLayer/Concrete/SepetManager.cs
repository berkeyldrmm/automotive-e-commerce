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
        public SepetDTO sepet { get; set; }
        public UrunManager urunManager { get; set; }
        public SepetManager(SepetDTO sepet) {
            this.sepet=sepet;
            urunManager = new UrunManager(new EfUrun());
        }
        public void SepeteEkle(UrunDTO sepetitem)
        {
            foreach (var sepeturun in sepet.sepetUrunler)
            {
                if(sepeturun.Urun.UrunId == sepetitem.UrunId)
                {
                    SepetUrunMiktarArttir(sepeturun.Urun.UrunId);
                    return;
                }
            } 
            var urun=urunManager.TItemGetir(sepetitem.UrunId);
            var SepetItemDTO = new SepetItemDTO() { Urun = urun, miktar = Convert.ToInt32(sepetitem.miktar) };
            ValidateMiktar.MiktarValidator(SepetItemDTO);
            sepet.sepetUrunler.Add(SepetItemDTO);
        }

        public void SepetiBosalt()
        {
            sepet.sepetUrunler = new List<SepetItemDTO>();
        }

        public void SepettenCikar(int id)
        {
            SepetItemDTO silinecekurun = SepetUrunGetir(id);
            sepet.sepetUrunler.Remove(silinecekurun);
        }

        public SepetItemDTO SepetUrunGetir(int id)
        {
            SepetItemDTO urun = sepet.sepetUrunler.SingleOrDefault(sepetItem => sepetItem.Urun.UrunId == id);
            return urun;
        }

        public void SepetUrunMiktarArttir(int id)
        {
            SepetItemDTO urun = this.SepetUrunGetir(id);
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
