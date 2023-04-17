using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Otomativ_e_ticaret.Models;

namespace Otomativ_e_ticaret.Controllers
{
    public class SepetController : Controller
    {
        public SepetDTO sepet { get; set; }
        public SepetManager sepetManager { get; set; }

        public SepetController(SepetDTO sepet)
        {
            this.sepet = sepet;
            this.sepetManager = new SepetManager(sepet);
        }

        public IActionResult Index()
        {
            var sepeturunler = sepet.sepetUrunler;
            return View(sepeturunler);
		}

        [HttpPost]
        public IActionResult SepeteEkle(int UrunId,string miktar)
        {
            sepetManager.SepeteEkle(UrunId, miktar);
            
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
