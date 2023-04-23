using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylari { get; set; }
        public DbSet<Status> StatusList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=otomation;Uid=root;Pwd=Mysqlpassword3444;", new MySqlServerVersion("6.0.0"));
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<SiparisUrun>().HasKey(su => new { su.SiparisId, su.UrunId });
        //    modelBuilder.Entity<SiparisUrun>().HasOne(su => su.Siparis).WithMany(s => s.Urunler).HasForeignKey(su=>su.SiparisId);
        //    modelBuilder.Entity<SiparisUrun>().HasOne(su => su.Urun).WithMany(u => u.Siparisler).HasForeignKey(su=>su.UrunId);
        //}
    }
}