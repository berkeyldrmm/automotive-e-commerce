using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity_Framework
{
    internal class EfSiparis : GenericRepository<Siparis>, ISiparisDal
    {
        public void Ekle(Siparis item)
        {
            throw new NotImplementedException();
        }

        public void Guncelle(Siparis item)
        {
            throw new NotImplementedException();
        }

        public Siparis ItemGetir(Siparis item)
        {
            throw new NotImplementedException();
        }

        public List<Siparis> ListeGetir()
        {
            throw new NotImplementedException();
        }

        public void Sil(Siparis item)
        {
            throw new NotImplementedException();
        }
    }
}
