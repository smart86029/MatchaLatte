﻿// <auto-generated />
using System;
using Manager.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Data.Migrations
{
    [DbContext(typeof(ManagerContext))]
    partial class ManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview2-30571")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Manager.Models.Generic.BusinessEntity", b =>
                {
                    b.Property<int>("BusinessEntityId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("BusinessEntityId");

                    b.ToTable("BusinessEntity","Generic");
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Remark")
                        .HasMaxLength(512);

                    b.Property<DateTime>("StartTime");

                    b.HasKey("GroupId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Group","GroupBuying");
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.GroupStore", b =>
                {
                    b.Property<int>("GroupId");

                    b.Property<int>("StoreId");

                    b.HasKey("GroupId", "StoreId");

                    b.HasIndex("StoreId");

                    b.ToTable("GroupStore","GroupBuying");
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int>("ProductCategoryId");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Product","GroupBuying");
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int>("StoreId");

                    b.HasKey("ProductCategoryId");

                    b.HasIndex("StoreId");

                    b.ToTable("ProductCategory","GroupBuying");
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.ProductItem", b =>
                {
                    b.Property<int>("ProductItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(32);

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductId");

                    b.HasKey("ProductItemId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductItem","GroupBuying");
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.ProductOption", b =>
                {
                    b.Property<int>("ProductOptionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int>("ProductOptionType");

                    b.HasKey("ProductOptionId");

                    b.HasIndex("ProductOptionType");

                    b.ToTable("ProductOption","GroupBuying");
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.ProductProductOption", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("ProductOptionId");

                    b.HasKey("ProductId", "ProductOptionId");

                    b.HasIndex("ProductOptionId");

                    b.ToTable("ProductProductOption","GroupBuying");
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(128);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description")
                        .HasMaxLength(512);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("Phone")
                        .HasMaxLength(32);

                    b.Property<string>("Remark")
                        .HasMaxLength(512);

                    b.HasKey("StoreId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Store","GroupBuying");
                });

            modelBuilder.Entity("Manager.Models.System.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action")
                        .HasMaxLength(50);

                    b.Property<string>("Area")
                        .HasMaxLength(50);

                    b.Property<string>("Controller")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Order");

                    b.Property<int?>("ParentId");

                    b.HasKey("MenuId");

                    b.HasIndex("ParentId");

                    b.ToTable("Menu","System");
                });

            modelBuilder.Entity("Manager.Models.System.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("RoleId");

                    b.ToTable("Role","System");
                });

            modelBuilder.Entity("Manager.Models.System.RoleMenu", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("MenuId");

                    b.HasKey("RoleId", "MenuId");

                    b.HasIndex("MenuId");

                    b.ToTable("RoleMenu","System");
                });

            modelBuilder.Entity("Manager.Models.System.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BusinessEntityId");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("UserId");

                    b.HasIndex("BusinessEntityId");

                    b.ToTable("User","System");
                });

            modelBuilder.Entity("Manager.Models.System.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole","System");
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.Group", b =>
                {
                    b.HasOne("Manager.Models.System.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.GroupStore", b =>
                {
                    b.HasOne("Manager.Models.GroupBuying.Group", "Group")
                        .WithMany("GroupStores")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Manager.Models.GroupBuying.Store", "Store")
                        .WithMany("GroupStores")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.Product", b =>
                {
                    b.HasOne("Manager.Models.GroupBuying.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.ProductCategory", b =>
                {
                    b.HasOne("Manager.Models.GroupBuying.Store", "Store")
                        .WithMany("ProductCategories")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.ProductItem", b =>
                {
                    b.HasOne("Manager.Models.GroupBuying.Product")
                        .WithMany("ProductItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.ProductProductOption", b =>
                {
                    b.HasOne("Manager.Models.GroupBuying.Product", "Product")
                        .WithMany("ProductProductOptions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Manager.Models.GroupBuying.ProductOption", "ProductOption")
                        .WithMany("ProductProductOptions")
                        .HasForeignKey("ProductOptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Manager.Models.GroupBuying.Store", b =>
                {
                    b.HasOne("Manager.Models.System.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Manager.Models.System.Menu", b =>
                {
                    b.HasOne("Manager.Models.System.Menu", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Manager.Models.System.RoleMenu", b =>
                {
                    b.HasOne("Manager.Models.System.Menu", "Menu")
                        .WithMany("RoleMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Manager.Models.System.Role", "Role")
                        .WithMany("RoleMenus")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Manager.Models.System.User", b =>
                {
                    b.HasOne("Manager.Models.Generic.BusinessEntity", "BusinessEntity")
                        .WithMany()
                        .HasForeignKey("BusinessEntityId");
                });

            modelBuilder.Entity("Manager.Models.System.UserRole", b =>
                {
                    b.HasOne("Manager.Models.System.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Manager.Models.System.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
