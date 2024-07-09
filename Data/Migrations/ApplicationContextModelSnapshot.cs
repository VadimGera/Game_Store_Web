﻿// <auto-generated />
using System;
using GameStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameStore.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GameStore.Models.BuyingGames", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CouponId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GameId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CouponId");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("BuyingGames");
                });

            modelBuilder.Entity("GameStore.Models.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Discount")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("GameStore.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AverageRating")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GameDescription")
                        .HasColumnType("text");

                    b.Property<string>("GameName")
                        .HasColumnType("text");

                    b.Property<decimal>("Privce")
                        .HasColumnType("numeric");

                    b.Property<int>("StudioDevId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudioDevId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameStore.Models.GameReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("GameId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("GameStore.Models.StudioDev", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StudioDevs");
                });

            modelBuilder.Entity("GameStore.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("boolean");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameUser", b =>
                {
                    b.Property<int>("BoughtGamesId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersWhoBoughtGameId")
                        .HasColumnType("integer");

                    b.HasKey("BoughtGamesId", "UsersWhoBoughtGameId");

                    b.HasIndex("UsersWhoBoughtGameId");

                    b.ToTable("GameUser");
                });

            modelBuilder.Entity("GameStore.Models.BuyingGames", b =>
                {
                    b.HasOne("GameStore.Models.Coupon", "Coupon")
                        .WithMany()
                        .HasForeignKey("CouponId");

                    b.HasOne("GameStore.Models.Game", "Game")
                        .WithMany("BuyingGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.Models.User", "User")
                        .WithMany("BuyingGames")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coupon");

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameStore.Models.Game", b =>
                {
                    b.HasOne("GameStore.Models.StudioDev", "StudioDev")
                        .WithMany("Games")
                        .HasForeignKey("StudioDevId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudioDev");
                });

            modelBuilder.Entity("GameStore.Models.GameReview", b =>
                {
                    b.HasOne("GameStore.Models.Game", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameUser", b =>
                {
                    b.HasOne("GameStore.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("BoughtGamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersWhoBoughtGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameStore.Models.Game", b =>
                {
                    b.Navigation("BuyingGames");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("GameStore.Models.StudioDev", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("GameStore.Models.User", b =>
                {
                    b.Navigation("BuyingGames");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
