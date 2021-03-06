// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportyApi.Models;

namespace SportyApi.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20220307144131_SeedsSomeFootballProducts")]
    partial class SeedsSomeFootballProducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.Level", b =>
                {
                    b.Property<Guid>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("SportId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LevelId");

                    b.HasIndex("SportId");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.OrderItem", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<double>("TotalItemPrice")
                        .HasColumnType("float");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionMinimized")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("SportId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId");

                    b.HasIndex("SportId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("70431068-33cf-4e6e-b49b-499e553d34c1"),
                            Brand = "adidas",
                            Description = "Now with 360° coverage of DEMONSKIN rubber spikes, deliberately positioned to align with key ball - contact points, enabling superior control and increased ball swerve.Informed by elite player feedback, adidas updated the Predator design by creating an enhanced fit and extending the coverage of Demonskin rubber spikes for extraordinary ball control.",
                            DescriptionMinimized = "A CONTROL FREAK - the new adidas Predator Freak is the most aggressive - looking cleat in the game.",
                            ImageUrl = "Products/Football/AdidasPredatorFreakSoccerCleat.jpg",
                            Name = "Predator Freak + FG Firm Ground Soccer Cleat",
                            Price = 234.99000000000001,
                            Quantity = 150,
                            SportId = new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed")
                        },
                        new
                        {
                            ProductId = new Guid("277d46c2-8f29-491d-aa39-81df68968553"),
                            Brand = "adidas",
                            Description = "adidas Predator gloves turn any goalkeeper into a shot-stopping beast! Play with the confidence that you're competing in a superior set of gloves from a great soccer brand.Can be worn for both match and training, on all surfaces,in all conditions.",
                            DescriptionMinimized = "adidas Predator gloves turn any goalkeeper into a shot - stopping beast.",
                            ImageUrl = "Products/Football/adidasPredatorGoalKeeperGloves.jpg",
                            Name = "Predator Pro Ultimate Goalkeeper Gloves",
                            Price = 179.99000000000001,
                            Quantity = 150,
                            SportId = new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed")
                        },
                        new
                        {
                            ProductId = new Guid("ec043374-747d-4188-9f15-0c41a65258a9"),
                            Brand = "adidas",
                            Description = "The Pro is the official on-field match ball for the 2022 Champions League finale.UCL details, Textured surface, Thermally bonded seamless construction, 100 % Polyurethane, Butyl bladder, and Meets FIFA Quality Pro Standards.",
                            DescriptionMinimized = " The Pro is the official on-field match ball for the 2022 Champions League finale.",
                            ImageUrl = "Products/Football/adidasUCLChampionsLeagueBall.jpg",
                            Name = "UCL Champions League Pro Soccer Ball",
                            Price = 164.99000000000001,
                            Quantity = 150,
                            SportId = new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed")
                        },
                        new
                        {
                            ProductId = new Guid("e43f48a9-3928-4035-9960-b25e011fa984"),
                            Brand = "adidas",
                            Description = "rawing inspiration from past speed boots, the X 19.1 perfectly blends innovation and technology with the look of pure speed. Some of the fastest players around the world are lacing up in the adidas X, so why aren't you ? A redesigned SpeedMesh upper offers a softer feel around your foot, and a more plush feel on the ball.The upper stays lightweight, offering a second skin - like fit.",
                            DescriptionMinimized = "The X 19.1 is the perfect boot for players looking to show off their speed.",
                            ImageUrl = "Products/Football/adidasX19.1FGSoccerCleats.jpg",
                            Name = "X 19.1 FG Soccer Cleats",
                            Price = 139.99000000000001,
                            Quantity = 150,
                            SportId = new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed")
                        },
                        new
                        {
                            ProductId = new Guid("833dc10f-63a0-4d18-a919-f6f387dbbbdd"),
                            Brand = "Nike",
                            Description = "Full zip training jacket. Ribbed collar, cuffs and waist, Mesh insert, Embroidered swoosh, Dri - FIT technology wicks sweat, and 100 % polyester.",
                            DescriptionMinimized = "Nike Academy 21 Jacket",
                            ImageUrl = "Products/Football/NikeAcademyJacket.jpg",
                            Name = "Academy 21 Jacket",
                            Price = 59.990000000000002,
                            Quantity = 150,
                            SportId = new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed")
                        },
                        new
                        {
                            ProductId = new Guid("ed310637-8a9b-4bdb-ae60-ae10383fad1f"),
                            Brand = "SKLZ",
                            Description = " A shoot and finish trainer that fits regulation size goals. It gives strikers open zones where they statistically are four times more likely to score a goal.Easily attaches to any regulation goal.",
                            DescriptionMinimized = "A shoot and finish trainer that fits regulation size goals",
                            ImageUrl = "Products/Football/SKLZGoalshot.jpg",
                            Name = "SKLZ Goalshot",
                            Price = 299.99000000000001,
                            Quantity = 150,
                            SportId = new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed")
                        });
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.ReservedProgram", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("TrainingProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("UserId", "TrainingProgramId");

                    b.HasIndex("TrainingProgramId");

                    b.ToTable("ReservedPrograms");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.Sport", b =>
                {
                    b.Property<Guid>("SportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SportId");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.TrainingProgram", b =>
                {
                    b.Property<Guid>("TrainingProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionMinimized")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("PricePerMonth")
                        .HasColumnType("float");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("SportId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TrainingProgramId");

                    b.HasIndex("LevelId");

                    b.HasIndex("SportId");

                    b.ToTable("TrainingPrograms");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.UserCreditCard", b =>
                {
                    b.Property<Guid>("CreditCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("ExpirationDate")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CreditCardId");

                    b.HasIndex("UserId");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.UsersInterests", b =>
                {
                    b.Property<Guid>("SportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SportId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersInterests");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SportyApi.Models.Core.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SportyApi.Models.Core.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportyApi.Models.Core.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SportyApi.Models.Core.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.ApplicationUser", b =>
                {
                    b.OwnsOne("SportyApi.Models.Core.Domain.Address", "Address", b1 =>
                        {
                            b1.Property<string>("ApplicationUserId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("BuildingNumber")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Street")
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.HasKey("ApplicationUserId");

                            b1.ToTable("AspNetUsers");

                            b1.WithOwner()
                                .HasForeignKey("ApplicationUserId");
                        });

                    b.OwnsOne("SportyApi.Models.Core.Domain.RefreshToken", "RefreshToken", b1 =>
                        {
                            b1.Property<string>("ApplicationUserId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("CreatedOn")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("ExpiresOn")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Token")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ApplicationUserId");

                            b1.ToTable("AspNetUsers");

                            b1.WithOwner()
                                .HasForeignKey("ApplicationUserId");
                        });

                    b.Navigation("Address");

                    b.Navigation("RefreshToken");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.Level", b =>
                {
                    b.HasOne("SportyApi.Models.Core.Domain.Sport", "Sport")
                        .WithMany("Levels")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.Order", b =>
                {
                    b.HasOne("SportyApi.Models.Core.Domain.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SportyApi.Models.Core.Domain.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("BuildingNumber")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Street")
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("SportyApi.Models.Core.Domain.OrderCreditCard", "CreditCard", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CreditCardNumber")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("nvarchar(25)");

                            b1.Property<string>("ExpirationDate")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("nvarchar(25)");

                            b1.Property<string>("Zipcode")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("nvarchar(15)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("CreditCard")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.OrderItem", b =>
                {
                    b.HasOne("SportyApi.Models.Core.Domain.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportyApi.Models.Core.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.Product", b =>
                {
                    b.HasOne("SportyApi.Models.Core.Domain.Sport", "Sport")
                        .WithMany("Products")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.ReservedProgram", b =>
                {
                    b.HasOne("SportyApi.Models.Core.Domain.TrainingProgram", "TrainingProgram")
                        .WithMany()
                        .HasForeignKey("TrainingProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportyApi.Models.Core.Domain.ApplicationUser", "User")
                        .WithMany("ReservedPrograms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingProgram");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.TrainingProgram", b =>
                {
                    b.HasOne("SportyApi.Models.Core.Domain.Level", "Level")
                        .WithMany("TrainingPrograms")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportyApi.Models.Core.Domain.Sport", "Sport")
                        .WithMany("TrainingPrograms")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.UserCreditCard", b =>
                {
                    b.HasOne("SportyApi.Models.Core.Domain.ApplicationUser", "User")
                        .WithMany("CreditCards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.UsersInterests", b =>
                {
                    b.HasOne("SportyApi.Models.Core.Domain.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportyApi.Models.Core.Domain.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.ApplicationUser", b =>
                {
                    b.Navigation("CreditCards");

                    b.Navigation("Orders");

                    b.Navigation("ReservedPrograms");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.Level", b =>
                {
                    b.Navigation("TrainingPrograms");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("SportyApi.Models.Core.Domain.Sport", b =>
                {
                    b.Navigation("Levels");

                    b.Navigation("Products");

                    b.Navigation("TrainingPrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
