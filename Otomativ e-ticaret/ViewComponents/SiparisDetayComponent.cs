using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.ViewComponents
{
    public class SiparisDetayComponent : ViewComponent
    {
        public ISiparisDetayService SiparisDetayService { get; set; }

        public SiparisDetayComponent(ISiparisDetayService siparisDetayService)
        {
            SiparisDetayService = siparisDetayService;
        }

        public IViewComponentResult Invoke(int siparisid)
        {
            var urunler= SiparisDetayService.SiparisDetayOlustur(siparisid);
            return View(urunler);
        }
    }
}
