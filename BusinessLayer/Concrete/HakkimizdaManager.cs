using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.Siparis;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HakkimizdaManager : IHakkimizdaService
    {
        private readonly IHakkimizdaDal HakkimizdaDal;

        public HakkimizdaManager(IHakkimizdaDal hakkimizdaservice)
        {
            HakkimizdaDal = hakkimizdaservice;
        }

        public void TEkle(Hakkimizda entity)
        {
            HakkimizdaDal.Ekle(entity);
        }

        public void TGunceller(Hakkimizda entity)
        {
            HakkimizdaDal.Guncelle(entity);
        }

        public Hakkimizda TItemGetir(int id)
        {
            return HakkimizdaDal.ItemGetir(id);
        }

        public List<Hakkimizda> TListeGetir()
        {
            return HakkimizdaDal.ListeGetir();
        }

        public void TSil(Hakkimizda entity)
        {
            HakkimizdaDal.Sil(entity);
        }
    }
}
