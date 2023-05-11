using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class MesajValidator : AbstractValidator<Mesaj>
	{
		public MesajValidator() { 
			RuleFor(m=>m.MesajSahibiIsimSoyisim).NotEmpty().WithMessage("Lütfen bu alanı doldurunuz.");
			RuleFor(m=>m.MesajSahibiMail).NotEmpty().WithMessage("Lütfen bu alanı doldurunuz.");
			RuleFor(m=>m.MesajSahibiMail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
			RuleFor(m=>m.MesajSahibiTelefon).Length(10).WithMessage("Lütfen geçerli bir telefon numarası giriniz.");
			RuleFor(m=>m.TextMesaj).NotEmpty().WithMessage("Lütfen bu alanı doldurunuz.");
			RuleFor(m=>m.TextMesaj).MaximumLength(1000).WithMessage("Lütfen 1000 karakteri geçmeyiniz.");
		}
	}
}
