﻿// <auto-generated />
using System;
using LeagueOfPlots.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LeagueOfPlots.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210801180330_Commit")]
    partial class Commit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("LeagueOfPlots.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("Avatar")
                        .HasColumnName("AVATAR")
                        .HasColumnType("bytea");

                    b.Property<DateTime>("BirthDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BIRTHDATE")
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("CONCURRENCY_STAMP")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnName("EMAIL")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Facebook")
                        .HasColumnName("FACEBOOK")
                        .HasColumnType("text");

                    b.Property<int>("FauxFrerotPoints")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FAUX_FREROT_POINTS")
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FIRSTNAME")
                        .HasColumnType("text");

                    b.Property<string>("Instagram")
                        .HasColumnName("INSTAGRAM")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LASTNAME")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnName("NORMALIZED_USERNAME")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("PASSWORD_HASH")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("SECURITY_STAMP")
                        .HasColumnType("text");

                    b.Property<string>("Twitter")
                        .HasColumnName("TWITTER")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnName("USERNAME")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LeagueOfPlots.Models.Gallery.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ALB_ID")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AuthorUsername")
                        .IsRequired()
                        .HasColumnName("ALB_AUTHOR_USERNAME")
                        .HasColumnType("text");

                    b.Property<int?>("CoverPhotoId")
                        .HasColumnName("PHT_ID")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("ALB_NAME")
                        .HasColumnType("text");

                    b.Property<int>("PhotoCount")
                        .HasColumnName("ALB_PHOTO_COUNT")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CoverPhotoId")
                        .IsUnique();

                    b.ToTable("Album");
                });

            modelBuilder.Entity("LeagueOfPlots.Models.Gallery.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PHT_ID")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AlbumId")
                        .HasColumnName("ALB_ID")
                        .HasColumnType("integer");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnName("PHT_EXTENSION")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("PHT_NAME")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("LeagueOfPlots.Models.Gallery.PhotoContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PHT_ID")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnName("PHT_CONTENT")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("LeagueOfPlots.Models.RegistrationModel", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnName("KEY")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FIRSTNAME")
                        .HasColumnType("text");

                    b.Property<bool>("IsRegister")
                        .HasColumnName("IS_REGISTER")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LASTNAME")
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.ToTable("REGISTRATION");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LeagueOfPlots.Models.Gallery.Album", b =>
                {
                    b.HasOne("LeagueOfPlots.Models.Gallery.Photo", "CoverPhoto")
                        .WithOne()
                        .HasForeignKey("LeagueOfPlots.Models.Gallery.Album", "CoverPhotoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LeagueOfPlots.Models.Gallery.Photo", b =>
                {
                    b.HasOne("LeagueOfPlots.Models.Gallery.Album", "Album")
                        .WithMany("Photos")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeagueOfPlots.Models.Gallery.PhotoContent", b =>
                {
                    b.HasOne("LeagueOfPlots.Models.Gallery.Photo", null)
                        .WithOne("Content")
                        .HasForeignKey("LeagueOfPlots.Models.Gallery.PhotoContent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("LeagueOfPlots.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("LeagueOfPlots.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeagueOfPlots.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("LeagueOfPlots.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
