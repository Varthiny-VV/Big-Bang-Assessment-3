﻿// <auto-generated />
using System;
using Bookings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookings.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Bookings.Models.AdditionalTravellers", b =>
                {
                    b.Property<int>("AdditionalTravellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdditionalTravellerId"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PackageId")
                        .HasColumnType("int");

                    b.Property<string>("TravellerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("id")
                        .HasColumnType("int");

                    b.HasKey("AdditionalTravellerId");

                    b.HasIndex("id");

                    b.ToTable("AdditionalTravellers");
                });

            modelBuilder.Entity("Bookings.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"), 1L, 1);

                    b.Property<int?>("AvailableCount")
                        .HasColumnType("int");

                    b.Property<string>("Drop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<string>("PickUp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TravelAgentId")
                        .HasColumnType("int");

                    b.Property<int>("TravellerCount")
                        .HasColumnType("int");

                    b.Property<string>("TravellerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Bookings.Models.AdditionalTravellers", b =>
                {
                    b.HasOne("Bookings.Models.Booking", "Booking")
                        .WithMany("Travellers")
                        .HasForeignKey("id");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Bookings.Models.Booking", b =>
                {
                    b.Navigation("Travellers");
                });
#pragma warning restore 612, 618
        }
    }
}
