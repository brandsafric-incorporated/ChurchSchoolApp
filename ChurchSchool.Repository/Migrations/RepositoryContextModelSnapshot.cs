﻿// <auto-generated />
using System;
using ChurchSchool.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChurchSchool.Repository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Address", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("AddressTypeId");

                    b.Property<int>("CityId");

                    b.Property<string>("Details")
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("PersonId");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.ConfigurationCurriculum", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("ConfigurationId");

                    b.Property<Guid>("CurriculumId");

                    b.Property<DateTime?>("FinishDate");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsCurrentConfiguration");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

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

                    b.Property<bool>("isActive");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.CourseClass", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ClassName");

                    b.Property<Guid>("Curriculum_SubjectId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("ProfessorId");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Curriculum_SubjectId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.CourseClass_Student", b =>
                {
                    b.Property<Guid>("CourseClassId");

                    b.Property<Guid>("StudentId");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("CourseClassId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseClass_Student");
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

                    b.Property<Guid>("CourseConfigurationId");

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

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Curriculum_Subject", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("CurriculumId");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("SubjectId");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Curriculum_Subject");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Email", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("PersonId");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Frequency", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("InsertedDate");

                    b.Property<Guid>("ProfessorId");

                    b.Property<DateTime?>("RemovedDate");

                    b.Property<Guid>("StudentId");

                    b.Property<Guid>("SubjectId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Frequencies");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Grade", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("InsertedDate");

                    b.Property<DateTime?>("RemovedDate");

                    b.Property<Guid?>("SubjectId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.GradeHistory", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CurrentGradeId");

                    b.Property<DateTime>("InsertedDate");

                    b.Property<DateTime?>("RemovedDate");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CurrentGradeId");

                    b.ToTable("GradeHistory");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Person", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("varchar(MAX)");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Sex");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.PersonDocument", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("IssuingDate")
                        .HasColumnType("datetime");

                    b.Property<string>("IssuingEntity")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<Guid>("PersonId");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonDocuments");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Professor", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("EnrollmentID");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("PersonId");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.ProfessorSubject", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("ProfessorId");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("SubjectId");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("SubjectId");

                    b.ToTable("ProfessorSubject");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Student", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("CourseId");

                    b.Property<DateTime?>("EnrollmentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("EnrollmentID")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("PersonId");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("PersonId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.StudentDocument", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("IssuingDate")
                        .HasColumnType("datetime");

                    b.Property<string>("IssuingEntity")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("StudentId");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentDocuments");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Subject", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

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

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Structs.Phone", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaCode")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<DateTime>("InsertedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<Guid>("PersonId");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Address", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Person")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("ChurchSchool.Domain.Entities.CourseClass", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Curriculum_Subject", "Curriculum_Subject")
                        .WithMany()
                        .HasForeignKey("Curriculum_SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChurchSchool.Domain.Entities.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.CourseClass_Student", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.CourseClass", "RelatedClass")
                        .WithMany()
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChurchSchool.Domain.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
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
                        .HasForeignKey("CourseConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Curriculum_Subject", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Curriculum", "Curriculum")
                        .WithMany()
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChurchSchool.Domain.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Email", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Person", "Person")
                        .WithOne("Email")
                        .HasForeignKey("ChurchSchool.Domain.Entities.Email", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Frequency", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChurchSchool.Domain.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChurchSchool.Domain.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Grade", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.GradeHistory", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Grade", "CurrentGrade")
                        .WithMany("History")
                        .HasForeignKey("CurrentGradeId");
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.PersonDocument", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Person", "Person")
                        .WithMany("Documents")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Professor", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.ProfessorSubject", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Professor", "Professor")
                        .WithMany("RelatedSubjects")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChurchSchool.Domain.Entities.Subject", "Subject")
                        .WithMany("RelatedProfessors")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.Student", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChurchSchool.Domain.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChurchSchool.Domain.Entities.StudentDocument", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Student", "Student")
                        .WithMany("Documents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChurchSchool.Domain.Structs.Phone", b =>
                {
                    b.HasOne("ChurchSchool.Domain.Entities.Person")
                        .WithMany("Phones")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
