using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Otomativ_e_ticaret.ViewComponents
{
    public class UrunGetirComponent : ViewComponent
    {
        private readonly IUrunService urunService;

        public UrunGetirComponent(IUrunService _urunService)
        {
            urunService = _urunService;
        }

        public IViewComponentResult Invoke()
        {
            var urunler=urunService.TListeGetir();
            return View(urunler);
        }
    }
}
