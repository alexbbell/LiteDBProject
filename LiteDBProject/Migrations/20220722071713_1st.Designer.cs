﻿// <auto-generated />
using LiteDBProject.Data.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiteDBProject.Migrations
{
    [DbContext(typeof(PremixContext))]
    [Migration("20220722071713_1st")]
    partial class _1st
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("LiteDBProject.Data.Developer", b =>
                {
                    b.Property<int>("DeveloperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DeveloperId");

                    b.ToTable("Developer", (string)null);

                    b.HasData(
                        new
                        {
                            DeveloperId = 1,
                            Country = "England",
                            Name = "Terezia"
                        },
                        new
                        {
                            DeveloperId = 2,
                            Country = "Russia",
                            Name = "Resurs"
                        });
                });

            modelBuilder.Entity("LiteDBProject.Data.Models.PremixVitamin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PremixId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VitaminId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VitaminId");

                    b.ToTable("PremixVitamins");
                });

            modelBuilder.Entity("LiteDBProject.Data.Premix", b =>
                {
                    b.Property<int>("PremixId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Vid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PremixId");

                    b.HasIndex("DeveloperId");

                    b.ToTable("Premix", (string)null);

                    b.HasData(
                        new
                        {
                            PremixId = 1,
                            Age = "small",
                            DeveloperId = 1,
                            Title = "Premix 1",
                            Tu = "tu 1",
                            Vid = "rastvor"
                        });
                });

            modelBuilder.Entity("LiteDBProject.Data.Vitamin", b =>
                {
                    b.Property<int>("VitaminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rastvor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("VitaminId");

                    b.ToTable("Vitamin", (string)null);

                    b.HasData(
                        new
                        {
                            VitaminId = 1,
                            Rastvor = "rastvor",
                            Title = "A"
                        },
                        new
                        {
                            VitaminId = 2,
                            Rastvor = "rastvor",
                            Title = "B"
                        },
                        new
                        {
                            VitaminId = 3,
                            Rastvor = "rastvor",
                            Title = "C"
                        });
                });

            modelBuilder.Entity("LiteDBProject.Data.Models.PremixVitamin", b =>
                {
                    b.HasOne("LiteDBProject.Data.Premix", "Premix")
                        .WithMany("PremixVitamins")
                        .HasForeignKey("VitaminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiteDBProject.Data.Vitamin", "Vitamin")
                        .WithMany("PremixVitamins")
                        .HasForeignKey("VitaminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Premix");

                    b.Navigation("Vitamin");
                });

            modelBuilder.Entity("LiteDBProject.Data.Premix", b =>
                {
                    b.HasOne("LiteDBProject.Data.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("LiteDBProject.Data.Premix", b =>
                {
                    b.Navigation("PremixVitamins");
                });

            modelBuilder.Entity("LiteDBProject.Data.Vitamin", b =>
                {
                    b.Navigation("PremixVitamins");
                });
#pragma warning restore 612, 618
        }
    }
}
