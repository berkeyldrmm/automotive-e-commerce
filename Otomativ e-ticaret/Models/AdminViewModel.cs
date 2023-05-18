using System.ComponentModel.DataAnnotations;

namespace Otomativ_e_ticaret.Models
{
    public class AdminViewModel
    {
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz.")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz."), MinLength(8, ErrorMessage="Şifre en az 8 karakterden oluşmalıdır."), MaxLength(16, ErrorMessage = "Şifre en fazla 16 karakterden oluşmalıdır."), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Şifre en az 1 büyük harf, 1 küçük harf ve 1 sayı içermelidir.")]
        public string Sifre { get; set; }
    }
}
