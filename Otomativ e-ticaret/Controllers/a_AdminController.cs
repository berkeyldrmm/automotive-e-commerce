using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DTOLayer.DTOs.SifreDegistir;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otomativ_e_ticaret.Models;

namespace Otomativ_e_ticaret.Controllers
{
    [Authorize]
    public class a_AdminController : Controller
    {
        public IAdminService AdminService { get; set; }

        public a_AdminController(IAdminService adminService)
        {
            AdminService = adminService;
        }

        public IActionResult Index()
        {
            if (TempData["error"] != null)
            {
                ViewBag.error = TempData["error"];
            }
            if (TempData["fromadminekle"]!=null)
            {
                ViewBag.fromadminekle = TempData["fromadminekle"];
            }
            ViewBag.Adminler = AdminService.TListeGetir();
            return View();
        }

        [HttpPost]
        public IActionResult AdminEkle(AdminViewModel adminViewModel)
        {
            if (ModelState.IsValid)
            {
                var admin = new Admin()
                {
                    KullaniciAdi = adminViewModel.KullaniciAdi,
                    Sifre = adminViewModel.Sifre
                };
                AdminService.TEkle(admin);
            }
            else
            {
                TempData["fromadminekle"] = true;
            }
            
            return RedirectToAction("index");
        }

        public IActionResult SifreDegistir(string id)
        {
            ViewBag.AdminId = id;
            return View();
        }

        [HttpPost]
        public IActionResult SifreDegistir(SifreViewModel SifreViewModel)
        {

            if (ModelState.IsValid)
            {
                var admin = AdminService.TItemGetir(int.Parse(SifreViewModel.AdminId));
                if (admin.Sifre == SifreViewModel.oldpassword)
                {
                    admin.Sifre = SifreViewModel.newpassword;
                    AdminService.TGunceller(admin);
                    TempData["error"] = true;
                }
                else
                {
                    TempData["error"] = false;
                }
            }
            else
            {
                TempData["error"] = false;
            }
            return RedirectToAction("index");
        }

        public IActionResult AdminSil(string id, string sifre)
        {
            var admin = AdminService.TItemGetir(int.Parse(id));
            if (admin.Sifre == sifre)
            {
                AdminService.TSil(admin);
                TempData["error"] = true;
            }
            else
            {
                TempData["error"] = false;
            }
            return RedirectToAction("index");
        }
    }
}
