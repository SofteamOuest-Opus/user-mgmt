﻿// <auto-generated />
using System;
using DatabaseInfrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DatabaseInfrastructure.Migrations
{
    [DbContext(typeof(UserMgmtContext))]
    [Migration("20200129110140_AddEmployees")]
    partial class AddEmployees
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DatabaseInfrastructure.Entities.EmployeeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("HumanResourceManagerId")
                        .HasColumnType("uuid");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OccupationId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OfficeId")
                        .HasColumnType("uuid");

                    b.Property<string>("PhotoUri")
                        .HasColumnType("text");

                    b.Property<Guid?>("StatusId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("HumanResourceManagerId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("OccupationId");

                    b.HasIndex("OfficeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DatabaseInfrastructure.Entities.OccupationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Occupations");
                });

            modelBuilder.Entity("DatabaseInfrastructure.Entities.OfficeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("DatabaseInfrastructure.Entities.StatusEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("DatabaseInfrastructure.Entities.EmployeeEntity", b =>
                {
                    b.HasOne("DatabaseInfrastructure.Entities.EmployeeEntity", "HumanResourceManager")
                        .WithMany()
                        .HasForeignKey("HumanResourceManagerId");

                    b.HasOne("DatabaseInfrastructure.Entities.EmployeeEntity", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("DatabaseInfrastructure.Entities.OccupationEntity", "Occupation")
                        .WithMany()
                        .HasForeignKey("OccupationId");

                    b.HasOne("DatabaseInfrastructure.Entities.OfficeEntity", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId");

                    b.HasOne("DatabaseInfrastructure.Entities.StatusEntity", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
