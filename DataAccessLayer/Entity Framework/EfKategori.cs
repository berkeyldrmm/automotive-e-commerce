using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity_Framework
{
    public class EfKategori : GenericRepository<Kategori>, IKategoriDal
    {
        public Kategori GetKategoriByKod(string KategoriKod)
        {
            using var c = new Context();
            var kategori=c.Kategoriler.SingleOrDefault(k=>k.KategoriKod==KategoriKod);
            return kategori;
        }

    }
}
