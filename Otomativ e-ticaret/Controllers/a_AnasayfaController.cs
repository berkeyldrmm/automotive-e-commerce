using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otomativ_e_ticaret.Models;
using System.Security.Claims;

namespace Otomativ_e_ticaret.Controllers
{
    public class a_AnasayfaController : Controller
    {
        public IAdminService AdminService { get; set; }
        public a_AnasayfaController(IAdminService adminService)
        {
            AdminService = adminService;
        }
        [Authorize]
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
        public async Task<IActionResult> LogIn(Admin admin)
        {
            try
            {
                if (AdminService.AdminGirisKontrol(admin))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,admin.KullaniciAdi)
                    };
                    var adminidentity=new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal= new ClaimsPrincipal(adminidentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index","a_Anasayfa");
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
