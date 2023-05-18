using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.Controllers
{
    [Authorize]
    public class a_KategoriController : Controller
    {
        public IKategoriService KategoriService { get; set; }
        public KategoriValidator KategoriValidator { get; set; }

        public a_KategoriController(IKategoriService kategoriService)
        {
            KategoriService = kategoriService;
            KategoriValidator=new KategoriValidator();
        }

        public IActionResult Index()
        {
            if (TempData["error"] != null)
            {
                ViewBag.error = TempData["error"];
            }
            List<Kategori> kategoriler = KategoriService.TListeGetir();
            ViewBag.Kategori = kategoriler;
            return View();
        }

        [HttpPost]
        public IActionResult KategoriEkle(Kategori kategori)
        {
            var kategoriValidator = KategoriValidator.Validate(kategori);

            if (kategoriValidator.IsValid)
            {
                KategoriService.TEkle(kategori);
            }
            else
            {
				foreach (var error in kategoriValidator.Errors)
				{
					ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
				}
				TempData["error"] = true;
            }

            return RedirectToAction("index");
        }

        public IActionResult KategoriSil(int id)
        {
            var kategori = KategoriService.TItemGetir(id);
            KategoriService.TSil(kategori);
            return RedirectToAction("index");
        }
    }
}
