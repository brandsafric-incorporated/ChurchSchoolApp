﻿// <auto-generated />
using ChurchSchool.Domain.Enum;
using ChurchSchool.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ChurchSchool.Repository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20180526184245_ConfiguringCourseDocs")]
    partial class ConfiguringCourseDocs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChurchSchool.Domain.Entities.ConfigurationCurriculum", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ConfigurationId");

                    b.Property<Guid>("CurriculumId");

                    b.Property<DateTime?>("FinishDate");

                    b.Property<DateTime>("InsertedDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsCurrentConfiguration");

                    b.Property<DateTime?>("RemovedDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationId");

                    b.HasIndex("CurriculumId");

                    b.ToTable("ConfigurationCurriculum");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Course", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.CourseConfiguration", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("CourseId");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsCurrentConfiguration");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.CourseDocuments", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("CourseConfigurationId");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsRequired");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Type");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CourseConfigurationId");

                    b.ToTable("CourseDocuments");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Curriculum", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Curriculums");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.ConfigurationCurriculum", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.CourseConfiguration", "Configuration")
                        .WithMany("ConfigCurriculumns")
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChurchSchool.Domain.Entities.Curriculum", "Curriculum")
                        .WithMany("ConfigCurriculumns")
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.CourseConfiguration", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Course", "RelatedCourse")
                        .WithOne("CurrentConfiguration")
                        .HasForeignKey("ChurchSchool.Domain.Entities.CourseConfiguration", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.CourseDocuments", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.CourseConfiguration")
                        .WithMany("EnrollDocuments")
                        .HasForeignKey("CourseConfigurationId");
                });
#pragma warning restore 612, 618
        }
    }
}
