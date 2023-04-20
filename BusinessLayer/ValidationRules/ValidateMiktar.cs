using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.Sepet;
using EntityLayer.Concrete;
using Otomativ_e_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ValidateMiktar
    {

        public static void MiktarValidator(UrunDTO sepetitem, UrunManager urunManager)
        {
            Urun urun = urunManager.TItemGetir(sepetitem.UrunId);
            if (int.Parse(sepetitem.miktar) > 10)
            {
                throw new Error(string.Format("10 adetten daha fazla sipariş veremezsiniz."));
            }
            else if (int.Parse(sepetitem.miktar) > urun.Stok)
            {
                throw new Error(string.Format("Yeteri kadar stok yok."));
            }
        }
    }
}
