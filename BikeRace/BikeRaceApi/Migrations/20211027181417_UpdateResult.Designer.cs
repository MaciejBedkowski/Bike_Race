﻿// <auto-generated />
using System;
using BikeRaceApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BikeRaceApi.Migrations
{
    [DbContext(typeof(RaceDBContext))]
    [Migration("20211027181417_UpdateResult")]
    partial class UpdateResult
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BikeRaceApi.Entities.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<bool>("Payed")
                        .HasColumnType("bit");

                    b.Property<Guid>("RaceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResultId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.HasIndex("ResultId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("BikeRaceApi.Entities.Race", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("BikeRaceApi.Entities.Result", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdParticipant")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("BikeRaceApi.Entities.Participant", b =>
                {
                    b.HasOne("BikeRaceApi.Entities.Race", "Race")
                        .WithMany("Participants")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeRaceApi.Entities.Result", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId");

                    b.Navigation("Race");

                    b.Navigation("Result");
                });

            modelBuilder.Entity("BikeRaceApi.Entities.Race", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}