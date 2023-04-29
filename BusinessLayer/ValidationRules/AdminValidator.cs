using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(a => a.KullaniciAdi).NotNull().NotEmpty().WithMessage("Lütfen kullanıcı adını giriniz.");
            RuleFor(a => a.Sifre).NotNull().NotEmpty().WithMessage("Lütfen şifrenizi giriniz.");
            RuleFor(a => a.Sifre).MinimumLength(8).MaximumLength(16).WithMessage("Şifre en az 8 en fazla 16 karakterden oluşmalıdır.");
            RuleFor(a => a.Sifre).Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).+$").WithMessage("Şifre en az bir büyük harf bir küçük harf ve bir sayısal değer içermelidir.");
        }
    }
}
