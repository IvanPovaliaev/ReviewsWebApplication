﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reviews.Domain;

#nullable disable

namespace Reviews.Domain.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20241204174251_InitDb")]
    partial class InitDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Reviews.Domain.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "admin",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Reviews.Domain.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Grade")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2024, 12, 3, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8055),
                            Grade = 2.0,
                            ProductId = new Guid("99ed296b-8842-42c5-b426-a94374a74136")
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2024, 10, 9, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8088),
                            Grade = 3.0,
                            ProductId = new Guid("337f6d24-7f2e-47e1-8bbb-544c35716610")
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2024, 11, 14, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8107),
                            Grade = 4.0,
                            ProductId = new Guid("534c9309-f5ea-412a-a859-b2c5e67d22d3")
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(2024, 10, 27, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8117),
                            Grade = 5.0,
                            ProductId = new Guid("7810de42-0d84-41a0-b0da-e35b762976cb")
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(2024, 10, 8, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8131),
                            Grade = 3.3999999999999999,
                            ProductId = new Guid("9dd2814e-fd38-4e98-8dfd-a169381b6efd")
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(2024, 9, 14, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8173),
                            Grade = 2.6699999999999999,
                            ProductId = new Guid("e131f5a9-fe96-4e6a-8124-520056ba2060")
                        },
                        new
                        {
                            Id = 7,
                            CreationDate = new DateTime(2024, 11, 5, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8187),
                            Grade = 2.1400000000000001,
                            ProductId = new Guid("2e9d973e-efd2-41f2-9e8d-56a84350d64d")
                        },
                        new
                        {
                            Id = 8,
                            CreationDate = new DateTime(2024, 11, 14, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8202),
                            Grade = 3.2999999999999998,
                            ProductId = new Guid("a8a072b7-45cf-496b-89a0-ab2373076e00")
                        },
                        new
                        {
                            Id = 9,
                            CreationDate = new DateTime(2024, 11, 28, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8217),
                            Grade = 4.0,
                            ProductId = new Guid("619238df-47bb-470c-9b64-10b4adc66733")
                        },
                        new
                        {
                            Id = 10,
                            CreationDate = new DateTime(2024, 10, 6, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8231),
                            Grade = 1.0,
                            ProductId = new Guid("82faf50d-e506-4a71-94c6-ef72c81c2cd6")
                        });
                });

            modelBuilder.Entity("Reviews.Domain.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RatingId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RatingId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2024, 9, 15, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(6952),
                            Grade = 5,
                            ProductId = new Guid("99ed296b-8842-42c5-b426-a94374a74136"),
                            RatingId = 1,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiu",
                            UserId = "c0003160-e627-408b-9a05-f8d7f9e3e494"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2024, 10, 31, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(6996),
                            Grade = 0,
                            ProductId = new Guid("b408c25f-2ac0-4783-b2f6-9381d49920ad"),
                            RatingId = 1,
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do ei",
                            UserId = "8874d691-d16b-4827-8fd4-09b2010a31e3"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2024, 11, 27, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7015),
                            Grade = 1,
                            ProductId = new Guid("b6a5a3df-198a-452f-ac60-7e8c3004e317"),
                            RatingId = 1,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut",
                            UserId = "47e19264-71a5-4082-8857-6ec4f33ce033"
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(2024, 11, 28, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7038),
                            Grade = 4,
                            ProductId = new Guid("337f6d24-7f2e-47e1-8bbb-544c35716610"),
                            RatingId = 2,
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing el",
                            UserId = "5415b954-88d9-42c4-86e4-71d4e8890c40"
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(2024, 12, 2, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7113),
                            Grade = 2,
                            ProductId = new Guid("e1c477e9-9fd5-4186-80ec-fc8989d0b498"),
                            RatingId = 2,
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed",
                            UserId = "4d263476-137c-409f-9264-2a84491cb4ae"
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(2024, 9, 8, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7137),
                            Grade = 4,
                            ProductId = new Guid("534c9309-f5ea-412a-a859-b2c5e67d22d3"),
                            RatingId = 3,
                            Status = 1,
                            Text = "Lorem ipsum dolor sit am",
                            UserId = "b7a8b2a5-c95f-4ff5-829c-a002f6dc76db"
                        },
                        new
                        {
                            Id = 7,
                            CreationDate = new DateTime(2024, 11, 17, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7156),
                            Grade = 5,
                            ProductId = new Guid("7810de42-0d84-41a0-b0da-e35b762976cb"),
                            RatingId = 4,
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adi",
                            UserId = "c9fa7dbb-e6f1-495b-a5f2-18da36699df4"
                        },
                        new
                        {
                            Id = 8,
                            CreationDate = new DateTime(2024, 11, 6, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7180),
                            Grade = 4,
                            ProductId = new Guid("9dd2814e-fd38-4e98-8dfd-a169381b6efd"),
                            RatingId = 5,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiu",
                            UserId = "ddb2af6c-d8cb-403f-84e3-61774da4cb35"
                        },
                        new
                        {
                            Id = 9,
                            CreationDate = new DateTime(2024, 10, 20, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7198),
                            Grade = 3,
                            ProductId = new Guid("0f97a69a-78ad-4410-811c-18b9810546ca"),
                            RatingId = 5,
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, cons",
                            UserId = "16f8c9a4-4db8-4ea4-afcf-685f9b04a22e"
                        },
                        new
                        {
                            Id = 10,
                            CreationDate = new DateTime(2024, 11, 12, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7222),
                            Grade = 3,
                            ProductId = new Guid("262f1831-cc72-430a-ae59-4a669969ed7b"),
                            RatingId = 5,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing",
                            UserId = "8148a282-282b-47f6-8f91-9b39c5164fbe"
                        },
                        new
                        {
                            Id = 11,
                            CreationDate = new DateTime(2024, 9, 3, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7242),
                            Grade = 4,
                            ProductId = new Guid("c6dbfe7f-91b5-4bcf-93b7-ba3155f61dca"),
                            RatingId = 5,
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, c",
                            UserId = "01d31bf3-ee27-43ff-afab-9509e8db1379"
                        },
                        new
                        {
                            Id = 12,
                            CreationDate = new DateTime(2024, 10, 29, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7260),
                            Grade = 3,
                            ProductId = new Guid("3900c019-617e-4903-bb21-a31fefb2defe"),
                            RatingId = 5,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit,",
                            UserId = "81bc8d48-5325-4e15-ba85-a882b44af87a"
                        },
                        new
                        {
                            Id = 13,
                            CreationDate = new DateTime(2024, 9, 18, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7284),
                            Grade = 4,
                            ProductId = new Guid("e131f5a9-fe96-4e6a-8124-520056ba2060"),
                            RatingId = 6,
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing eli",
                            UserId = "3012882b-354a-4306-9f20-ec2f3f55922e"
                        },
                        new
                        {
                            Id = 14,
                            CreationDate = new DateTime(2024, 9, 6, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7303),
                            Grade = 3,
                            ProductId = new Guid("983c1d4e-0bf3-4070-bd5f-9e1273f9ca6a"),
                            RatingId = 6,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing",
                            UserId = "b0f08e90-3918-4856-80ed-04206eccb912"
                        },
                        new
                        {
                            Id = 15,
                            CreationDate = new DateTime(2024, 9, 26, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7323),
                            Grade = 1,
                            ProductId = new Guid("b141f699-6cc4-49b2-9982-49d07d9cbd52"),
                            RatingId = 6,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet,",
                            UserId = "a9d00c3e-6ccb-40cf-b626-9f4a669695d2"
                        },
                        new
                        {
                            Id = 16,
                            CreationDate = new DateTime(2024, 9, 7, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7341),
                            Grade = 5,
                            ProductId = new Guid("2e9d973e-efd2-41f2-9e8d-56a84350d64d"),
                            RatingId = 7,
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do ei",
                            UserId = "12c57af2-065e-4795-bd9a-78c5edd23f2a"
                        },
                        new
                        {
                            Id = 17,
                            CreationDate = new DateTime(2024, 9, 21, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7365),
                            Grade = 1,
                            ProductId = new Guid("af0e199c-0535-47a9-a93a-9f0b16baf59b"),
                            RatingId = 7,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ",
                            UserId = "908e36d6-748c-4210-b174-b0f3ab6626d2"
                        },
                        new
                        {
                            Id = 18,
                            CreationDate = new DateTime(2024, 11, 8, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7383),
                            Grade = 4,
                            ProductId = new Guid("b09728c0-e44a-4e3c-b9d7-fcdca97e8e2b"),
                            RatingId = 7,
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor i",
                            UserId = "bcd47fa8-71e9-4a72-aed6-a4a8880ee309"
                        },
                        new
                        {
                            Id = 19,
                            CreationDate = new DateTime(2024, 9, 6, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7408),
                            Grade = 1,
                            ProductId = new Guid("66c430ed-09e6-4535-aca2-67f9c9c0a614"),
                            RatingId = 7,
                            Status = 1,
                            Text = "Lorem ipsum dolor sit a",
                            UserId = "77c14ff2-1827-40b6-aa23-bd565be3d323"
                        },
                        new
                        {
                            Id = 20,
                            CreationDate = new DateTime(2024, 9, 15, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7426),
                            Grade = 4,
                            ProductId = new Guid("1e781af9-250c-4b85-b2bc-a4dbb1d44a40"),
                            RatingId = 7,
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit,",
                            UserId = "67e9e89f-affa-42fa-9709-8bc800005672"
                        },
                        new
                        {
                            Id = 21,
                            CreationDate = new DateTime(2024, 11, 21, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7450),
                            Grade = 0,
                            ProductId = new Guid("d33479bb-3aa5-4957-8315-b58243608acd"),
                            RatingId = 7,
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temp",
                            UserId = "ec9f6377-218c-4904-8ce0-720eca77f243"
                        },
                        new
                        {
                            Id = 22,
                            CreationDate = new DateTime(2024, 11, 1, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7469),
                            Grade = 0,
                            ProductId = new Guid("b78f2641-3616-431c-b83a-f9d4b96cc34e"),
                            RatingId = 7,
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur",
                            UserId = "de36b4f2-7380-4dd2-b41b-d393c64f4ee8"
                        },
                        new
                        {
                            Id = 23,
                            CreationDate = new DateTime(2024, 12, 2, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7488),
                            Grade = 2,
                            ProductId = new Guid("a8a072b7-45cf-496b-89a0-ab2373076e00"),
                            RatingId = 8,
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consect",
                            UserId = "e38b030c-b87f-44c6-a6e4-c70d51ab7387"
                        },
                        new
                        {
                            Id = 24,
                            CreationDate = new DateTime(2024, 9, 18, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7507),
                            Grade = 5,
                            ProductId = new Guid("9c12b47f-1ec0-432c-9ade-1e9ee4e4b234"),
                            RatingId = 8,
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, cons",
                            UserId = "03dc5f0a-9eb3-415a-8f09-968faf093fa2"
                        },
                        new
                        {
                            Id = 25,
                            CreationDate = new DateTime(2024, 10, 2, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7530),
                            Grade = 5,
                            ProductId = new Guid("cc7db11f-a52e-4386-aa2a-28f565286775"),
                            RatingId = 8,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisic",
                            UserId = "1af7dc8e-34c7-413c-8e1b-be9067933290"
                        },
                        new
                        {
                            Id = 26,
                            CreationDate = new DateTime(2024, 9, 8, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7549),
                            Grade = 4,
                            ProductId = new Guid("380106dc-3aff-4b00-a221-fb321c33684e"),
                            RatingId = 8,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet, consectet",
                            UserId = "f833c8b9-adad-456b-a639-a20e93794ee1"
                        },
                        new
                        {
                            Id = 27,
                            CreationDate = new DateTime(2024, 10, 12, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7568),
                            Grade = 1,
                            ProductId = new Guid("a5c2d3a9-2cf5-4391-a920-5e7d6c7603c5"),
                            RatingId = 8,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet, ",
                            UserId = "eb185533-b1c7-418f-91f5-90f0f2dac655"
                        },
                        new
                        {
                            Id = 28,
                            CreationDate = new DateTime(2024, 10, 1, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7587),
                            Grade = 3,
                            ProductId = new Guid("e557fa60-1767-4357-a267-6d8c898fed13"),
                            RatingId = 8,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidi",
                            UserId = "1cd8314e-8c8f-4168-8efb-02657de58fee"
                        },
                        new
                        {
                            Id = 29,
                            CreationDate = new DateTime(2024, 10, 11, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7615),
                            Grade = 5,
                            ProductId = new Guid("a1549e4e-ca85-4fa0-a6fb-c225f752718a"),
                            RatingId = 8,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, ",
                            UserId = "3742c2d1-d743-4496-837e-1e3eb3b4d5d5"
                        },
                        new
                        {
                            Id = 30,
                            CreationDate = new DateTime(2024, 10, 1, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7634),
                            Grade = 2,
                            ProductId = new Guid("233e07c3-8c91-4ed1-8ee1-3bd85aa83777"),
                            RatingId = 8,
                            Status = 0,
                            Text = "Lorem ipsum dolor sit ame",
                            UserId = "5ca7b7b0-8822-49e8-bd84-6fa2411a4e61"
                        },
                        new
                        {
                            Id = 31,
                            CreationDate = new DateTime(2024, 9, 18, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7686),
                            Grade = 1,
                            ProductId = new Guid("05fe73da-6ae1-452a-a911-1250290bf45f"),
                            RatingId = 8,
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, conse",
                            UserId = "6352e190-0dca-4565-aad2-7df2c0368e93"
                        },
                        new
                        {
                            Id = 32,
                            CreationDate = new DateTime(2024, 11, 15, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7710),
                            Grade = 5,
                            ProductId = new Guid("163662b1-22ef-4a8c-866d-edc509325405"),
                            RatingId = 8,
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, con",
                            UserId = "de9c2f89-ff43-4452-9b90-89ebca3d0529"
                        },
                        new
                        {
                            Id = 33,
                            CreationDate = new DateTime(2024, 11, 8, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7729),
                            Grade = 4,
                            ProductId = new Guid("619238df-47bb-470c-9b64-10b4adc66733"),
                            RatingId = 9,
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipis",
                            UserId = "1e40677d-8709-4491-be72-7f0014e37adf"
                        },
                        new
                        {
                            Id = 34,
                            CreationDate = new DateTime(2024, 9, 11, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7753),
                            Grade = 2,
                            ProductId = new Guid("82faf50d-e506-4a71-94c6-ef72c81c2cd6"),
                            RatingId = 10,
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temp",
                            UserId = "a7614fbb-6d9c-424a-b933-1aeae2a72223"
                        },
                        new
                        {
                            Id = 35,
                            CreationDate = new DateTime(2024, 12, 2, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7771),
                            Grade = 1,
                            ProductId = new Guid("ba79cb00-cb76-4986-99c2-f2ab24294ff8"),
                            RatingId = 10,
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adi",
                            UserId = "46ccc73b-b13d-4d3d-bf56-30cbd63babd3"
                        },
                        new
                        {
                            Id = 36,
                            CreationDate = new DateTime(2024, 11, 23, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7790),
                            Grade = 1,
                            ProductId = new Guid("f6e613c7-4f48-4a89-95b2-5dee5caaf678"),
                            RatingId = 10,
                            Status = 0,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipisic",
                            UserId = "5d053f25-6e73-47b5-8a37-5fe5a7ac5ed1"
                        },
                        new
                        {
                            Id = 37,
                            CreationDate = new DateTime(2024, 11, 28, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7814),
                            Grade = 0,
                            ProductId = new Guid("39cf447f-5f72-487f-84eb-4490025ee8f5"),
                            RatingId = 10,
                            Status = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipis",
                            UserId = "8f4468e2-a501-416d-9a69-9eb560f034a5"
                        },
                        new
                        {
                            Id = 38,
                            CreationDate = new DateTime(2024, 10, 24, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7833),
                            Grade = 1,
                            ProductId = new Guid("96e1c8d6-7383-483a-b451-d7caaf6ba57a"),
                            RatingId = 10,
                            Status = 2,
                            Text = "Lorem ipsum dolor sit amet, con",
                            UserId = "36690a1a-f421-4b9e-9657-5a7a5fa6fec8"
                        });
                });

            modelBuilder.Entity("Reviews.Domain.Models.Review", b =>
                {
                    b.HasOne("Reviews.Domain.Models.Rating", "Rating")
                        .WithMany("Reviews")
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("Reviews.Domain.Models.Rating", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
