﻿// <auto-generated />
using System;
using Feedbacks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Feedbacks.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230806183928_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Feedbacks.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackID"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PackageId")
                        .HasColumnType("int");

                    b.Property<double?>("Ratings")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<int>("TravellerId")
                        .HasColumnType("int");

                    b.HasKey("FeedbackID");

                    b.ToTable("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}