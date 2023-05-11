using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Otomativ_e_ticaret.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Otomativ_e_ticaret.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKategoriService KategoriService;

        public HomeController(ILogger<HomeController> logger, IKategoriService kategoriService)
        {
            _logger = logger;
            KategoriService = kategoriService;
        }

        public IActionResult Index()
        {
            var kategoriler = KategoriService.TListeGetir();
            ViewBag.title = "Oto Plus";
            return View(kategoriler);
        }
    }
}