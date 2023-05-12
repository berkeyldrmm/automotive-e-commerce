using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.Controllers
{
    public class a_MesajController : Controller
    {
        public IMesajService MesajService { get; set; }

        public a_MesajController(IMesajService mesajService)
        {
            MesajService = mesajService;
        }

        public IActionResult Index()
        {
            ViewBag.Mesajlar = MesajService.TListeGetir();
            return View();
        }

        public IActionResult MesajSil(int id)
        {
            var mesaj = MesajService.TItemGetir(id);
            MesajService.TSil(mesaj);
            return RedirectToAction("index");
        }
    }
}
