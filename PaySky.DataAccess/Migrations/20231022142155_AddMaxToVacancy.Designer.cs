﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaySky.DataAccess;

#nullable disable

namespace PaySky.DataAccess.Migrations
{
    [DbContext(typeof(PaySkyDBContext))]
    [Migration("20231022142155_AddMaxToVacancy")]
    partial class AddMaxToVacancy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PaySky.Models.ApiModels.Role.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Applicant"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Employer"
                        });
                });

            modelBuilder.Entity("PaySky.Models.ApiModels.UserEntity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("roleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PaySky.Models.ApiModels.UserVacancyEntity.UserVacancy", b =>
                {
                    b.Property<int>("VacanyId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("VacanyId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserVacancy");
                });

            modelBuilder.Entity("PaySky.Models.ApiModels.VacancyEntity.Vacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxNumberOfApplicants")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vacancies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 12, 21, 17, 21, 55, 266, DateTimeKind.Local).AddTicks(5733),
                            Description = "Description",
                            ExpiryDate = new DateTime(2023, 12, 21, 17, 21, 55, 266, DateTimeKind.Local).AddTicks(5713),
                            MaxNumberOfApplicants = 0,
                            Title = "First Vacancy"
                        });
                });

            modelBuilder.Entity("PaySky.Models.ApiModels.UserEntity.User", b =>
                {
                    b.HasOne("PaySky.Models.ApiModels.Role.UserRole", "role")
                        .WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");
                });

            modelBuilder.Entity("PaySky.Models.ApiModels.UserVacancyEntity.UserVacancy", b =>
                {
                    b.HasOne("PaySky.Models.ApiModels.UserEntity.User", "User")
                        .WithMany("UserVacancies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaySky.Models.ApiModels.VacancyEntity.Vacancy", "Vacancy")
                        .WithMany("UserVacancies")
                        .HasForeignKey("VacanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("PaySky.Models.ApiModels.UserEntity.User", b =>
                {
                    b.Navigation("UserVacancies");
                });

            modelBuilder.Entity("PaySky.Models.ApiModels.VacancyEntity.Vacancy", b =>
                {
                    b.Navigation("UserVacancies");
                });
#pragma warning restore 612, 618
        }
    }
}
