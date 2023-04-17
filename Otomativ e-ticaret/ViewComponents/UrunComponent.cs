using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Otomativ_e_ticaret.Models;
using System.Collections;
using System.Collections.Generic;

namespace Otomativ_e_ticaret.ViewComponents
{
    public class UrunComponent : ViewComponent
    {
        private UrunManager urunManager;

        public UrunComponent(UrunManager urunManager)
        {
            this.urunManager = urunManager;
        }

        public IViewComponentResult Invoke(string category, bool forIndex, string marka, double enaz, double enfazla, string sira, string altkategori)
        {
            List<Urun> urunler;
            if (category == "Parça")
            {
                if (altkategori != null)
                {
                    urunler = urunManager.KategoriUrun(altkategori);
                }
                else
                {
                    urunler = urunManager.ParcalariGetir();
                    if (forIndex)
                    {
                        urunler = urunler.GetRange(urunler.Count - 4, 4);
                        urunler.Reverse();
                    }
                }
            }
            else if (forIndex)
            {
                urunler = urunManager.KategoriUrun(category);
                
                urunler = urunler.GetRange(urunler.Count-4, 4);
                urunler.Reverse();
            }
            else if (marka == null)
            {
                urunler = urunManager.KategoriUrun(category);
            }
            else
            {
                var markasizurunler = urunManager.KategoriUrun(category);
                urunler = urunManager.KategoriMarkaUrun(markasizurunler, marka);
            }
            //Filreleme - siralama
            if (enfazla != 0)
            {
                urunler=urunManager.FiyatFiltrele(urunler, enaz, enfazla);
            }
            if (sira != null)
            {
                urunler = urunManager.Sirala(urunler, sira);
            }
            return View(urunler);
        }
    }
}
