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
        public UrunManager urunManager { get; set; }

        public SepetController(SepetDTO sepet)
        {
            this.sepet = sepet;
            sepetManager = new SepetManager(sepet);
            urunManager = new UrunManager(new EfUrun());
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
                foreach (var sepeturun in sepet.sepetUrunler)
                {
                    if (sepeturun.Urun.UrunId == sepetitem.UrunId)
                    {
                        return SepetUrunMiktarArttir(sepeturun.Urun.UrunId);
                    }
                }
                var sepetitemDto = new SepetItemDTO() { Urun = urunManager.TItemGetir(sepetitem.UrunId), miktar = int.Parse(sepetitem.miktar) };
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
    }
}
