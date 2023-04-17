using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UrunValidator : AbstractValidator<Urun>
    {
        public UrunValidator() {
            RuleFor(u=>u.UrunAdi).NotEmpty().WithMessage("Urun kısmını boş bırakmayınız.");
            RuleFor(u => u.Stok).GreaterThanOrEqualTo(0).WithMessage("Stok bilgisini 0'ın altında olamaz.");

        }
    }
}
