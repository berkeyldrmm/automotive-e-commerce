using DataAccessLayer.Abstraact;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public async void Ekle(T item)
        {
            Context c = new Context();
            await c.AddAsync(item);
            await c.SaveChangesAsync();
        }

        public async void Guncelle(T item)
        {
            using var c = new Context();
            c.Update(item);
            await c.SaveChangesAsync();
        }

        public void Sil(T item)
        {
            using var c = new Context();
            c.Remove(item);
            c.SaveChangesAsync();
        }

        public List<T> ListeGetir()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public T ItemGetir(int id)
        {
            using var c = new Context();

            return c.Set<T>().Find(id);

        }
    }
}
