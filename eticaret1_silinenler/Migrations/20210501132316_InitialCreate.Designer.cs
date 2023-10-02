﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eticaret1;

namespace eticaret1.Migrations
{
    [DbContext(typeof(Program))]
    [Migration("20210501132316_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eticaret1_entity.Models.Categoryy", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categoryys");
                });

            modelBuilder.Entity("eticaret1_entity.Models.CategoryyProductt", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryyCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ProducttProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("CategoryyCategoryId");

                    b.HasIndex("ProducttProductId");

                    b.ToTable("CategoryyProductt");
                });

            modelBuilder.Entity("eticaret1_entity.Models.Productt", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Namee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Pricee")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Productts");
                });

            modelBuilder.Entity("eticaret1_entity.Models.CategoryyProductt", b =>
                {
                    b.HasOne("eticaret1_entity.Models.Categoryy", "Categoryy")
                        .WithMany("CategoryyProductts")
                        .HasForeignKey("CategoryyCategoryId");

                    b.HasOne("eticaret1_entity.Models.Productt", "Productt")
                        .WithMany("CategoryyProductts")
                        .HasForeignKey("ProducttProductId");

                    b.Navigation("Categoryy");

                    b.Navigation("Productt");
                });

            modelBuilder.Entity("eticaret1_entity.Models.Categoryy", b =>
                {
                    b.Navigation("CategoryyProductts");
                });

            modelBuilder.Entity("eticaret1_entity.Models.Productt", b =>
                {
                    b.Navigation("CategoryyProductts");
                });
#pragma warning restore 612, 618
        }
    }
}