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
    [Migration("20171129191733_SeedStylesTable")]
    partial class SeedStylesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoeStore.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("ShoeStore.Models.Shoe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrandId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Shoes");
                });

            modelBuilder.Entity("ShoeStore.Models.ShoeStyle", b =>
                {
                    b.Property<int>("ShoeId");

                    b.Property<int>("StyleId");

                    b.HasKey("ShoeId", "StyleId");

                    b.HasIndex("StyleId");

                    b.ToTable("ShoeStyles");
                });

            modelBuilder.Entity("ShoeStore.Models.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("ShoeStore.Models.Shoe", b =>
                {
                    b.HasOne("ShoeStore.Models.Brand", "Brand")
                        .WithMany("Shoes")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoeStore.Models.ShoeStyle", b =>
                {
                    b.HasOne("ShoeStore.Models.Shoe", "Shoe")
                        .WithMany("ShoeStyles")
                        .HasForeignKey("ShoeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShoeStore.Models.Style", "Style")
                        .WithMany("ShoeStyles")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
