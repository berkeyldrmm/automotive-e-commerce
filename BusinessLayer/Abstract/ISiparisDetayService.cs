using DTOLayer.DTOs.SiparisDetay;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISiparisDetayService : IGenericService<SiparisDetay>
    {
        public List<SiparisDetayDTO> SiparisDetayOlustur(int id);
    }
}
