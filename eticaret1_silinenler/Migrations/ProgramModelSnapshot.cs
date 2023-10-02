﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eticaret1;

namespace eticaret1.Migrations
{
    [DbContext(typeof(Program))]
    partial class ProgramModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CategoryyProductt", b =>
                {
                    b.Property<int>("CategoryysCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProducttProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryysCategoryId", "ProducttProductId");

                    b.HasIndex("ProducttProductId");

                    b.ToTable("CategoryyProductt");
                });

            modelBuilder.Entity("eticaret1_entity.Models.Categoryy", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Categoryys");
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

            modelBuilder.Entity("CategoryyProductt", b =>
                {
                    b.HasOne("eticaret1_entity.Models.Categoryy", null)
                        .WithMany()
                        .HasForeignKey("CategoryysCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eticaret1_entity.Models.Productt", null)
                        .WithMany()
                        .HasForeignKey("ProducttProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}