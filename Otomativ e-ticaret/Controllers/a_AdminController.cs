using BusinessLayer.Abstract;
using DTOLayer.DTOs.SifreDegistir;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.Controllers
{
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
            ViewBag.Adminler = AdminService.TListeGetir();
            return View();
        }

        [HttpPost]
        public IActionResult AdminEkle(Admin admin)
        {
            AdminService.TEkle(admin);
            return RedirectToAction("index");
        }

        public IActionResult SifreDegistir(string id)
        {
            ViewBag.AdminId = id;
            return View();
        }

        [HttpPost]
        public IActionResult SifreDegistir(SifreDTO sifreDTO)
        {

            if (ModelState.IsValid)
            {
                var admin = AdminService.TItemGetir(int.Parse(sifreDTO.AdminId));
                if (admin.Sifre == sifreDTO.oldpassword)
                {
                    admin.Sifre = sifreDTO.newpassword;
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
