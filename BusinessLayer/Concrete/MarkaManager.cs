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
    public class MarkaManager : IMarkaService
    {
        public IMarkaDal MarkaDal { get; set; }

        public MarkaManager(IMarkaDal markaDal)
        {
            MarkaDal = markaDal;
        }

        public void TEkle(Marka entity)
        {
            MarkaDal.Ekle(entity);
        }

        public void TGunceller(Marka entity)
        {
            MarkaDal.Guncelle(entity);
        }

        public Marka TItemGetir(int id)
        {
            return MarkaDal.ItemGetir(id);
        }

        public List<Marka> TListeGetir()
        {
            return MarkaDal.ListeGetir();
        }

        public void TSil(Marka entity)
        {
            MarkaDal.Sil(entity);
        }
    }
}
