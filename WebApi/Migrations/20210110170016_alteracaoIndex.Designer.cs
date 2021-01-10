﻿// <auto-generated />
using System;
using Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210110170016_alteracaoIndex")]
    partial class alteracaoIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.PasswordChangeRegistry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UPR_CD_ID")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Expiration")
                        .HasColumnName("UPR_DT_DATA")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .HasColumnName("UPR_TX_PASSWORD")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Token")
                        .HasColumnName("UPR_TX_TOKEN")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("User_Id")
                        .HasColumnName("USER_CD_ID")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("User_Id");

                    b.ToTable("USER_PASSWORD_REGISTRY");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("USER_CD_ID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Cellphone")
                        .HasColumnName("USER_NM_CELLPHONE")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnName("USER_TX_EMAIL")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnName("USER_TX_NAME")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnName("USER_TX_PASSWORD")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .HasColumnName("USER_TX_USERNAME")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("USER");
                });

            modelBuilder.Entity("Entities.PasswordChangeRegistry", b =>
                {
                    b.HasOne("Entities.User", "User")
                        .WithMany("UserPasswordRegistry")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}