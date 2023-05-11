using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class KategoriManager : IKategoriService
    {
        public IKategoriDal KategoriDal { get; set; }

        public KategoriManager(IKategoriDal kategoriDal)
        {
            KategoriDal = kategoriDal;
        }

        public void TEkle(Kategori entity)
        {
            KategoriDal.Ekle(entity);
        }

        public void TGunceller(Kategori entity)
        {
            KategoriDal.Guncelle(entity);
        }

        public Kategori TItemGetir(int id)
        {
            return KategoriDal.ItemGetir(id);
        }

        public List<Kategori> TListeGetir()
        {
            return KategoriDal.ListeGetir();
        }

        public void TSil(Kategori entity)
        {
            KategoriDal.Sil(entity);
        }

        public Kategori GetKategoriByKod(string KategoriKod)
        {
            return KategoriDal.GetKategoriByKod(KategoriKod);
        }

    }
}
