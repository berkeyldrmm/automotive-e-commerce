using DataAccessLayer.Abstraact;
using DTOLayer.DTOs.SiparisDetay;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISiparisDetayDal : IGenericDal<SiparisDetay>
    {
        public List<SiparisDetayDTO> SiparisDetayOlustur(int id);
    }
}
