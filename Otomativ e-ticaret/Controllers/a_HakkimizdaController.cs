using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.Controllers
{
    public class a_HakkimizdaController : Controller
    {
        public IHakkimizdaService HakkimizdaService { get; set; }

        public a_HakkimizdaController(IHakkimizdaService hakkimizdaService)
        {
            HakkimizdaService = hakkimizdaService;
        }

        public IActionResult Index()
        {
            ViewBag.HakkimizdaSablonlar = HakkimizdaService.TListeGetir();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HakkimizdaEkle(Hakkimizda hakkimizda, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var randomName = String.Format($"{Guid.NewGuid()}{extension}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", randomName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            hakkimizda.GorselUrl = "images/" + randomName;
            hakkimizda.Aktiflik = false;

            HakkimizdaService.TEkle(hakkimizda);

            return RedirectToAction("index");
        }

        public IActionResult HakkimizdaSil(int id)
        {
            var hakkimizda = HakkimizdaService.TItemGetir(id);
            HakkimizdaService.TSil(hakkimizda);
            return RedirectToAction("index");
        }

        public IActionResult HakkimizdaAktifEt(int id)
        {
            var hakkimizdasablonlar = HakkimizdaService.TListeGetir();
            foreach (var sablon in hakkimizdasablonlar)
            {
                sablon.Aktiflik = false;
                HakkimizdaService.TGunceller(sablon);
            }
            var aktifsablon = HakkimizdaService.TItemGetir(id);
            aktifsablon.Aktiflik = true;
            HakkimizdaService.TGunceller(aktifsablon);
            return RedirectToAction("index");

        }
    }
}
