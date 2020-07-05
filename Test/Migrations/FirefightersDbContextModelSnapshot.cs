﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.Models;

namespace Test.Migrations
{
    [DbContext(typeof(FirefightersDbContext))]
    partial class FirefightersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.6.20312.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Test.Models.Action", b =>
                {
                    b.Property<int>("IdAction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<byte>("NeedSpecialEquipment")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAction");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("Test.Models.FireTruck", b =>
                {
                    b.Property<int>("IdFireTruck")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("SpecialEquipment")
                        .HasColumnType("tinyint");

                    b.Property<string>("TruckNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("IdFireTruck");

                    b.ToTable("FireTrucks");
                });

            modelBuilder.Entity("Test.Models.FireTruckAction", b =>
                {
                    b.Property<int>("IdFireTruckAction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AssignmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdAction")
                        .HasColumnType("int");

                    b.Property<int?>("IdFireTruck")
                        .HasColumnType("int");

                    b.HasKey("IdFireTruckAction");

                    b.HasIndex("IdAction");

                    b.HasIndex("IdFireTruck");

                    b.ToTable("FireTruckActions");
                });

            modelBuilder.Entity("Test.Models.Firefighter", b =>
                {
                    b.Property<int>("IdFirefighter")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdFirefighter");

                    b.ToTable("Firefighters");
                });

            modelBuilder.Entity("Test.Models.FirefighterAction", b =>
                {
                    b.Property<int>("IdFirefighter")
                        .HasColumnType("int");

                    b.Property<int>("IdAction")
                        .HasColumnType("int");

                    b.HasKey("IdFirefighter", "IdAction");

                    b.HasIndex("IdAction");

                    b.ToTable("FirefighterActions");
                });

            modelBuilder.Entity("Test.Models.FireTruckAction", b =>
                {
                    b.HasOne("Test.Models.Action", "Action")
                        .WithMany("FireTruckActions")
                        .HasForeignKey("IdAction");

                    b.HasOne("Test.Models.FireTruck", "FireTruck")
                        .WithMany("FireTruckActions")
                        .HasForeignKey("IdFireTruck");
                });

            modelBuilder.Entity("Test.Models.FirefighterAction", b =>
                {
                    b.HasOne("Test.Models.Action", "Action")
                        .WithMany("FirefighterActions")
                        .HasForeignKey("IdAction")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Models.Firefighter", "Firefighter")
                        .WithMany("FirefighterActions")
                        .HasForeignKey("IdFirefighter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
