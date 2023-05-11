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
            RuleFor(u=>u.UrunAdi).NotEmpty().WithMessage("Ürün kısmını boş bırakmayınız.");
            RuleFor(u => u.Fiyat).NotEmpty().WithMessage("Lütfen bir fiyat bilgisi giriniz.");
            RuleFor(u => u.Fiyat).GreaterThanOrEqualTo(0).WithMessage("Fiyat bilgisi 0'ın altında olamaz.");
            RuleFor(u => u.Stok).GreaterThanOrEqualTo(0).WithMessage("Stok bilgisi 0'ın altında olamaz.");

        }
    }
}
