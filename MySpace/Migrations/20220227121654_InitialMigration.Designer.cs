﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySpace.Models;

namespace MySpace.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220227121654_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MySpace.Entities.ViewModel.MyDayViewModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LocalDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TimeDifferenceInMinutes")
                        .HasColumnType("int");

                    b.Property<DateTime>("UtcDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("WrittenData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Days");
                });
#pragma warning restore 612, 618
        }
    }
}
