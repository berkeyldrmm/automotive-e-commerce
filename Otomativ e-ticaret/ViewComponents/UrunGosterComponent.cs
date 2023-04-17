using BusinessLayer.Concrete;
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
            var urun = urunManager.TItemGetir(id);
            return View(urun);
        }
    }
}
