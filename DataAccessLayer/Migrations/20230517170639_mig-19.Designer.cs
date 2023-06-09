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
    [Migration("20230517170639_mig-19")]
    partial class mig19
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntityLayer.Concrete.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.HasKey("AdminId");

                    b.ToTable("Adminler");
                });

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

            modelBuilder.Entity("EntityLayer.Concrete.Kategori", b =>
                {
                    b.Property<int>("KategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("KategoriKod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UrunCesitId")
                        .HasColumnType("int");

                    b.HasKey("KategoriId");

                    b.HasIndex("UrunCesitId");

                    b.ToTable("Kategoriler");
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

            modelBuilder.Entity("EntityLayer.Concrete.Marka", b =>
                {
                    b.Property<int>("MarkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MarkaAdi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MarkaKod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UrunCesitId")
                        .HasColumnType("int");

                    b.HasKey("MarkaId");

                    b.HasIndex("UrunCesitId");

                    b.ToTable("Markalar");
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
                        .IsRequired()
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
                        .HasColumnType("longtext");

                    b.Property<double>("Fiyat")
                        .HasColumnType("double");

                    b.Property<string>("GorselUrl")
                        .HasColumnType("longtext");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<int>("MarkaId")
                        .HasColumnType("int");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.Property<string>("UrunAdi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UrunCesitId")
                        .HasColumnType("int");

                    b.HasKey("UrunId");

                    b.HasIndex("KategoriId");

                    b.HasIndex("MarkaId");

                    b.HasIndex("UrunCesitId");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("EntityLayer.Concrete.UrunCesit", b =>
                {
                    b.Property<int>("UrunCesitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CesitAdi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CesitKod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UrunCesitId");

                    b.ToTable("UrunCesitleri");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kategori", b =>
                {
                    b.HasOne("EntityLayer.Concrete.UrunCesit", "UrunCesidi")
                        .WithMany("Kategoriler")
                        .HasForeignKey("UrunCesitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UrunCesidi");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Marka", b =>
                {
                    b.HasOne("EntityLayer.Concrete.UrunCesit", "UrunCesidi")
                        .WithMany()
                        .HasForeignKey("UrunCesitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UrunCesidi");
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

            modelBuilder.Entity("EntityLayer.Concrete.Urun", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Kategori", "kategori")
                        .WithMany("Urunler")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Marka", "marka")
                        .WithMany("Urunler")
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.UrunCesit", "UrunCesidi")
                        .WithMany("Urunler")
                        .HasForeignKey("UrunCesitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UrunCesidi");

                    b.Navigation("kategori");

                    b.Navigation("marka");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kategori", b =>
                {
                    b.Navigation("Urunler");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Marka", b =>
                {
                    b.Navigation("Urunler");
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

            modelBuilder.Entity("EntityLayer.Concrete.UrunCesit", b =>
                {
                    b.Navigation("Kategoriler");

                    b.Navigation("Urunler");
                });
#pragma warning restore 612, 618
        }
    }
}
