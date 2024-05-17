﻿// <auto-generated />
using System;
using BloodDonorReceiver.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BloodDonorReceiver.DataAccess.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20240517195912_CreateAndEditDonorsProp")]
    partial class CreateAndEditDonorsProp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.BloodCenterModel", b =>
                {
                    b.Property<string>("TeamId")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BloodDonationCenterName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TeamId");

                    b.HasIndex("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("BloodCenters");
                });

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.CityModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.DonorModel", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<string>("Birthday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("BloodType")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCronicIllness")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsUpdated")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Guid");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.ReceiverModel", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<string>("Birthday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("BloodType")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsUpdated")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Guid");

                    b.ToTable("Receivers");
                });

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.StateModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("CityId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.UserModel", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Birthday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsUpdated")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TCNO")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Guid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.BloodCenterModel", b =>
                {
                    b.HasOne("BloodDonorReceiver.Data.Models.CityModel", "City")
                        .WithMany("BloodCenters")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodDonorReceiver.Data.Models.StateModel", "State")
                        .WithMany("BloodCenters")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("State");
                });

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.DonorModel", b =>
                {
                    b.HasOne("BloodDonorReceiver.Data.Models.UserModel", "Users")
                        .WithMany("Donors")
                        .HasForeignKey("Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.ReceiverModel", b =>
                {
                    b.HasOne("BloodDonorReceiver.Data.Models.UserModel", "Users")
                        .WithMany("Receivers")
                        .HasForeignKey("Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.StateModel", b =>
                {
                    b.HasOne("BloodDonorReceiver.Data.Models.CityModel", "City")
                        .WithMany("States")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.CityModel", b =>
                {
                    b.Navigation("BloodCenters");

                    b.Navigation("States");
                });

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.StateModel", b =>
                {
                    b.Navigation("BloodCenters");
                });

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.UserModel", b =>
                {
                    b.Navigation("Donors");

                    b.Navigation("Receivers");
                });
#pragma warning restore 612, 618
        }
    }
}