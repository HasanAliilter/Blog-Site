﻿// <auto-generated />
using System;
using BlogProject.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogProject.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240509213746_SeedSuccess")]
    partial class SeedSuccess
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlogProject.Entity.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6dceb422-7dcc-4bd3-884e-8e6b5749da76"),
                            CategoryId = new Guid("933b9554-cc1b-4715-97c9-9a1a85db9bc5"),
                            Content = "Lorem ipsum dolor sit amet",
                            CreatedBy = "Admin Hasan",
                            CreatedDate = new DateTime(2024, 5, 10, 0, 37, 46, 86, DateTimeKind.Local).AddTicks(2949),
                            ImageId = new Guid("f91b9913-a95d-4c7c-a204-e1d32a151c72"),
                            IsDeleted = false,
                            Title = "C# Makale",
                            ViewCount = 13
                        },
                        new
                        {
                            Id = new Guid("2bd5469c-b027-4ae0-9bc9-5c317cd4414d"),
                            CategoryId = new Guid("301de9f5-8a72-4738-863e-4104123917f7"),
                            Content = "Lorem ipsum dolor sit amet mxalknclcnaljcnlscnlxclnaslcnaslcnc sql server",
                            CreatedBy = "Admin Hasan",
                            CreatedDate = new DateTime(2024, 5, 10, 0, 37, 46, 86, DateTimeKind.Local).AddTicks(2964),
                            ImageId = new Guid("efedf71d-350e-4869-bfaa-6d0e24f1014d"),
                            IsDeleted = false,
                            Title = "Sql Server Makale",
                            ViewCount = 25
                        });
                });

            modelBuilder.Entity("BlogProject.Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("933b9554-cc1b-4715-97c9-9a1a85db9bc5"),
                            CreatedBy = "Admin Hasan",
                            CreatedDate = new DateTime(2024, 5, 10, 0, 37, 46, 86, DateTimeKind.Local).AddTicks(3906),
                            IsDeleted = false,
                            Name = "C#"
                        },
                        new
                        {
                            Id = new Guid("301de9f5-8a72-4738-863e-4104123917f7"),
                            CreatedBy = "Admin Hasan",
                            CreatedDate = new DateTime(2024, 5, 10, 0, 37, 46, 86, DateTimeKind.Local).AddTicks(3909),
                            IsDeleted = false,
                            Name = "Sql Server"
                        });
                });

            modelBuilder.Entity("BlogProject.Entity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f91b9913-a95d-4c7c-a204-e1d32a151c72"),
                            CreatedBy = "Admin Hasan",
                            CreatedDate = new DateTime(2024, 5, 10, 0, 37, 46, 86, DateTimeKind.Local).AddTicks(5906),
                            FileName = "Images/hasanimage",
                            FileType = "jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("efedf71d-350e-4869-bfaa-6d0e24f1014d"),
                            CreatedBy = "Admin Hasan",
                            CreatedDate = new DateTime(2024, 5, 10, 0, 37, 46, 86, DateTimeKind.Local).AddTicks(5910),
                            FileName = "Images/sqltest",
                            FileType = "jpg",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("BlogProject.Entity.Entities.Article", b =>
                {
                    b.HasOne("BlogProject.Entity.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogProject.Entity.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("BlogProject.Entity.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("BlogProject.Entity.Entities.Image", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}