using ChurchSchool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace ChurchSchool.Repository
{
    public partial class RepositoryContext : DbContext
    {
        #region Properties

        public static readonly LoggerFactory DbConsoleFactory = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((category, level)=> category == DbLoggerCategory.Database.Command.Name &&
                                                          level == LogLevel.Information,true)
        });

        private static string SqlServerConnectionString = @"Data Source=(local)\HOME_XPS;Integrated Security=False;User ID=sa;Password=#gt512M4a1;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #endregion
        #region DbSets
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ScholarTerm> ScholarTerms { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<GradeHistory> GradeHistory { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseClass> Classes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<Professor> Professors { get; set; }
        #endregion

        #region Overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLoggerFactory(DbConsoleFactory)
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(SqlServerConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseClass_Subject>()
                        .HasKey(k => new { k.CourseClassId, k.SubjectId, k.ProfessorId });

            modelBuilder.Entity<CourseClass_Student>()
                        .HasKey(k => new { k.CourseClassId, k.EnrolledStudentId });

            modelBuilder.Entity<Curriculum_Subject>()
                        .HasKey(k => new { k.CurriculumId, k.SubjectId });
        }

        #endregion  
    }
}
