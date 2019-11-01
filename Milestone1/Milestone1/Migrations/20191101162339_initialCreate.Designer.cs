﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Milestone1.Data;

namespace Milestone1.Migrations
{
    [DbContext(typeof(FitnessClubContext))]
    [Migration("20191101162339_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("Milestone1.Models.Coach", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("tel")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Coaches");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            name = "Tony",
                            tel = "+13625623"
                        },
                        new
                        {
                            id = 2L,
                            name = "Mike",
                            tel = "+73473827"
                        });
                });

            modelBuilder.Entity("Milestone1.Models.Course", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("coachId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<long>("roomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("coachId")
                        .IsUnique();

                    b.HasIndex("roomId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            coachId = 2L,
                            name = "Yoga",
                            roomId = 2L
                        },
                        new
                        {
                            id = 2L,
                            coachId = 1L,
                            name = "Upper Body Workout",
                            roomId = 1L
                        });
                });

            modelBuilder.Entity("Milestone1.Models.Equipment", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int>("price")
                        .HasColumnType("INTEGER");

                    b.Property<long>("roomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("roomId");

                    b.ToTable("Equipments");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            name = "Yoga ball",
                            price = 2000,
                            roomId = 2L
                        },
                        new
                        {
                            id = 2L,
                            name = "Dumbell",
                            price = 5000,
                            roomId = 1L
                        });
                });

            modelBuilder.Entity("Milestone1.Models.Member", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("telephone")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            name = "Yedil",
                            telephone = "+77771234567"
                        },
                        new
                        {
                            id = 2L,
                            name = "Lisa",
                            telephone = "+21233523343"
                        });
                });

            modelBuilder.Entity("Milestone1.Models.MembershipCard", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("createdAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<long>("memberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("memberId")
                        .IsUnique();

                    b.ToTable("MembershipCards");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            createdAt = new DateTime(2019, 11, 1, 22, 23, 38, 948, DateTimeKind.Local).AddTicks(5020),
                            memberId = 1L
                        },
                        new
                        {
                            id = 2L,
                            createdAt = new DateTime(2019, 11, 1, 22, 23, 38, 960, DateTimeKind.Local).AddTicks(4380),
                            memberId = 2L
                        });
                });

            modelBuilder.Entity("Milestone1.Models.Room", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("capcity")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            capcity = 20
                        },
                        new
                        {
                            id = 2L,
                            capcity = 30
                        });
                });

            modelBuilder.Entity("Milestone1.Models.Schedule", b =>
                {
                    b.Property<long>("courseId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("memberId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("day")
                        .HasColumnType("INTEGER");

                    b.HasKey("courseId", "memberId");

                    b.HasIndex("memberId");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            courseId = 2L,
                            memberId = 1L,
                            day = 1
                        },
                        new
                        {
                            courseId = 1L,
                            memberId = 2L,
                            day = 4
                        });
                });

            modelBuilder.Entity("Milestone1.Models.Course", b =>
                {
                    b.HasOne("Milestone1.Models.Coach", "coach")
                        .WithOne("program")
                        .HasForeignKey("Milestone1.Models.Course", "coachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Milestone1.Models.Room", "room")
                        .WithMany("courses")
                        .HasForeignKey("roomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Milestone1.Models.Equipment", b =>
                {
                    b.HasOne("Milestone1.Models.Room", "room")
                        .WithMany("equipments")
                        .HasForeignKey("roomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Milestone1.Models.MembershipCard", b =>
                {
                    b.HasOne("Milestone1.Models.Member", "member")
                        .WithOne("membershipCard")
                        .HasForeignKey("Milestone1.Models.MembershipCard", "memberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Milestone1.Models.Schedule", b =>
                {
                    b.HasOne("Milestone1.Models.Course", "course")
                        .WithMany("schedules")
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Milestone1.Models.Member", "member")
                        .WithMany("schedules")
                        .HasForeignKey("memberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
