using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;
//using Otomativ_e_ticaret.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Otomativ_e_ticaret.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}