﻿// <auto-generated />
using System;
using MatchaLatte.Catalog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatchaLatte.Catalog.Data.Migrations
{
    [DbContext(typeof(CatalogContext))]
    partial class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Catalog")
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MatchaLatte.Catalog.Domain.Groups.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("EndOn");

                    b.Property<string>("Remark")
                        .HasMaxLength(512);

                    b.Property<DateTime>("StartOn");

                    b.Property<Guid>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("MatchaLatte.Catalog.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(512);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<Guid>("ProductCategoryId");

                    b.Property<int>("Sequence");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MatchaLatte.Catalog.Domain.Products.ProductItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(32);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(19, 4)");

                    b.Property<Guid>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductItem");
                });

            modelBuilder.Entity("MatchaLatte.Catalog.Domain.Stores.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int>("Sequence");

                    b.Property<Guid>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("MatchaLatte.Catalog.Domain.Stores.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description")
                        .HasMaxLength(512);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("Remark")
                        .HasMaxLength(512);

                    b.HasKey("Id");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("MatchaLatte.Common.Events.EventLog", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("EventContent")
                        .IsRequired();

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("EventTypeNamespace")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("PublishCount");

                    b.Property<int>("PublishState");

                    b.HasKey("EventId");

                    b.ToTable("EventLog","Common");
                });

            modelBuilder.Entity("MatchaLatte.Catalog.Domain.Groups.Group", b =>
                {
                    b.HasOne("MatchaLatte.Catalog.Domain.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MatchaLatte.Catalog.Domain.Products.Product", b =>
                {
                    b.HasOne("MatchaLatte.Catalog.Domain.Stores.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MatchaLatte.Catalog.Domain.Products.ProductItem", b =>
                {
                    b.HasOne("MatchaLatte.Catalog.Domain.Products.Product", "Product")
                        .WithMany("ProductItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MatchaLatte.Catalog.Domain.Stores.ProductCategory", b =>
                {
                    b.HasOne("MatchaLatte.Catalog.Domain.Stores.Store", "Store")
                        .WithMany("ProductCategories")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MatchaLatte.Catalog.Domain.Stores.Store", b =>
                {
                    b.OwnsOne("MatchaLatte.Catalog.Domain.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("StoreId");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnName("City")
                                .HasMaxLength(32);

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnName("Country")
                                .HasMaxLength(32);

                            b1.Property<string>("District")
                                .IsRequired()
                                .HasColumnName("District")
                                .HasMaxLength(32);

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnName("PostalCode")
                                .HasMaxLength(8);

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnName("Street")
                                .HasMaxLength(128);

                            b1.HasKey("StoreId");

                            b1.ToTable("Store","Catalog");

                            b1.HasOne("MatchaLatte.Catalog.Domain.Stores.Store")
                                .WithOne("Address")
                                .HasForeignKey("MatchaLatte.Catalog.Domain.Address", "StoreId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("MatchaLatte.Catalog.Domain.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("StoreId");

                            b1.Property<string>("CountryCode")
                                .IsRequired()
                                .HasColumnName("CountryCode")
                                .HasMaxLength(4);

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasColumnName("PhoneNumber")
                                .HasMaxLength(32);

                            b1.Property<int>("PhoneType")
                                .HasColumnName("PhoneType");

                            b1.HasKey("StoreId");

                            b1.ToTable("Store","Catalog");

                            b1.HasOne("MatchaLatte.Catalog.Domain.Stores.Store")
                                .WithOne("Phone")
                                .HasForeignKey("MatchaLatte.Catalog.Domain.Phone", "StoreId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("MatchaLatte.Catalog.Domain.Picture", "Logo", b1 =>
                        {
                            b1.Property<Guid>("StoreId");

                            b1.Property<string>("FileName")
                                .IsRequired()
                                .HasColumnName("LogoFileName")
                                .HasMaxLength(256);

                            b1.HasKey("StoreId");

                            b1.ToTable("Store","Catalog");

                            b1.HasOne("MatchaLatte.Catalog.Domain.Stores.Store")
                                .WithOne("Logo")
                                .HasForeignKey("MatchaLatte.Catalog.Domain.Picture", "StoreId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
