﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("WebApi.Models.PrayerRequest", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAnswered")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRespondedTo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PrayerAsk")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RequestId");

                    b.ToTable("PrayerRequests");
                });

            modelBuilder.Entity("WebApi.Models.PrayerResponse", b =>
                {
                    b.Property<int>("responseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("ministerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("opId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("prayerTextResponse")
                        .HasColumnType("TEXT");

                    b.Property<int>("requestId")
                        .HasColumnType("INTEGER");

                    b.HasKey("responseId");

                    b.ToTable("PrayerResponses");
                });

            modelBuilder.Entity("WebApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
