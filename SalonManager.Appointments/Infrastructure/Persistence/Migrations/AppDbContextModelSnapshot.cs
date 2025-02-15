﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SalonManager.Appointments.Infrastructure.Context;

#nullable disable

namespace SalonManager.Appointments.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SalonManager.Appointments.Core.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("CreatedAt");

                    b.Property<Guid>("CustomerAppointmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<double>("Earnings")
                        .HasColumnType("numeric");

                    b.Property<Guid>("EmployeeAppointmentId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Finished")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("FinishedDate")
                        .HasColumnType("timestamp");

                    b.Property<bool>("IsActived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PaymentWay")
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("ServiceAppointmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("UpdatedAt");

                    b.Property<Guid>("UserCreatorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Appointments", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
