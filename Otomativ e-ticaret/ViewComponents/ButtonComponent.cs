using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.ViewComponents
{
    public class ButtonComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string category)
        {
            var cat = category.Replace(" ", "")
                .Replace("ğ", "g")
                .Replace("ç", "c")
                .Replace("ı","i")
                .Replace("ö","o")
                .ToLower();
            ViewBag.Category = cat;
            return View();
        }
    }
}
