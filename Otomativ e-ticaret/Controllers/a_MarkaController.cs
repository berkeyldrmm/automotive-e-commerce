using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.Controllers
{
    [Authorize]
    public class a_MarkaController : Controller
    {
        public IMarkaService MarkaService { get; set; }
        public MarkaValidator MarkaValidator { get; set; }

        public a_MarkaController(IMarkaService markaService)
        {
            MarkaService = markaService;
            MarkaValidator = new MarkaValidator();
        }

        public IActionResult Index()
        {
            if (TempData["error"] != null)
            {
                ViewBag.error = TempData["error"];
            }
            var markalar = MarkaService.TListeGetir();
            ViewBag.Markalar = markalar;
            return View();
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
				foreach (var error in markaValidator.Errors)
				{
					ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
				}
				TempData["error"] = true;
            }
            return RedirectToAction("index");
        }

        public IActionResult MarkaSil(int id)
        {
            var marka = MarkaService.TItemGetir(id);
            MarkaService.TSil(marka);
            return RedirectToAction("index");
        }
    }
}
