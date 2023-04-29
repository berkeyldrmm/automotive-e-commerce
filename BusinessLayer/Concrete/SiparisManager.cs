using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.Siparis;
using EntityLayer.Concrete;
using Otomativ_e_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SiparisManager : ISiparisService
    {
		//Dependency Injection
		private readonly ISiparisDal SiparisDal;
		private readonly IUrunService UrunService;

		public SiparisManager(ISiparisDal siparisDal, IUrunService urunService)
        {
            SiparisDal = siparisDal;
			UrunService = urunService;
		}
        public void TEkle(Siparis entity)
        {
            SiparisDal.Ekle(entity);
        }

        public void TGunceller(Siparis entity)
        {
            SiparisDal.Guncelle(entity);
        }

        public List<Siparis> TListeGetir()
        {
            return SiparisDal.ListeGetir();
        }

        public void TSil(Siparis entity)
        {
            SiparisDal.Sil(entity);
        }

        public Siparis TItemGetir(int id)
        {
            return SiparisDal.ItemGetir(id);
        }

		public Siparis SiparisOlustur(SepetDTO sepet, SiparisDTO siparisDTO, Urun GuncelUrun, HashSet<SiparisDetay> siparisDetay)
		{
			double SiparisTutari = 0;
			foreach (var urun in sepet.sepetUrunler)
			{
				GuncelUrun = urun.Urun;
				GuncelUrun.Stok -= urun.miktar;
				UrunService.TGunceller(GuncelUrun);
				SiparisTutari += urun.Urun.Fiyat * urun.miktar;
				siparisDetay.Add(new SiparisDetay() { UrunId = urun.Urun.UrunId, Miktar = urun.miktar });
			}
			var siparis = new Siparis()
			{
				Isim = siparisDTO.ad,
				Soyisim = siparisDTO.soyad,
				TelefonNo = siparisDTO.telefon,
				Mail = siparisDTO.email,
				Adres = siparisDTO.adres,
				SiparisZamani = DateTime.Now,
				SiparisDetayi = siparisDetay,
				SiparisTutari = SiparisTutari,
				StatusId = 1
			};

			return siparis;
		}
	}
}
