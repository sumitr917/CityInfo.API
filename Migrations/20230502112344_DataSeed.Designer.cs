﻿// <auto-generated />
using CityInfo.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityInfo.API.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    [Migration("20230502112344_DataSeed")]
    partial class DataSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The Land of Lord Shiva",
                            Name = "Varanasi"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Earlier known as Patliputra",
                            Name = "Patna"
                        },
                        new
                        {
                            Id = 3,
                            Description = "One of the IT hubs in India",
                            Name = "Pune"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointsOfInterest");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Description = "One of the 12 Jyotirlingas of Lord Shiva",
                            Name = "Shri Kashi Vishwanath Temple"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Description = "One of the ghats on Holy Ganges",
                            Name = "Dasashwamedha Ghat"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 2,
                            Description = "Famous Temple of Lord Hanuman at Patna Junction",
                            Name = "Shri Mahavir Temple"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            Description = "Large ground for gatherings, festivals",
                            Name = "Gandhi Maidan"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 3,
                            Description = "Full of offices of IT Companies",
                            Name = "Hinjewadi"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 3,
                            Description = "The go to party and enjoyment place",
                            Name = "Koregaon Park"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfInterest", b =>
                {
                    b.HasOne("CityInfo.API.Entities.City", "City")
                        .WithMany("PointsOfInterest")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Navigation("PointsOfInterest");
                });
#pragma warning restore 612, 618
        }
    }
}