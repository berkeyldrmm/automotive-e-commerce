using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Otomativ_e_ticaret.Models;
using System.Xml.Linq;

namespace Otomativ_e_ticaret.Controllers
{
    public class UrunlerController : Controller
    {
        [HttpGet("urunler/{kategoriAdi}")]
        public IActionResult Urunler(string kategoriAdi,[FromQuery] string marka, double enaz, double enfazla, string sira, string altkategori)
        {
            ViewBag.enaz = enaz;
            ViewBag.enfazla = enfazla;
            ViewBag.sira = sira;
            if (marka != null)
            {
                ViewBag.marka = marka;
            }
            if (kategoriAdi == "parca")
            {
                ViewBag.altkategori = altkategori;
            }
            return View(kategoriAdi);
        }
    }
}
