using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.Sepet;
using EntityLayer.Concrete;
using Otomativ_e_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ValidateMiktar
    {
        public static void MiktarValidator(SepetItemDTO sepetitem)
        {
            //Urun urun = urunManager.TItemGetir(sepetitem.UrunId);
            if (sepetitem.miktar > 10)
            {
                throw new Error(string.Format("10 adetten daha fazla sipariş veremezsiniz."));
            }
            else if (sepetitem.miktar > sepetitem.Urun.Stok)
            {
                throw new Error(string.Format("Yeteri kadar stok yok."));
            }
            else if(sepetitem.miktar < 1)
            {
                throw new Error(string.Format("Bu üründen 1 tane var."));
            }
        }
    }
}
