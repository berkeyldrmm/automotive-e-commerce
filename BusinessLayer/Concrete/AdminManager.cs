using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Otomativ_e_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        public IAdminDal AdminDal { get; set; }

        public AdminManager(IAdminDal adminDal)
        {
            AdminDal = adminDal;
        }

        public void TEkle(Admin entity)
        {
            AdminDal.Ekle(entity);
        }

        public void TGunceller(Admin entity)
        {
            AdminDal.Guncelle(entity);
        }

        public Admin TItemGetir(int id)
        {
            return AdminDal.ItemGetir(id);
        }

        public List<Admin> TListeGetir()
        {
            return AdminDal.ListeGetir();
        }

        public void TSil(Admin entity)
        {
            AdminDal.Sil(entity);
        }

        public bool AdminGirisKontrol(Admin admin)
        {
                var Admin = AdminDal.KullaniciAdiylaGetir(admin.KullaniciAdi);
                if (Admin != null)
                {
                    if (admin.Sifre == Admin.Sifre)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Error("Şifre yanlış");
                    }
                }
                else
                {
                    throw new Error("Kullanıcı adı veya şifre yanlış");
                }
        }
    }
}
