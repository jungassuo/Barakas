﻿// <auto-generated />
using Barakas.Services.RoomAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Barakas.Services.RoomAPI.Migrations
{
    [DbContext(typeof(AddDbContext))]
    partial class AddDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.7.23375.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Barakas.Services.RoomAPI.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FreeBedsAmmount")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            Condition = "Good",
                            FreeBedsAmmount = 1,
                            IsActive = true,
                            Name = "405"
                        },
                        new
                        {
                            RoomId = 2,
                            Condition = "Good",
                            FreeBedsAmmount = 1,
                            IsActive = true,
                            Name = "406"
                        },
                        new
                        {
                            RoomId = 3,
                            Condition = "Good",
                            FreeBedsAmmount = 1,
                            IsActive = true,
                            Name = "407"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
