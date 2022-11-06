﻿// <auto-generated />
using System;
using MeetupManager.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeetupManager.Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220520124015_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("MeetupManager.Core.Data.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Austria"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Belgium"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bulgaria"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Croatia"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Cyprus"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Czech Republic"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Denmark"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Estonia"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Finland"
                        },
                        new
                        {
                            Id = 10,
                            Name = "France"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Germany"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Greece"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Hungary"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Ireland"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Italy"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Latvia"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Lithuania"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Luxembourg"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Malta"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Netherlands"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Poland"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Portugal"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Romania"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Slovakia"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Slovenia"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Spain"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Sweden"
                        });
                });

            modelBuilder.Entity("MeetupManager.Core.Data.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Zip")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Sokolovska 352/215",
                            City = "Praha",
                            CountryId = 6,
                            Name = "RIGANTI Prague",
                            Zip = "190 00"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Hybesova 61",
                            City = "Brno",
                            CountryId = 6,
                            Name = "RIGANTI Brno",
                            Zip = "602 00"
                        },
                        new
                        {
                            Id = 3,
                            City = "Bratislava",
                            CountryId = 24,
                            Name = "Bratislava Startup Hub"
                        },
                        new
                        {
                            Id = 4,
                            City = "Berlin",
                            CountryId = 11,
                            Name = "Berlin Cowork"
                        },
                        new
                        {
                            Id = 5,
                            City = "Dresden",
                            CountryId = 11,
                            Name = "Community Hub Dresden"
                        });
                });

            modelBuilder.Entity("MeetupManager.Core.Data.Meetup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Meetups");
                });

            modelBuilder.Entity("MeetupManager.Core.Data.Location", b =>
                {
                    b.HasOne("MeetupManager.Core.Data.Country", "Country")
                        .WithMany("Locations")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MeetupManager.Core.Data.Meetup", b =>
                {
                    b.HasOne("MeetupManager.Core.Data.Location", "Location")
                        .WithMany("Meetups")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("MeetupManager.Core.Data.Country", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("MeetupManager.Core.Data.Location", b =>
                {
                    b.Navigation("Meetups");
                });
#pragma warning restore 612, 618
        }
    }
}
