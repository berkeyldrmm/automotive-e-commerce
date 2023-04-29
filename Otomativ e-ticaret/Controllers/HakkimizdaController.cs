using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.Controllers
{
    public class HakkimizdaController : Controller
    {
        private readonly IHakkimizdaService HakkimizdaService;

		public HakkimizdaController(IHakkimizdaService hakkimizdaService)
		{
			HakkimizdaService = hakkimizdaService;
		}

		public IActionResult Index()
        {
            var hakkimizdaitem= HakkimizdaService.TListeGetir().FirstOrDefault(hi=>hi.Aktiflik==true);
            ViewBag.title = "Hakkimizda";

			return View(hakkimizdaitem);
        }
    }
}
