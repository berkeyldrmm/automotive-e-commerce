﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230425174822_mig-8")]
    partial class mig8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntityLayer.Concrete.Hakkimizda", b =>
                {
                    b.Property<int>("HakkimizdaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Aktiflik")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("GorselUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Metin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("HakkimizdaId");

                    b.ToTable("Hakkimizda");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Kullaniciadi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Siparisler")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Mesaj", b =>
                {
                    b.Property<int>("MesajId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MesajSahibiIsimSoyisim")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MesajSahibiMail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MesajSahibiTelefon")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("MesajZamani")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TextMesaj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MesajId");

                    b.ToTable("IletisimForm");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Siparis", b =>
                {
                    b.Property<int>("SiparisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Mail")
                        .HasColumnType("longtext");

                    b.Property<double>("SiparisTutari")
                        .HasColumnType("double");

                    b.Property<DateTime>("SiparisZamani")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Soyisim")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("TelefonNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SiparisId");

                    b.HasIndex("StatusId");

                    b.ToTable("Siparisler");
                });

            modelBuilder.Entity("EntityLayer.Concrete.SiparisDetay", b =>
                {
                    b.Property<int>("SiparisDetayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Miktar")
                        .HasColumnType("int");

                    b.Property<int>("SiparisId")
                        .HasColumnType("int");

                    b.Property<int>("UrunId")
                        .HasColumnType("int");

                    b.HasKey("SiparisDetayId");

                    b.HasIndex("SiparisId");

                    b.HasIndex("UrunId");

                    b.ToTable("SiparisDetaylari");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StatusId");

                    b.ToTable("StatusList");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Urun", b =>
                {
                    b.Property<int>("UrunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Fiyat")
                        .HasColumnType("double");

                    b.Property<string>("GorselUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.Property<string>("UrunAdi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UstKategori")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UrunId");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Siparis", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Status", "Status")
                        .WithMany("Siparisler")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EntityLayer.Concrete.SiparisDetay", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Siparis", "Siparis")
                        .WithMany("SiparisDetayi")
                        .HasForeignKey("SiparisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Urun", "Urun")
                        .WithMany("Siparisler")
                        .HasForeignKey("UrunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Siparis");

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Siparis", b =>
                {
                    b.Navigation("SiparisDetayi");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Status", b =>
                {
                    b.Navigation("Siparisler");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Urun", b =>
                {
                    b.Navigation("Siparisler");
                });
#pragma warning restore 612, 618
        }
    }
}
