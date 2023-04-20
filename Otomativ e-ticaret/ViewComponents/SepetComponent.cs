using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Otomativ_e_ticaret.Models;

namespace Otomativ_e_ticaret.ViewComponents
{
	public class SepetComponent : ViewComponent
	{
		public IViewComponentResult Invoke(List<SepetItemDTO> sepet)
		{
			//List<Tuple<Urun,int>> sepeturunler=new List<Tuple<Urun,int>>();
			//var urunManager = new UrunManager(new EfUrun());
			//foreach (var urun in sepet)
			//{
			//	Urun sepetitem= urunManager.TItemGetir(urun.UrunId);
			//	sepeturunler.Add(new Tuple<Urun, int>(sepetitem,Convert.ToInt32(urun.miktar)));
			//}
			return View(sepet);
		}
	}
}
