using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Otomativ_e_ticaret.ViewComponents
{
    public class KategoriGetirComponent : ViewComponent
    {
        public IKategoriService KategoriService { get; set; }

        public KategoriGetirComponent(IKategoriService kategoriService)
        {
            KategoriService = kategoriService;
        }

        public IViewComponentResult Invoke(int id, bool requestforone, bool requestfromkategorilerpage)
        {
            if (requestforone)
            {
                var kategoriName = KategoriService.TItemGetir(id).KategoriAdi;
                return Content(kategoriName);
            }
            else
            {
                List<Kategori> kategoriler = KategoriService.TListeGetir();
                if (requestfromkategorilerpage)
                {
                    return View("KategoriListesi", kategoriler);
                }
                else
                {
                    return View(kategoriler);
                }

            }
        }
    }
}
