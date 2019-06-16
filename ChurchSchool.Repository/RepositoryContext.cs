﻿using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using ChurchSchool.Repository.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ChurchSchool.Repository
{
    public class RepositoryContext : DbContext, IDomainTables, IDbContext
    {
        #region Properties

        public static readonly LoggerFactory DbConsoleFactory = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((category, level)=> category == DbLoggerCategory.Database.Command.Name &&
                                                          level == LogLevel.Information,true)
        });

        #endregion

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        #region Db Sets
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<StudentDocument> StudentDocuments { get; set; }
        public DbSet<PersonDocument> PersonDocuments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseConfiguration> Configurations { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<CourseDocument> CourseDocuments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<CourseClass> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<GradeHistory> GradeHistory { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<Curriculum_Subject> Curriculum_Subject { get; set; }
        public DbSet<CourseClass_Student> CourseClass_Student { get; set; }
        public DbSet<ProfessorSubject> ProfessorSubject { get; set; }
        #endregion

        #region Overrides
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelBuilderFactory.ConfigureDomainModels(modelBuilder);
        }
        #endregion


    }
}