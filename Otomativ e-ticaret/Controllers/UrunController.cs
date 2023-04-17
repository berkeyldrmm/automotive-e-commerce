using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index(int id)
        {
            return View(id);
        }
    }
}
