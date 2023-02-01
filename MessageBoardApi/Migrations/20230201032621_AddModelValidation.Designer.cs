﻿// <auto-generated />
using System;
using MessageBoardApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MessageBoardApi.Migrations
{
    [DbContext(typeof(MessageBoardApiContext))]
    [Migration("20230201032621_AddModelValidation")]
    partial class AddModelValidation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MessageBoardApi.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = 1,
                            Comment = "I'm a good boy",
                            Date = new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "Good Times",
                            UserName = "mr_hans"
                        },
                        new
                        {
                            MessageId = 2,
                            Comment = "Time is crazy",
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "Good Times",
                            UserName = "mr_hans"
                        },
                        new
                        {
                            MessageId = 3,
                            Comment = "I like time, i'm obsessed with it.",
                            Date = new DateTime(2023, 1, 29, 18, 0, 21, 0, DateTimeKind.Unspecified),
                            Group = "Good Times",
                            UserName = "mr_hans"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
