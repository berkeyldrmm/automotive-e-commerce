using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.Controllers
{
    public class a_UrunlerController : Controller
    {
        public IUrunService UrunService { get; set; }
        public UrunValidator UrunValidator { get; set; }

        public a_UrunlerController(IUrunService urunService)
        {
            UrunService = urunService;
            UrunValidator = new UrunValidator();
        }

        public IActionResult Index()
        {
            if (TempData["urunekle"] != null)
            {
                ViewBag.urunekle = TempData["urunekle"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.error = TempData["error"];
            }
            var urunler = UrunService.TListeGetir();
            ViewBag.Urunler = urunler;
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(Urun urun, IFormFile file)
        {
            ViewBag.title = "Ürün ekle";
            var urunvalidation = UrunValidator.Validate(urun);
            if (urunvalidation.IsValid)
            {
                if (file != null)
                {
                    GorselOlustur.gorselOlustur(urun, file);
                }
                UrunService.TEkle(urun);
                TempData["error"] = true;
                TempData["urunekle"] = true;
            }
            else
            {
                TempData["error"] = false;
            }
            return RedirectToAction("index");
        }


        public IActionResult UrunDuzenle(int id)
        {
            ViewBag.title = "Ürün düzenle";
            var urun = UrunService.TItemGetir(id);
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
                    GorselOlustur.gorselOlustur(urun, file);
                }
                UrunService.TGunceller(urun);
                TempData["error"] = true;
                return RedirectToAction("index");
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
            return RedirectToAction("index");
        }
    }
}
