using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.Sepet;
using Microsoft.AspNetCore.Mvc;
using Otomativ_e_ticaret.Models;
using System.Text.Json;

namespace Otomativ_e_ticaret.Controllers
{
    public class SepetController : Controller
    {
        public SepetDTO sepet { get; set; }
        public SepetManager sepetManager { get; set; }
        public UrunManager urunManager = new UrunManager(new EfUrun());

        public SepetController(SepetDTO sepet)
        {
            this.sepet = sepet;
            this.sepetManager = new SepetManager(sepet);
        }

        public IActionResult Index()
        {
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
                ValidateMiktar.MiktarValidator(sepetitem, new UrunManager(new EfUrun()));
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
            sepetManager.SepetUrunMiktarArttir(id);
            return RedirectToAction("Index");
        }
        public IActionResult SepetUrunMiktarAzalt(int id)
        {
            sepetManager.SepetUrunMiktarAzalt(id);
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
    }
}
