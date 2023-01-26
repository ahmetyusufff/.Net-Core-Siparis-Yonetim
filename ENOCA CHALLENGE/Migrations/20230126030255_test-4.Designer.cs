﻿// <auto-generated />
using System;
using ENOCA_CHALLENGE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ENOCACHALLENGE.Migrations
{
    [DbContext(typeof(SiparisYonetimContext))]
    [Migration("20230126030255_test-4")]
    partial class test4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ENOCA_CHALLENGE.Models.Firma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnayDurumu")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("SiparisBaslangicSaati")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("SiparisBitisSaati")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Firmalar");
                });

            modelBuilder.Entity("ENOCA_CHALLENGE.Models.Siparis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FirmaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SiparisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("SiparisVeren")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UrunId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirmaId");

                    b.HasIndex("UrunId");

                    b.ToTable("Siparisler");
                });

            modelBuilder.Entity("ENOCA_CHALLENGE.Models.Urun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FirmaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirmaId");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("ENOCA_CHALLENGE.Models.Siparis", b =>
                {
                    b.HasOne("ENOCA_CHALLENGE.Models.Firma", "Firma")
                        .WithMany("Siparisler")
                        .HasForeignKey("FirmaId")
                        .IsRequired();

                    b.HasOne("ENOCA_CHALLENGE.Models.Urun", "Urun")
                        .WithMany("Siparisler")
                        .HasForeignKey("UrunId")
                        .IsRequired();

                    b.Navigation("Firma");

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("ENOCA_CHALLENGE.Models.Urun", b =>
                {
                    b.HasOne("ENOCA_CHALLENGE.Models.Firma", "Firma")
                        .WithMany("Urunler")
                        .HasForeignKey("FirmaId")
                        .IsRequired();

                    b.Navigation("Firma");
                });

            modelBuilder.Entity("ENOCA_CHALLENGE.Models.Firma", b =>
                {
                    b.Navigation("Siparisler");

                    b.Navigation("Urunler");
                });

            modelBuilder.Entity("ENOCA_CHALLENGE.Models.Urun", b =>
                {
                    b.Navigation("Siparisler");
                });
#pragma warning restore 612, 618
        }
    }
}
