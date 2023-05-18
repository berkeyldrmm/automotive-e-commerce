using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MarkaValidator : AbstractValidator<Marka>
    {
        public MarkaValidator()
        {
            //RuleFor(m => m.MarkaAdi).NotEmpty().WithMessage("Lütfen bir marka adı giriniz.");
            //RuleFor(m => m.MarkaKod).NotEmpty().WithMessage("Marka için lütfen bir kod girin.");
        }
    }
}
