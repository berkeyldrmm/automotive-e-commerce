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
    public class MesajManager : IMesajService
    {
        private readonly IMesajDal MesajDal;

        public MesajManager(IMesajDal mesajDal)
        {
            MesajDal = mesajDal;
        }

        public void TEkle(Mesaj entity)
        {
            MesajDal.Ekle(entity);
        }

        public void TGunceller(Mesaj entity)
        {
			MesajDal.Guncelle(entity);
		}

        public Mesaj TItemGetir(int id)
        {
			return MesajDal.ItemGetir(id);
		}

        public List<Mesaj> TListeGetir()
        {
			return MesajDal.ListeGetir();
		}

        public void TSil(Mesaj entity)
        {
            MesajDal.Sil(entity);
        }
    }
}
