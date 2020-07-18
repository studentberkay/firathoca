﻿// <auto-generated />
using FiratHoca.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FiratHoca.Migrations
{
    [DbContext(typeof(FiratHocaContext))]
    partial class FiratHocaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("FiratHoca.Models.Resim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DosyaAdi")
                        .HasColumnType("TEXT");

                    b.Property<int>("BebekuId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BebekuId");

                    b.ToTable("Resimler");
                });

            modelBuilder.Entity("FiratHoca.Models.Bebek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Kilo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bebekler");
                });

            modelBuilder.Entity("FiratHoca.Models.Resim", b =>
                {
                    b.HasOne("FiratHoca.Models.Bebek", "Bebeku")
                        .WithMany("Resimler")
                        .HasForeignKey("BebekuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
