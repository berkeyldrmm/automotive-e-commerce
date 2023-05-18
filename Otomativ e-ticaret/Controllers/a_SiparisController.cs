using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.Controllers
{
    [Authorize]
    public class a_SiparisController : Controller
    {
        public ISiparisService SiparisService { get; set; }

        public a_SiparisController(ISiparisService siparisService)
        {
            SiparisService = siparisService;
        }

        public IActionResult Index()
        {
            ViewBag.Siparisler=SiparisService.TListeGetir();
            return View();
        }

        public IActionResult StatusUpdate(int id)
        {
            var siparis = SiparisService.TItemGetir(id);
            siparis.StatusId++;
            SiparisService.TGunceller(siparis);
            return RedirectToAction("index");
        }
        public IActionResult SiparisSil(int id)
        {
            var siparis = SiparisService.TItemGetir(id);
            SiparisService.TSil(siparis);
            return RedirectToAction("index");
        }
    }
}
