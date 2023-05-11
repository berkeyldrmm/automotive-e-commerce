using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Otomativ_e_ticaret.ViewComponents
{
    public class MarkaGetirComponent : ViewComponent
    {
        public IMarkaService MarkaService { get; set; }

        public MarkaGetirComponent(IMarkaService markaService)
        {
            MarkaService = markaService;
        }

        public IViewComponentResult Invoke(int id, bool requestforone, bool requestfrommarkalarpage)
        {
            if (requestforone)
            {
                var marka = MarkaService.TItemGetir(id).MarkaAdi;
                return Content(marka);
            }
            else
            {
                var markalar = MarkaService.TListeGetir();
                if (requestfrommarkalarpage)
                {
                    return View("MarkaListesi", markalar);
                }
                else
                {
                    return View(markalar);
                }
               
            }
        }
    }
}
