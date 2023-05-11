using BusinessLayer.Abstract;
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
        private readonly IUrunService urunManager;

        public UrunComponent(IUrunService urunManager)
        {
            this.urunManager = urunManager;
        }

        public IViewComponentResult Invoke(string uruncesidi, string category, bool forIndex, string marka, double enaz, double enfazla, string sira)
        {
            List<Urun> urunler;
            if (uruncesidi == "parca")
            {
                if (category != null)
                {
                    urunler = urunManager.KategoriUrun(category);
                }
                else
                {
                    urunler = urunManager.ParcalariGetir();
                    if (forIndex)
                    {
                        if(urunler.Count > 4)
                        {
                            urunler = urunler.GetRange(urunler.Count - 4, 4);
                        }
                        urunler.Reverse();
                    }
                }
            }
            else if (forIndex)
            {
                urunler = urunManager.KategoriUrun(category);

                if (urunler.Count > 4)
                {
                    urunler = urunler.GetRange(urunler.Count - 4, 4);
                }
                urunler.Reverse();
            }
            else if (marka == null)
            {
                urunler = urunManager.KategoriUrun(category);
            }
            else
            {
                urunler = urunManager.KategoriMarkaUrun(category, marka);
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
