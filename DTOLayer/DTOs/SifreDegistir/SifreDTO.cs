using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.SifreDegistir
{
    public class SifreDTO
    {
        public string AdminId { get; set; }
        [Required(ErrorMessage ="Admin şifresini giriniz.")]
        public string oldpassword { get; set; }
        [Required(ErrorMessage = "Yeni şifreyi giriniz.")]
        public string newpassword { get; set; }
        [Compare("newpassword", ErrorMessage = "şifreler uyumlu değil")]
        public string confirmpassword { get; set; }
    }
}
