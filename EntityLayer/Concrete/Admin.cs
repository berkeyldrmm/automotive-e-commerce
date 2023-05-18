using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        public int AdminId { get; set; }
        [Required(ErrorMessage ="Lütfen bu alanı doldurunuz.")]
        public string KullaniciAdi { get; set; }
		[Required(ErrorMessage = "Lütfen bu alanı doldurunuz.")]
		public string Sifre { get; set; }

    }
}
