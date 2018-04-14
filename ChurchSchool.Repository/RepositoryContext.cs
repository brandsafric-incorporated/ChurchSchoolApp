using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.ModelSettings;
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
        
        public DbSet<Domain.Entities.Subject> Subjects { get; set; }
        public DbSet<Domain.Entities.Student> Students { get; set; }
        public DbSet<Domain.Entities.ScholarTerm> ScholarTerms { get; set; }
        public DbSet<Domain.Entities.Grade> Grades { get; set; }
        public DbSet<Domain.Entities.GradeHistory> GradeHistory { get; set; }
        public DbSet<Domain.Entities.Frequency> Frequencies { get; set; }
        public DbSet<Domain.Entities.Course> Courses { get; set; }
        public DbSet<Domain.Entities.CourseClass> Classes { get; set; }
        public DbSet<Domain.Entities.Enrollment> Enrollments { get; set; }
        public DbSet<Domain.Entities.Curriculum> Curriculums { get; set; }
        public DbSet<Domain.Entities.Professor> Professors { get; set; }
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


            new ModelSettings.Course().Configure(modelBuilder);

            new ModelSettings.CourseClass().Configure(modelBuilder);

            new ModelSettings.CourseClass_Student().Configure(modelBuilder);

            new ModelSettings.CourseClass_Subject().Configure(modelBuilder);

            new ModelSettings.CourseConfiguration().Configure(modelBuilder);

            new ModelSettings.Curriculum().Configure(modelBuilder);

            new ModelSettings.Curriculum_Subject().Configure(modelBuilder);

            new ModelSettings.Enrollment().Configure(modelBuilder);

            new ModelSettings.Frequency().Configure(modelBuilder);

            new ModelSettings.Grade().Configure(modelBuilder);

            new ModelSettings.GradeHistory().Configure(modelBuilder);

            new ModelSettings.Professor().Configure(modelBuilder);

            new ModelSettings.ScholarTerm().Configure(modelBuilder);

            new ModelSettings.Student().Configure(modelBuilder);

            new ModelSettings.Subject().Configure(modelBuilder);
            
        }

        #endregion  
    }
}
