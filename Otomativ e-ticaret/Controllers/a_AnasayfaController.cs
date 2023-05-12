using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Otomativ_e_ticaret.Models;

namespace Otomativ_e_ticaret.Controllers
{
    public class a_AnasayfaController : Controller
    {
        public IAdminService AdminService { get; set; }

        public a_AnasayfaController(IAdminService adminService)
        {
            AdminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            ViewBag.title = "Admin giriş sayfası";
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(Admin admin)
        {
            try
            {
                if (AdminService.AdminGirisKontrol(admin))
                {
                    TempData["izin"] = true;
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch (Error err)
            {
                ViewBag.error = err.Message;
                return View();
            }

        }
    }
}
