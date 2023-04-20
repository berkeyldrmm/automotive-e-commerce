using BusinessLayer.Concrete;
using DTOLayer.DTOs.Sepet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.ViewComponents
{
    public class UrunGosterComponent : ViewComponent
    {
        private UrunManager urunManager;

        public UrunGosterComponent(UrunManager urunManager)
        {
            this.urunManager = urunManager;
        }
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.urun = urunManager.TItemGetir(id);
			return View();
        }
    }
}
