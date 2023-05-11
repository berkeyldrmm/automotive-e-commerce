using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DTOLayer.DTOs.Sepet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.ViewComponents
{
    public class UrunGosterComponent : ViewComponent
    {
        private readonly IUrunService UrunManager;

        public UrunGosterComponent(IUrunService urunManager)
        {
            this.UrunManager = urunManager;
        }
        public IViewComponentResult Invoke(int id)
        {
            var urun = UrunManager.TItemGetir(id);
            ViewBag.urun = urun;
            ViewBag.title = urun.UrunAdi;
			return View();
        }
    }
}
