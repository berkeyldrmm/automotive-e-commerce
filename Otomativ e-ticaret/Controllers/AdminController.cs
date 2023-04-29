using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Otomativ_e_ticaret.Models;
using System.Net;

namespace Otomativ_e_ticaret.Controllers
{
    public class AdminController : Controller
	{
		private readonly IAdminService AdminService;


        public AdminController(IAdminService adminService)
        {
            AdminService = adminService;
        }

		[HttpGet("admin/{sayfa}")]
        public IActionResult Anasayfa(string sayfa)
		{
			ViewBag.title=sayfa;
            return View(sayfa);
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
					return RedirectToAction("Anasayfa");
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
