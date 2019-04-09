﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20190409065221_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("DAL.Domain.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image")
                        .HasMaxLength(256);

                    b.Property<DateTime>("Time");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "https://cdn.myanimelist.net/images/anime/12/76049.jpg",
                            Time = new DateTime(2019, 4, 9, 9, 52, 21, 163, DateTimeKind.Local).AddTicks(8264),
                            Title = "One Punch Man",
                            Url = "https://myanimelist.net/anime/30276/One_Punch_Man",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Image = "https://cdn.myanimelist.net/images/anime/3/77176.jpg",
                            Time = new DateTime(2019, 4, 9, 9, 52, 21, 163, DateTimeKind.Local).AddTicks(8978),
                            Title = "Mobile Suit Gundam Thunderbolt",
                            Url = "https://myanimelist.net/anime/31973/Mobile_Suit_Gundam_Thunderbolt",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Image = "https://cdn.myanimelist.net/images/anime/1562/100460.jpg",
                            Time = new DateTime(2019, 4, 9, 9, 52, 21, 163, DateTimeKind.Local).AddTicks(8994),
                            Title = "Fairy Gone",
                            Url = "https://myanimelist.net/anime/39063/Fairy_Gone",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("DAL.Domain.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("MovieId");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "action",
                            MovieId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "really cool",
                            MovieId = 1
                        },
                        new
                        {
                            Id = 3,
                            Content = "military",
                            MovieId = 2
                        },
                        new
                        {
                            Id = 4,
                            Content = "michael bay",
                            MovieId = 2
                        },
                        new
                        {
                            Id = 5,
                            Content = "average at best",
                            MovieId = 2
                        },
                        new
                        {
                            Id = 6,
                            Content = "eh",
                            MovieId = 3
                        });
                });

            modelBuilder.Entity("DAL.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Joined");

                    b.Property<DateTime>("LastActive");

                    b.Property<string>("Pin")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Joined = new DateTime(2019, 4, 9, 9, 52, 21, 161, DateTimeKind.Local).AddTicks(4752),
                            LastActive = new DateTime(2019, 4, 9, 9, 52, 21, 162, DateTimeKind.Local).AddTicks(8010),
                            Pin = "0000",
                            UserName = "catnib"
                        },
                        new
                        {
                            Id = 2,
                            Joined = new DateTime(2019, 4, 9, 9, 52, 21, 162, DateTimeKind.Local).AddTicks(8281),
                            LastActive = new DateTime(2019, 4, 9, 9, 52, 21, 162, DateTimeKind.Local).AddTicks(8289),
                            Pin = "1234",
                            UserName = "siegrest"
                        },
                        new
                        {
                            Id = 3,
                            Joined = new DateTime(2019, 4, 9, 9, 52, 21, 162, DateTimeKind.Local).AddTicks(8294),
                            LastActive = new DateTime(2019, 4, 9, 9, 52, 21, 162, DateTimeKind.Local).AddTicks(8296),
                            Pin = "4568",
                            UserName = "rinnex"
                        });
                });

            modelBuilder.Entity("DAL.Domain.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Time");

                    b.Property<int>("UserId");

                    b.Property<short>("Value");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("DAL.Domain.Movie", b =>
                {
                    b.HasOne("DAL.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Domain.Tag", b =>
                {
                    b.HasOne("DAL.Domain.Movie", "Movie")
                        .WithMany("Tags")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Domain.Vote", b =>
                {
                    b.HasOne("DAL.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}