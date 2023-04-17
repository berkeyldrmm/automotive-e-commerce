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
    [Migration("20230402233843_mig-8")]
    partial class mig8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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

            modelBuilder.Entity("EntityLayer.Concrete.Siparis", b =>
                {
                    b.Property<int>("SiparisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SiparisMiktari")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SiparisZamani")
                        .HasColumnType("int");

                    b.Property<string>("UrunId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SiparisId");

                    b.ToTable("Siparisler");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Urun", b =>
                {
                    b.Property<int>("UrunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double?>("Fiyat")
                        .HasColumnType("double");

                    b.Property<string>("GorselUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Stok")
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
#pragma warning restore 612, 618
        }
    }
}