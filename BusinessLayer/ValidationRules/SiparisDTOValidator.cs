using DTOLayer.DTOs.Siparis;
using FluentValidation;
using Otomativ_e_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class SiparisDTOValidator : AbstractValidator<SiparisDTO>
	{
		public SiparisDTOValidator()
		{
			RuleFor(x => x.ad).NotNull().NotEmpty().WithMessage("Bu kısım boş geçilemez.");
			RuleFor(x => x.soyad).NotNull().NotEmpty().WithMessage("Bu kısım boş geçilemez.");
			RuleFor(x => x.adres).NotNull().NotEmpty().WithMessage("Bu kısım boş geçilemez.");
			RuleFor(x => x.email).NotNull().NotEmpty().WithMessage("Bu kısım boş geçilemez.");
			RuleFor(x => x.telefon).NotNull().NotEmpty().WithMessage("Bu kısım boş geçilemez.");
			RuleFor(x => x.telefon).Length(10).WithMessage("Lütfen geçerli bir telefon numarası giriniz.");
			RuleFor(x => x.email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
		}
	}
}
