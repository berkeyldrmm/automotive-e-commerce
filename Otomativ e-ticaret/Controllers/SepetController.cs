using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.Sepet;
using DTOLayer.DTOs.Siparis;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Otomativ_e_ticaret.Models;

namespace Otomativ_e_ticaret.Controllers
{
    public class SepetController : Controller
    {
        private readonly SepetDTO sepet;
        private readonly ISepetService sepetManager;
        private readonly IUrunService UrunManager;

        private readonly ISiparisService SiparisService;

        public SepetController(SepetDTO sepet, IUrunService urunManager, ISiparisService siparisService)
        {
            this.sepet = sepet;
            sepetManager = new SepetManager(sepet, new UrunManager(new EfUrun()));
            UrunManager = urunManager;
			SiparisService = siparisService;

		}

        public IActionResult Index()
        {
            ViewBag.title = "Sepet";
            if (TempData["sepeteeklendi"]!=null)
            {
                ViewBag.sepeteeklendi = TempData["sepeteeklendi"];
            }
            var sepeturunler = sepet.sepetUrunler;
            return View(sepeturunler);
        }

        [HttpPost]
        public IActionResult SepeteEkle(UrunDTO sepetitem)
        {
            try
            {
                foreach (var sepeturun in sepet.sepetUrunler)
                {
                    if (sepeturun.Urun.UrunId == sepetitem.UrunId)
                    {
                        return SepetUrunMiktarArttir(sepeturun.Urun.UrunId);
                    }
                }
                var sepetitemDto = new SepetItemDTO() { Urun = UrunManager.TItemGetir(sepetitem.UrunId), miktar = int.Parse(sepetitem.miktar) };
                sepetManager.SepeteEkle(sepetitem);
            }
            catch (Exception err)
            {
                TempData["sepeteeklendi"] = err.Message;
            }
            
            return RedirectToAction("Index");
        }
        public IActionResult SepetUrunMiktarArttir(int id)
        {
            try
            {
                var urun=sepetManager.SepetUrunGetir(id);
                sepetManager.SepetUrunMiktarArttir(id);
               
            }
            catch (Exception err)
            {
                sepetManager.SepetUrunMiktarAzalt(id);
                TempData["sepeteeklendi"] = err.Message;
            }

            return RedirectToAction("Index");
        }
        public IActionResult SepetUrunMiktarAzalt(int id)
        {
            try
            {
                var urun = sepetManager.SepetUrunGetir(id);
                sepetManager.SepetUrunMiktarAzalt(id);

            }
            catch (Exception err)
            {
                sepetManager.SepetUrunMiktarArttir(id);
                TempData["sepeteeklendi"] = err.Message;
            }

            return RedirectToAction("Index");

        }
        public IActionResult SepetUrunSil(int id)
        {
            sepetManager.SepettenCikar(id);
            return RedirectToAction("Index");
        }
        public IActionResult SepetBosalt()
        {
            sepetManager.SepetiBosalt();
            return RedirectToAction("Index");
        }
        public IActionResult SiparisVer()
        {
            ViewBag.title = "Sipariş";
            ViewBag.siparis = sepet.sepetUrunler;
            return View();
        }
        [HttpPost]
        public IActionResult SiparisVer(SiparisDTO siparisDTO)
        {
            SiparisDTOValidator siparisValidator = new SiparisDTOValidator();
            ValidationResult validationResult = siparisValidator.Validate(siparisDTO);

            if (validationResult.IsValid)
            {
                var yenisiparis = SiparisService.SiparisOlustur(sepet, siparisDTO, new Urun(), new HashSet<SiparisDetay>());
                SiparisService.TEkle(yenisiparis);

                sepet.sepetUrunler = new List<SepetItemDTO>();
                return View("SiparisTamamla");
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                ViewBag.siparis = sepet.sepetUrunler;
                ViewBag.siparishata = "Siparis Oluşturulmadı.";
                return View();
            }



        }
    }
}
