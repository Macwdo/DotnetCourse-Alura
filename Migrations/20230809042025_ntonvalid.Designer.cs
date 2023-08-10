﻿// <auto-generated />
using System;
using DOTNET6_COURSE_WEB_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DOTNET6_COURSE_WEB_API.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20230809042025_ntonvalid")]
    partial class ntonvalid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DOTNET6_COURSE_WEB_API.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DOTNET6_COURSE_WEB_API.Models.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("DOTNET6_COURSE_WEB_API.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Kind")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("DOTNET6_COURSE_WEB_API.Models.Session", b =>
                {
                    b.Property<int?>("MovieId")
                        .HasColumnType("integer");

                    b.Property<int?>("CinemaId")
                        .HasColumnType("integer");

                    b.HasKey("MovieId", "CinemaId");

                    b.HasIndex("CinemaId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("DOTNET6_COURSE_WEB_API.Models.Cinema", b =>
                {
                    b.HasOne("DOTNET6_COURSE_WEB_API.Models.Address", "Address")
                        .WithOne("Cinema")
                        .HasForeignKey("DOTNET6_COURSE_WEB_API.Models.Cinema", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("DOTNET6_COURSE_WEB_API.Models.Session", b =>
                {
                    b.HasOne("DOTNET6_COURSE_WEB_API.Models.Cinema", "Cinema")
                        .WithMany("Sessions")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DOTNET6_COURSE_WEB_API.Models.Movie", "Movie")
                        .WithMany("Sessions")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("DOTNET6_COURSE_WEB_API.Models.Address", b =>
                {
                    b.Navigation("Cinema")
                        .IsRequired();
                });

            modelBuilder.Entity("DOTNET6_COURSE_WEB_API.Models.Cinema", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("DOTNET6_COURSE_WEB_API.Models.Movie", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
