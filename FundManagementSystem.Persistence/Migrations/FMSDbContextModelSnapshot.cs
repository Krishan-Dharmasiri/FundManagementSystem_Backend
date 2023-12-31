﻿// <auto-generated />
using System;
using FundManagementSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FundManagementSystem.Persistence.Migrations
{
    [DbContext(typeof(FMSDbContext))]
    partial class FMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FundManagementSystem.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(2023, 12, 4, 11, 50, 12, 550, DateTimeKind.Local).AddTicks(5816),
                            Email = "kush@gmail.com",
                            Name = "Kushi Saranya"
                        });
                });

            modelBuilder.Entity("FundManagementSystem.Domain.Entities.Portfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Portfolios");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                            ClientId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(2023, 12, 4, 11, 50, 12, 550, DateTimeKind.Local).AddTicks(5946),
                            Name = "Portfolio One",
                            StartDate = new DateTime(2023, 12, 4, 11, 50, 12, 550, DateTimeKind.Local).AddTicks(5952),
                            Type = "EQUITY"
                        },
                        new
                        {
                            Id = new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                            ClientId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(2023, 12, 4, 11, 50, 12, 550, DateTimeKind.Local).AddTicks(5964),
                            Name = "Portfolio Two",
                            StartDate = new DateTime(2023, 12, 4, 11, 50, 12, 550, DateTimeKind.Local).AddTicks(5966),
                            Type = "FIXED_INCOME"
                        });
                });

            modelBuilder.Entity("FundManagementSystem.Domain.Entities.Portfolio", b =>
                {
                    b.HasOne("FundManagementSystem.Domain.Entities.Client", "Client")
                        .WithMany("Portfolios")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("FundManagementSystem.Domain.Entities.Client", b =>
                {
                    b.Navigation("Portfolios");
                });
#pragma warning restore 612, 618
        }
    }
}
