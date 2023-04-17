using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstraact
{
    public interface IGenericDal<T>
    {
        void Ekle(T item);
        void Sil(T item);
        void Guncelle(T item);
        List<T> ListeGetir();
        T ItemGetir(int id);
    }
}
