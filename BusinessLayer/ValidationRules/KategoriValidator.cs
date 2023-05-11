using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class KategoriValidator : AbstractValidator<Kategori>
    {
        public KategoriValidator() { 
            RuleFor(k=>k.KategoriAdi).NotEmpty().WithMessage("Kategori adı boş geçilemez.");
            RuleFor(k=>k.KategoriKod).NotEmpty().WithMessage("Kategori için lütfen bir kod girin.");
        }

    }
}
