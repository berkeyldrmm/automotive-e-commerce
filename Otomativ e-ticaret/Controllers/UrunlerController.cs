using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Otomativ_e_ticaret.Models;
using System.Xml.Linq;

namespace Otomativ_e_ticaret.Controllers
{
    public class UrunlerController : Controller
    {
        [HttpGet("urunler/{UrunCesidi}/{KategoriAdi?}")]
        public IActionResult Urunler(string UrunCesidi, string? KategoriAdi, [FromQuery] string marka, double enaz, double enfazla, string sira)
        {
            ViewBag.enaz = enaz;
            ViewBag.enfazla = enfazla;
            ViewBag.sira = sira;
            if (marka != null)
            {
                ViewBag.marka = marka;
            }
            ViewBag.UrunCesidi = UrunCesidi;
            ViewBag.KategoriAdi = KategoriAdi;
            if (UrunCesidi == "parca")
            {
                ViewBag.title = "Parçalar";
            }
            else if(marka!= null)
            {
                ViewBag.title = KategoriAdi;
            }
            else
            {
                ViewBag.title=KategoriAdi + " - " + marka;
            }
            return View(UrunCesidi);
        }
    }
}
