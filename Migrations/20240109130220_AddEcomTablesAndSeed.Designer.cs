﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ComApi.Data;

#nullable disable

namespace ComApi.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20240109130220_AddEcomTablesAndSeed")]
    partial class AddEcomTablesAndSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ComApi.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Laptops"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Computers"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Electronics"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "HP"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Mobiles"
                        },
                        new
                        {
                            CategoryId = 6,
                            Name = "Apple"
                        },
                        new
                        {
                            CategoryId = 7,
                            Name = "Samsung"
                        },
                        new
                        {
                            CategoryId = 8,
                            Name = "TVs"
                        });
                });

            modelBuilder.Entity("ComApi.Models.Product", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ItemId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Hp Laptop 15"
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "iPhone 15"
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "Samsung S23"
                        },
                        new
                        {
                            ProductId = 4,
                            Name = "Samsung LED Screen 32"
                        });
                });

            modelBuilder.Entity("ComApi.Models.ProductCategory", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategory");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 4
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 5
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 6
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 5
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 7
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 8
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 7
                        });
                });

            modelBuilder.Entity("ComApi.Models.ProductCategory", b =>
                {
                    b.HasOne("ComApi.Models.Category", "Category")
                        .WithMany("ProductCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComApi.Models.Product", "Product")
                        .WithMany("ProductCategory")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ComApi.Models.Category", b =>
                {
                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("ComApi.Models.Product", b =>
                {
                    b.Navigation("ProductCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
