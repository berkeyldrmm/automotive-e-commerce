using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.ViewComponents
{
    public class ButtonComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string uruncesidi, string category)
        {
            if (uruncesidi != "parca")
            {
                ViewBag.KategoriAdi = category;
            }
            ViewBag.Cesit = uruncesidi;
            
            return View();
        }
    }
}
