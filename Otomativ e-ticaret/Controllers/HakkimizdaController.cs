using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.Controllers
{
    public class HakkimizdaController : Controller
    {
		public IActionResult Index()
        {
            var hakkimizdaManager = new HakkimizdaManager(new EfHakkimizda());
            var hakkimizdaitem=hakkimizdaManager.TListeGetir().FirstOrDefault(hi=>hi.Aktiflik==true);

			return View(hakkimizdaitem);
        }
    }
}
