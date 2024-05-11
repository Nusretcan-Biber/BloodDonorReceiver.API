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
    [Migration("20240511195749_DeletedParametersIsDELETED")]
    partial class DeletedParametersIsDELETED
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.DonorModel", b =>
                {
                    b.HasOne("BloodDonorReceiver.Data.Models.UserModel", "Users")
                        .WithMany("Donors")
                        .HasForeignKey("Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("UserGuid");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BloodDonorReceiver.Data.Models.ReceiverModel", b =>
                {
                    b.HasOne("BloodDonorReceiver.Data.Models.UserModel", "Users")
                        .WithMany("Receivers")
                        .HasForeignKey("Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("UserGuid");

                    b.Navigation("Users");
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
