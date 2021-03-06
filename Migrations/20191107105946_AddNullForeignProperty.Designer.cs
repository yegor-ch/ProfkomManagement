﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProfkomManagement.Data;

namespace ProfkomManagement.Migrations
{
    [DbContext(typeof(ProfkomDbContext))]
    [Migration("20191107105946_AddNullForeignProperty")]
    partial class AddNullForeignProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProfkomManagement.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("ProfkomManagement.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FacultyId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ProfkomManagement.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfEntry");

                    b.Property<DateTime?>("DateOfExit");

                    b.Property<int?>("FacultyID");

                    b.Property<int?>("GroupId");

                    b.Property<bool>("IsScholarship");

                    b.Property<string>("Name");

                    b.Property<string>("Patronymic");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("FacultyID");

                    b.HasIndex("GroupId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("ProfkomManagement.Models.Group", b =>
                {
                    b.HasOne("ProfkomManagement.Models.Faculty", "Faculty")
                        .WithMany("Groups")
                        .HasForeignKey("FacultyId");
                });

            modelBuilder.Entity("ProfkomManagement.Models.Member", b =>
                {
                    b.HasOne("ProfkomManagement.Models.Faculty", "Faculty")
                        .WithMany("Members")
                        .HasForeignKey("FacultyID");

                    b.HasOne("ProfkomManagement.Models.Group", "Group")
                        .WithMany("Members")
                        .HasForeignKey("GroupId");
                });
#pragma warning restore 612, 618
        }
    }
}
