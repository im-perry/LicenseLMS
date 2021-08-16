﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using groupsapi;

namespace groupsapi.Migrations
{
    [DbContext(typeof(GroupsContext))]
    [Migration("20210815133025_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroupsAPI.Models.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialisationId")
                        .HasColumnType("int");

                    b.Property<Guid?>("SpecialisationId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.HasIndex("SpecialisationId1");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("GroupsAPI.Models.Specialisation", b =>
                {
                    b.Property<Guid>("SpecialisationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecialisationId");

                    b.ToTable("Specialisations");
                });

            modelBuilder.Entity("GroupsAPI.Models.Subgroup", b =>
                {
                    b.Property<Guid>("SubgroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubgroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("Subgroups");
                });

            modelBuilder.Entity("GroupsAPI.Models.Group", b =>
                {
                    b.HasOne("GroupsAPI.Models.Specialisation", "Specialisation")
                        .WithMany()
                        .HasForeignKey("SpecialisationId1");

                    b.Navigation("Specialisation");
                });

            modelBuilder.Entity("GroupsAPI.Models.Subgroup", b =>
                {
                    b.HasOne("GroupsAPI.Models.Group", "Group")
                        .WithMany("Subgroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("GroupsAPI.Models.Group", b =>
                {
                    b.Navigation("Subgroups");
                });
#pragma warning restore 612, 618
        }
    }
}