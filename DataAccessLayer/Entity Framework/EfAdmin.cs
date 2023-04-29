using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity_Framework
{
    public class EfAdmin : GenericRepository<Admin>, IAdminDal
    {
        public Admin KullaniciAdiylaGetir(string kullaniciadi)
        {
            using var c = new Context();
            var admin= (from a in c.Adminler
                        where a.KullaniciAdi == kullaniciadi
                        select a).SingleOrDefault();
            return admin;

        }
    }
}
