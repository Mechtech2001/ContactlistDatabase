﻿// <auto-generated />
using ContactlistDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactlistDatabase.Migrations
{
    [DbContext(typeof(ContactsContext))]
    [Migration("20240831171329_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContactlistDatabase.Models.Contacts", b =>
                {
                    b.Property<int>("ContactsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactsId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactsId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactsId = 1,
                            Address = "6924 Chaffee Rd.",
                            Name = "Tommy Wells",
                            Note = "CIS 174 student",
                            PhoneNumber = "515-350-9070"
                        },
                        new
                        {
                            ContactsId = 2,
                            Address = "6924 Chaffee Rd.",
                            Name = "Amanda Christie",
                            Note = "N/A",
                            PhoneNumber = "515-657-0416"
                        },
                        new
                        {
                            ContactsId = 3,
                            Address = "1234 University Dr.",
                            Name = "Billy Bob",
                            Note = "He's just a guy",
                            PhoneNumber = "515-555-5555"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
