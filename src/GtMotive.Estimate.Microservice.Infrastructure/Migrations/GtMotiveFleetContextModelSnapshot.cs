﻿// <auto-generated />
using System;
using GtMotive.Estimate.Microservice.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GtMotive.Estimate.Microservice.Infrastructure.Migrations
{
    [DbContext(typeof(GtMotiveFleetContext))]
    partial class GtMotiveFleetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet.Fleet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Fleets", "Rental");
                });

            modelBuilder.Entity("GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FleetId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FleetId");

                    b.ToTable("Vehicles", "Rental");
                });

            modelBuilder.Entity("GtMotive.Estimate.Microservice.Domain.Aggregates.Rental.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Rentals", "Rental");
                });

            modelBuilder.Entity("GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet.Fleet", b =>
                {
                    b.OwnsOne("GtMotive.Estimate.Microservice.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<int>("FleetId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.HasKey("FleetId");

                            b1.ToTable("Fleets");

                            b1.WithOwner()
                                .HasForeignKey("FleetId");
                        });

                    b.Navigation("Name");
                });

            modelBuilder.Entity("GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet.Vehicle", b =>
                {
                    b.HasOne("GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet.Fleet", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("FleetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("GtMotive.Estimate.Microservice.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<int>("VehicleId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.HasKey("VehicleId");

                            b1.ToTable("Vehicles");

                            b1.WithOwner()
                                .HasForeignKey("VehicleId");
                        });

                    b.Navigation("Name");
                });

            modelBuilder.Entity("GtMotive.Estimate.Microservice.Domain.Aggregates.Rental.Rental", b =>
                {
                    b.HasOne("GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet.Fleet", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
