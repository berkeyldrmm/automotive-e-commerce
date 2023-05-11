using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.ViewComponents
{
    public class BaslikOlusturComponent : ViewComponent
    {
        public IKategoriService KategoriService { get; set; }

        public BaslikOlusturComponent(IKategoriService kategoriService)
        {
            KategoriService = kategoriService;
        }

        public IViewComponentResult Invoke(string kategoriAdi, string marka)
        {
            ViewBag.marka = marka;
            var kategori=KategoriService.GetKategoriByKod(kategoriAdi);
            return View(kategori);
        }
    }
}
