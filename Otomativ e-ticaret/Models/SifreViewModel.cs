using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.SifreDegistir
{
    public class SifreViewModel
    {
        public string AdminId { get; set; }
        [Required(ErrorMessage ="Admin şifresini giriniz.")]
        public string oldpassword { get; set; }
        [Required(ErrorMessage = "Yeni şifreyi giriniz."), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Şifre en az 1 büyük harf, 1 küçük harf ve 1 sayı içermelidir.")]
        public string newpassword { get; set; }
		[Required(ErrorMessage = "Yeni şifreyi giriniz."), Compare("newpassword", ErrorMessage = "şifreler uyumlu değil")]
        public string confirmpassword { get; set; }
    }
}
