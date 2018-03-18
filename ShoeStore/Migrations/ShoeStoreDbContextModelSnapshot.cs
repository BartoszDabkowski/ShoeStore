﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ShoeStore.Persistence;
using System;

namespace ShoeStore.Migrations
{
    [DbContext(typeof(ShoeStoreDbContext))]
    partial class ShoeStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoeStore.Core.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("ShoeStore.Core.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("ShoeStore.Core.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ColorId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("ShoeId");

                    b.Property<int>("SizeId");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("ShoeId");

                    b.HasIndex("SizeId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("ShoeStore.Core.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ColorId");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("ShoeId");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("ShoeId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("ShoeStore.Core.Models.Shoe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrandId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Shoes");
                });

            modelBuilder.Entity("ShoeStore.Core.Models.ShoeStyle", b =>
                {
                    b.Property<int>("ShoeId");

                    b.Property<int>("StyleId");

                    b.HasKey("ShoeId", "StyleId");

                    b.HasIndex("StyleId");

                    b.ToTable("ShoeStyles");
                });

            modelBuilder.Entity("ShoeStore.Core.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Name");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("ShoeStore.Core.Models.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("ShoeStore.Core.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("InventoryId");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("ShoeStore.Core.Models.Inventory", b =>
                {
                    b.HasOne("ShoeStore.Core.Models.Color", "Color")
                        .WithMany("Inventory")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShoeStore.Core.Models.Shoe", "Shoe")
                        .WithMany("Inventory")
                        .HasForeignKey("ShoeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShoeStore.Core.Models.Size", "Size")
                        .WithMany("Inventory")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoeStore.Core.Models.Photo", b =>
                {
                    b.HasOne("ShoeStore.Core.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShoeStore.Core.Models.Shoe", "Shoe")
                        .WithMany()
                        .HasForeignKey("ShoeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoeStore.Core.Models.Shoe", b =>
                {
                    b.HasOne("ShoeStore.Core.Models.Brand", "Brand")
                        .WithMany("Shoes")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoeStore.Core.Models.ShoeStyle", b =>
                {
                    b.HasOne("ShoeStore.Core.Models.Shoe", "Shoe")
                        .WithMany("ShoeStyles")
                        .HasForeignKey("ShoeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShoeStore.Core.Models.Style", "Style")
                        .WithMany("ShoeStyles")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoeStore.Core.Models.Transaction", b =>
                {
                    b.HasOne("ShoeStore.Core.Models.Inventory", "Inventory")
                        .WithMany("Transaction")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
