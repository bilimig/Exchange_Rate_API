﻿// <auto-generated />
using Exchange_Rate_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exchange_Rate_API.Migrations
{
    [DbContext(typeof(ExchangeHouse))]
    [Migration("20240327164008_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("Exchange_Rate_API.DbExchangeData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("key")
                        .HasColumnType("TEXT");

                    b.Property<long>("timestamp")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ExchangeData");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            key = "PLN",
                            timestamp = 1241324L,
                            value = 4.0m
                        },
                        new
                        {
                            Id = 2,
                            key = "USD",
                            timestamp = 1241324L,
                            value = 1.0m
                        },
                        new
                        {
                            Id = 3,
                            key = "EUR",
                            timestamp = 1241324L,
                            value = 0.9m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}