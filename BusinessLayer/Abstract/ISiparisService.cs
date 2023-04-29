using BusinessLayer.Concrete;
using DTOLayer.DTOs.Siparis;
using EntityLayer.Concrete;
using Otomativ_e_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISiparisService : IGenericService<Siparis>
	{
		public Siparis SiparisOlustur(SepetDTO sepet, SiparisDTO siparisDTO, Urun GuncelUrun, HashSet<SiparisDetay> siparisDetay);
	}
}
