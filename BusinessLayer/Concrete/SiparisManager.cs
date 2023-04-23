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
    public class SiparisManager : ISiparisService
    {
        //Dependency Injection
        private ISiparisDal SiparisDal { get; set; }

        public SiparisManager(ISiparisDal siparisService)
        {
            SiparisDal = siparisService;
        }
        public void TEkle(Siparis entity)
        {
            SiparisDal.Ekle(entity);
        }

        public void TGunceller(Siparis entity)
        {
            SiparisDal.Guncelle(entity);
        }

        public List<Siparis> TListeGetir()
        {
            return SiparisDal.ListeGetir();
        }

        public void TSil(Siparis entity)
        {
            SiparisDal.Sil(entity);
        }

        public Siparis TItemGetir(int id)
        {
            return SiparisDal.ItemGetir(id);
        }
    }
}
