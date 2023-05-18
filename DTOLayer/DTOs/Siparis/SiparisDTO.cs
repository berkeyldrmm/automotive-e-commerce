using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Siparis
{
    public class SiparisDTO
    {
        [Required(ErrorMessage ="Bu kısım boş geçilemez.")]
        public string ad { get; set; }
        [Required(ErrorMessage = "Bu kısım boş geçilemez.")]
        public string soyad { get; set; }
        [Required(ErrorMessage = "Bu kısım boş geçilemez.")]
        public string email { get; set; }
		[Required(ErrorMessage = "Bu kısım boş geçilemez.")]
		[StringLength(10, MinimumLength =10, ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz.")]
		public string telefon { get; set; }
        [Required(ErrorMessage = "Bu kısım boş geçilemez.")]
        public string adres { get; set; }
    }
}
