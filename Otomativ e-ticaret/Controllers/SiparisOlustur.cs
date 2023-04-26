using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.Siparis;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.DataProtection;
using Otomativ_e_ticaret.Models;

namespace Otomativ_e_ticaret.Controllers
{
	public static class SiparisOlustur
	{
		public static void siparisOlustur(SiparisDTO siparisDTO, double siparistutari)
		{
			//var guncelurun = new Urun();
			//var siparisdetay = new HashSet<SiparisDetay>();
			

			//var siparis = new Siparis()
			//{
			//	Isim = siparisDTO.ad,
			//	Soyisim = siparisDTO.soyad,
			//	TelefonNo = siparisDTO.telefon,
			//	Mail = siparisDTO.email,
			//	Adres = siparisDTO.adres,
			//	SiparisZamani = DateTime.Now,
			//	SiparisDetayi = siparisdetay,
			//	SiparisTutari = siparistutari,
			//	StatusId = 1
			//};
			//var siparisManager = new SiparisManager(new EfSiparis());

			//siparisManager.TEkle(siparis);
			//sepet.sepetUrunler = new List<SepetItemDTO>();
		}
	}
}
