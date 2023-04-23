using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public ICollection<Siparis> Siparisler { get; set; }
    }
}
