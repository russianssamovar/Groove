﻿// <auto-generated />
using System;
using DBRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBRepository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20190301083058_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommonModels.Entity.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessToken");

                    b.Property<long>("OwnerId");

                    b.Property<byte>("Type");

                    b.Property<string>("Url");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CommonModels.Entity.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccountId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("CommonModels.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CommonModels.Entity.Account", b =>
                {
                    b.HasOne("CommonModels.Entity.User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CommonModels.Entity.Group", b =>
                {
                    b.HasOne("CommonModels.Entity.Account")
                        .WithMany("Groups")
                        .HasForeignKey("AccountId");
                });
#pragma warning restore 612, 618
        }
    }
}