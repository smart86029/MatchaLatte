﻿// <auto-generated />
using System;
using MatchaLatte.HumanResources.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatchaLatte.HumanResources.Data.Migrations
{
    [DbContext(typeof(HumanResourcesContext))]
    [Migration("20190720153023_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("HumanResources")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("MatchaLatte.HumanResources.Domain.Departments.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("MatchaLatte.HumanResources.Domain.Employees.JobChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DepartmentId");

                    b.Property<Guid>("EmployeeId");

                    b.Property<DateTime?>("EndOn");

                    b.Property<Guid>("JobTitleId");

                    b.Property<DateTime>("StartOn");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("JobTitleId");

                    b.ToTable("JobChange");
                });

            modelBuilder.Entity("MatchaLatte.HumanResources.Domain.JobTitles.JobTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("JobTitle");
                });

            modelBuilder.Entity("MatchaLatte.HumanResources.Domain.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int>("MaritalStatus");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("MatchaLatte.HumanResources.Domain.Employees.Employee", b =>
                {
                    b.HasBaseType("MatchaLatte.HumanResources.Domain.Person");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("MatchaLatte.HumanResources.Domain.Employees.JobChange", b =>
                {
                    b.HasOne("MatchaLatte.HumanResources.Domain.Employees.Employee")
                        .WithMany("JobChanges")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
