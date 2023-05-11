using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.ViewComponents
{
    public class NavbarComponent: ViewComponent
    {
        private readonly IMarkaService MarkaService;
        private readonly IKategoriService KategoriService;
        public NavbarComponent(IMarkaService markaService, IKategoriService kategoriService)
        {
            MarkaService = markaService;
            KategoriService = kategoriService;
        }

        public IViewComponentResult Invoke(bool foryaglar)
        {
            if(foryaglar)
            {
                var markalar = MarkaService.TListeGetir().FindAll(m => m.UrunCesitId == 1);
                ViewBag.kategoriler = KategoriService.TListeGetir();
                return View(markalar);
            }
            else
            {
                var kategoriler = KategoriService.TListeGetir().FindAll(k => k.UrunCesitId == 2);
                return View("Parcalar", kategoriler); 
            }
            
        }
    }
}
