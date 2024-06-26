﻿// <auto-generated />
using System;
using FundHub.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FundHub.Data.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240522132549_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FundHub.Data.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4a858ba2-cc64-4752-973a-2b1acba5d78d"),
                            Name = "product"
                        },
                        new
                        {
                            Id = new Guid("fafaad46-3fbe-40ac-ad63-c311829668a4"),
                            Name = "society"
                        },
                        new
                        {
                            Id = new Guid("59cb7c8b-8e33-45d6-b066-214f3145a3c0"),
                            Name = "environment"
                        });
                });

            modelBuilder.Entity("FundHub.Data.Data.Models.Donation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<decimal>("DonationAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("DonationLogs");
                });

            modelBuilder.Entity("FundHub.Data.Data.Models.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Imagecovername")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("Published")
                        .HasColumnType("date");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0f97ea1d-e247-4cf5-a6d9-5f9d3265e220"),
                            Description = "Desc Test",
                            Imagecovername = "newscover.jpg",
                            Published = new DateOnly(2024, 1, 1),
                            Subtitle = "",
                            Title = "Innovative Breakthroughs: College Students Secure Funding for Groundbreaking Projects"
                        },
                        new
                        {
                            Id = new Guid("1a55b12e-65b8-4542-b4c1-6676c30311e7"),
                            Description = "Desc Test",
                            Imagecovername = "newscover.jpg",
                            Published = new DateOnly(2024, 1, 1),
                            Subtitle = "",
                            Title = "Empowering Tomorrow's Leaders: College Projects Receive Major Funding Boost"
                        },
                        new
                        {
                            Id = new Guid("93097c20-6558-4ed9-a27e-8bf07fb59b8a"),
                            Description = "Desc Test",
                            Imagecovername = "newscover.jpg",
                            Published = new DateOnly(2024, 1, 1),
                            Subtitle = "",
                            Title = "From Campus to Capital: Student-Led Ventures Garner Investment for Impactful Initiatives"
                        },
                        new
                        {
                            Id = new Guid("598004de-bc37-4300-8271-3c1c0bb5c430"),
                            Description = "Desc Test",
                            Imagecovername = "newscover.jpg",
                            Published = new DateOnly(2024, 1, 1),
                            Subtitle = "",
                            Title = "Shaping the Future: College Students' Ambitious Projects Win Substantial Funding"
                        });
                });

            modelBuilder.Entity("FundHub.Data.Data.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<int>("Currentfund")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string[]>("Imagesnames")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Instagram")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Totalfundrequired")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("X")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7e4788cd-77a9-4b03-9412-385a482cf489"),
                            CategoryId = new Guid("59cb7c8b-8e33-45d6-b066-214f3145a3c0"),
                            Currentfund = 500,
                            Description = "Description Test",
                            Facebook = "",
                            Imagesnames = new[] { "1.jpg", "2.jpg" },
                            Instagram = "",
                            Subtitle = "Subtitle Test",
                            Title = "Greener Egypt",
                            Totalfundrequired = 2000,
                            UserId = new Guid("c0c343f3-a9d0-4ae6-93e4-0d1923b04e60"),
                            X = ""
                        },
                        new
                        {
                            Id = new Guid("694d6683-d3e6-4bc1-ab5d-f2f67f887332"),
                            CategoryId = new Guid("fafaad46-3fbe-40ac-ad63-c311829668a4"),
                            Currentfund = 500,
                            Description = "Description Test",
                            Facebook = "",
                            Imagesnames = new[] { "1.jpg", "2.jpg" },
                            Instagram = "",
                            Subtitle = "Subtitle Test",
                            Title = "My Super Awesome Health Machine Research Paper",
                            Totalfundrequired = 1000000,
                            UserId = new Guid("913eedbd-a304-478e-beee-4c8db66bd86a"),
                            X = ""
                        },
                        new
                        {
                            Id = new Guid("a9437a37-1d37-4a9b-adbd-a18ef0490942"),
                            CategoryId = new Guid("4a858ba2-cc64-4752-973a-2b1acba5d78d"),
                            Currentfund = 500,
                            Description = "Description Test",
                            Facebook = "",
                            Imagesnames = new[] { "1.jpg", "2.jpg" },
                            Instagram = "",
                            Subtitle = "Subtitle Test",
                            Title = "Electric Koshary Machine",
                            Totalfundrequired = 120000,
                            UserId = new Guid("2e445054-8f22-4812-adb7-38cd849c976b"),
                            X = ""
                        },
                        new
                        {
                            Id = new Guid("e9c8eccf-76aa-42d6-be67-803d8622c951"),
                            CategoryId = new Guid("4a858ba2-cc64-4752-973a-2b1acba5d78d"),
                            Currentfund = 500,
                            Description = "Description Test",
                            Facebook = "",
                            Imagesnames = new[] { "1.jpg", "2.jpg" },
                            Instagram = "",
                            Subtitle = "Subtitle Test",
                            Title = "Indie Egyptian Game",
                            Totalfundrequired = 60000,
                            UserId = new Guid("a5379337-e6a4-4222-aa88-233358bda6e9"),
                            X = ""
                        });
                });

            modelBuilder.Entity("FundHub.Data.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Hashedpassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Instagram")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Phonenumber")
                        .HasColumnType("integer");

                    b.Property<string>("Profileimage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Usertype")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("X")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c0c343f3-a9d0-4ae6-93e4-0d1923b04e60"),
                            Email = "test@gmail.com",
                            Facebook = "",
                            Hashedpassword = "l7KlGmDy9VjpekaMMqffjA==.Ar9EOmtuXvV32e2NO+l722/vROY9S/FpqzBgIumYsik=",
                            Instagram = "",
                            Phonenumber = 123456789,
                            Profileimage = "profile.jpg",
                            Username = "testuser1",
                            Usertype = "user",
                            X = ""
                        },
                        new
                        {
                            Id = new Guid("913eedbd-a304-478e-beee-4c8db66bd86a"),
                            Email = "test@gmail.com",
                            Facebook = "",
                            Hashedpassword = "7hSmeUC0KT1PAVKQ1rR69w==.ywsTWK6zAUzua86GYr3akqaT4gWmSXEI9fQyqmD7I7I=",
                            Instagram = "",
                            Phonenumber = 123456789,
                            Profileimage = "profile.jpg",
                            Username = "testuser2",
                            Usertype = "user",
                            X = ""
                        },
                        new
                        {
                            Id = new Guid("2e445054-8f22-4812-adb7-38cd849c976b"),
                            Email = "test@gmail.com",
                            Facebook = "",
                            Hashedpassword = "oXFbbQQobrIbmUtFpYGszQ==.3mDp1D3VXZQSEw4OU641t083g6DyJ0slwZAX6u7yHWs=",
                            Instagram = "",
                            Phonenumber = 123456789,
                            Profileimage = "profile.jpg",
                            Username = "testuser3",
                            Usertype = "user",
                            X = ""
                        },
                        new
                        {
                            Id = new Guid("a5379337-e6a4-4222-aa88-233358bda6e9"),
                            Email = "test@gmail.com",
                            Facebook = "",
                            Hashedpassword = "wSyLm4mMYVUJrWNttUOIZQ==.Rwiimrp/JfgY8KDJz5UfDhaymRCKWc7gCXpgQpMx1d0=",
                            Instagram = "",
                            Phonenumber = 123456789,
                            Profileimage = "profile.jpg",
                            Username = "testuser4",
                            Usertype = "user",
                            X = ""
                        },
                        new
                        {
                            Id = new Guid("9bdfe044-4b02-40a7-ade7-4570e68af19c"),
                            Email = "test@gmail.com",
                            Facebook = "",
                            Hashedpassword = "UEi36lmIDWwA8t7BkrdQng==.+rtzatRTFbuMJPn0upq9fEZRGvYqvWGTQ1/M/PTSky4=",
                            Instagram = "",
                            Phonenumber = 123456789,
                            Profileimage = "profile.jpg",
                            Username = "testuser5",
                            Usertype = "user",
                            X = ""
                        },
                        new
                        {
                            Id = new Guid("c8b590f1-c920-4c1b-9237-852bc0b43518"),
                            Email = "test@gmail.com",
                            Facebook = "",
                            Hashedpassword = "7qxsRaxVZ+elPOfiRD0rwQ==.Iaw8WmYOtJSLk7JeoySALdokrMmR2R+BNbiAWr1BHb8=",
                            Instagram = "",
                            Phonenumber = 123456789,
                            Profileimage = "profile.jpg",
                            Username = "testadmin",
                            Usertype = "admin",
                            X = ""
                        });
                });

            modelBuilder.Entity("FundHub.Data.Data.Models.Donation", b =>
                {
                    b.HasOne("FundHub.Data.Data.Models.Project", "Project")
                        .WithMany("Donations")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FundHub.Data.Data.Models.User", "User")
                        .WithMany("Donations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FundHub.Data.Data.Models.Project", b =>
                {
                    b.HasOne("FundHub.Data.Data.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FundHub.Data.Data.Models.User", "User")
                        .WithOne("Project")
                        .HasForeignKey("FundHub.Data.Data.Models.Project", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FundHub.Data.Data.Models.Project", b =>
                {
                    b.Navigation("Donations");
                });

            modelBuilder.Entity("FundHub.Data.Data.Models.User", b =>
                {
                    b.Navigation("Donations");

                    b.Navigation("Project");
                });
#pragma warning restore 612, 618
        }
    }
}
