using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.SifreDegistir;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Otomativ_e_ticaret.Models;
using System.Net;

namespace Otomativ_e_ticaret.Controllers
{
    public class AdminController : Controller
	{
		private readonly IAdminService AdminService;
		private readonly IUrunService UrunService;
		private readonly IKategoriService KategoriService;
		private readonly IMarkaService MarkaService;
		private readonly IHakkimizdaService HakkimizdaService;
		private readonly ISiparisService SiparisService;
		private readonly IMesajService MesajService;
        private UrunValidator UrunValidator;
        private KategoriValidator KategoriValidator;
        private MarkaValidator MarkaValidator;

        public AdminController(IAdminService adminService, IUrunService urunService, IKategoriService kategoriService, IMarkaService markaService, IHakkimizdaService hakkimizdaService, ISiparisService siparisService, IMesajService mesajService)
        {
            AdminService = adminService;
			UrunService = urunService;
            KategoriService = kategoriService;
            MarkaService = markaService;
            HakkimizdaService = hakkimizdaService;
            SiparisService = siparisService;
            MesajService = mesajService;
            UrunValidator = new UrunValidator();
            KategoriValidator = new KategoriValidator();
            MarkaValidator = new MarkaValidator();
        }

		[HttpGet("admin/{sayfa}")]
        public IActionResult Anasayfa(string sayfa)
		{
            if (TempData["urunekle"]!=null)
            {
                ViewBag.urunekle = TempData["urunekle"];
            }
            if (TempData["error"]!=null)
            {
                ViewBag.error = TempData["error"];
            }
            if (sayfa == "hakkimizda")
            {
                ViewBag.hakkimizdatable = HakkimizdaService.TListeGetir();
            }
            if (sayfa == "siparisler")
            {
                ViewBag.siparisleratable = SiparisService.TListeGetir();
            }
            if (sayfa == "mesajlar")
            {
                ViewBag.mesajlaratable = MesajService.TListeGetir();
            }
            if (sayfa == "adminler")
            {
                ViewBag.adminleratable = AdminService.TListeGetir();
            }
            if (sayfa == "siparisler")
            {
                ViewBag.siparisleratable = SiparisService.TListeGetir();
            }
            ViewBag.title=sayfa;
            return View(sayfa);
		}

		[HttpGet]
		public IActionResult LogIn()
		{
			ViewBag.title = "Admin giriş sayfası";
			return View();
		}

		[HttpPost]
		public IActionResult LogIn(Admin admin)
		{
			try
			{
				if (AdminService.AdminGirisKontrol(admin))
				{
					TempData["izin"] = true;
					return RedirectToAction("Anasayfa");
				}
				else
				{
					return View();
				}

            }
			catch (Error err)
			{
				ViewBag.error = err.Message;
                return View();
            }
			
		}
        [HttpPost]
        public IActionResult UrunEkle(Urun urun, IFormFile file)
        {
            ViewBag.title = "Ürün ekle";
            var urunvalidation=UrunValidator.Validate(urun);
            if (urunvalidation.IsValid)
            {
                if (file != null)
                {
                    GorselOlustur(urun, file);
                }
                UrunService.TEkle(urun);
                TempData["error"] = true;
                TempData["urunekle"] = true;
            }
            else
            {
                TempData["error"] = false;
            }
            return RedirectToAction("anasayfa", new { sayfa = "urunler" });
        }

        
        public IActionResult UrunDuzenle(int id)
		{
			ViewBag.title = "Ürün düzenle";
            var urun=UrunService.TItemGetir(id);
			return View(urun);
		}

        [HttpPost]
        public IActionResult UrunDuzenle(Urun urun, IFormFile file)
        {
            var urunvalidation = UrunValidator.Validate(urun);
            if (urunvalidation.IsValid)
            {
                if (file != null)
                {
                    GorselOlustur(urun, file);
                }
                UrunService.TGunceller(urun);
                TempData["error"] = true;
                return RedirectToAction("anasayfa", new { sayfa = "urunler" });
            }
            else
            {
                ViewBag.error = false;
                return View(urun);
            }
            
        }

        public IActionResult UrunSil(int id)
        {
            UrunService.TSil(UrunService.TItemGetir(id));
            return RedirectToAction("anasayfa", new { sayfa = "urunler" });
        }

        public async void GorselOlustur(Urun urun, IFormFile file)
		{
            var extension = Path.GetExtension(file.FileName);
            var randomName = String.Format($"{Guid.NewGuid()}{extension}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", randomName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            urun.GorselUrl = "images/"+randomName;
        }

        [HttpPost]
        public IActionResult KategoriEkle(Kategori kategori)
        {
            var kategoriValidator=KategoriValidator.Validate(kategori);

            if (kategoriValidator.IsValid)
            {
                KategoriService.TEkle(kategori);
            }
            else
            {
                TempData["error"] = true;
            }
            
            return RedirectToAction("anasayfa", new { sayfa = "kategoriler" });
        }

        public IActionResult KategoriSil(int id)
        {
            var kategori=KategoriService.TItemGetir(id);
            KategoriService.TSil(kategori);
            return RedirectToAction("anasayfa", new { sayfa = "kategoriler" });
        }

        [HttpPost]
        public IActionResult MarkaEkle(Marka marka)
        {
            var markaValidator = MarkaValidator.Validate(marka);

            if (markaValidator.IsValid)
            {
                MarkaService.TEkle(marka);
            }
            else
            {
                TempData["error"] = true;
            }
            return RedirectToAction("anasayfa", new { sayfa = "markalar" });
        }

        public IActionResult MarkaSil(int id)
        {
            var marka = MarkaService.TItemGetir(id);
            MarkaService.TSil(marka);
            return RedirectToAction("anasayfa", new { sayfa = "markalar" });
        }

        [HttpPost]
        public async Task<IActionResult> HakkimizdaEkle(Hakkimizda hakkimizda, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var randomName = String.Format($"{Guid.NewGuid()}{extension}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", randomName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            hakkimizda.GorselUrl= "images/" + randomName;
            hakkimizda.Aktiflik = false;

            HakkimizdaService.TEkle(hakkimizda);
            
            return RedirectToAction("anasayfa", new { sayfa = "hakkimizda" });
        }

        public IActionResult HakkimizdaSil(int id)
        {
            var hakkimizda = HakkimizdaService.TItemGetir(id);
            HakkimizdaService.TSil(hakkimizda);
            return RedirectToAction("anasayfa", new { sayfa = "hakkimizda" });
        }

        public IActionResult HakkimizdaAktifEt(int id)
        {
            var hakkimizdasablonlar = HakkimizdaService.TListeGetir();
            foreach (var sablon in hakkimizdasablonlar)
            {
                sablon.Aktiflik = false;
                HakkimizdaService.TGunceller(sablon);
            }
            var aktifsablon=HakkimizdaService.TItemGetir(id);
            aktifsablon.Aktiflik = true;
            HakkimizdaService.TGunceller(aktifsablon);
            return RedirectToAction("anasayfa", new { sayfa = "hakkimizda" });

        }
        public IActionResult MesajSil(int id)
        {
            var mesaj=MesajService.TItemGetir(id);
            MesajService.TSil(mesaj);
            return RedirectToAction("anasayfa", new { sayfa = "mesajlar" });
        }

        [HttpPost]
        public IActionResult AdminEkle(Admin admin)
        {
            AdminService.TEkle(admin);
            return RedirectToAction("anasayfa", new { sayfa = "adminler" });
        }

        public IActionResult SifreDegistir(string id)
        {
            ViewBag.AdminId = id;
            return View();
        }

        [HttpPost]
        public IActionResult SifreDegistir(SifreDTO sifreDTO)
        {
            
            if (ModelState.IsValid)
            {
                var admin = AdminService.TItemGetir(int.Parse(sifreDTO.AdminId));
                if(admin.Sifre == sifreDTO.oldpassword)
                {
                    admin.Sifre = sifreDTO.newpassword;
                    AdminService.TGunceller(admin);
                    TempData["error"] = true;
                }
                else
                {
                    TempData["error"] = false;
                }
            }
            else
            {
                TempData["error"] = false;
            }
            return RedirectToAction("anasayfa", new { sayfa = "adminler" });
        }

        public IActionResult AdminSil(string id, string sifre)
        {
            var admin=AdminService.TItemGetir(int.Parse(id));
            if (admin.Sifre == sifre)
            {
                AdminService.TSil(admin);
                TempData["error"] = true;
            }
            else
            {
                TempData["error"] = false;
            }
            return RedirectToAction("anasayfa", new { sayfa = "adminler" });
        }
        public IActionResult StatusUpdate(int id)
        {
            var siparis=SiparisService.TItemGetir(id);
            siparis.StatusId++;
            SiparisService.TGunceller(siparis);
            return RedirectToAction("anasayfa", new { sayfa = "siparisler" });
        }
        public IActionResult SiparisSil(int id)
        {
            var siparis=SiparisService.TItemGetir(id);
            SiparisService.TSil(siparis);
            return RedirectToAction("anasayfa", new { sayfa = "siparisler" });
        }
        
    }
}