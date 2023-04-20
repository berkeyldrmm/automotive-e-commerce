using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.Sepet;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class UrunDTOValidator : AbstractValidator<UrunDTO>
	{
		//public UrunManager UrunManager {
		//	get {
		//		return new UrunManager(new EfUrun());
		//	}
		//	set { }
		//}
		public UrunDTOValidator() {
			RuleFor(u => int.Parse(u.miktar)).LessThanOrEqualTo(10).WithMessage("Bir ürün için 10 adetten daha fazla sipariş veremezsiniz.");
			//RuleFor(u => Convert.ToInt32(u.miktar)).LessThanOrEqualTo(UrunGetir(u))
		}
		//public Urun UrunGetir(UrunDTO urunDTO) => UrunManager.TItemGetir(urunDTO.UrunId);
	}
}
