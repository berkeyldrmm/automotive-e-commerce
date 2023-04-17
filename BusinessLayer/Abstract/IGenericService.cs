using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TEkle(T entity);
        void TSil(T entity);
        void TGunceller(T entity);
        List<T> TListeGetir();
        T TItemGetir(int id);
    }
}
