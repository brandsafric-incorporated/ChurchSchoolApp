using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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

        #endregion

        #region Constructors

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        #endregion

        #region DbSets

        public DbSet<Domain.Entities.ConfigurationCurriculum> ConfigurationCurriculum { get; set; }
        public DbSet<Domain.Entities.Person> People { get; set; }
        public DbSet<Domain.Entities.Address> Addresses { get; set; }
        public DbSet<Domain.Entities.Student> Students { get; set; }
        public DbSet<Domain.Entities.Email> Emails { get; set; }
        public DbSet<Domain.Entities.StudentDocument> StudentDocuments { get; set; }
        public DbSet<Domain.Entities.PersonDocument> PersonDocuments { get; set; }
        public DbSet<Domain.Entities.Course> Courses { get; set; }
        public DbSet<Domain.Entities.CourseConfiguration> Configurations { get; set; }
        public DbSet<Domain.Entities.Curriculum> Curriculums { get; set; }
        public DbSet<Domain.Entities.CourseDocuments> CourseDocuments { get; set; }
        public DbSet<Domain.Entities.Subject> Subjects { get; set; }
        public DbSet<Domain.Entities.Professor> Professors { get; set; }
        public DbSet<Domain.Entities.CourseClass> Classes { get; set; }
        public DbSet<Domain.Entities.Grade> Grades { get; set; }
        public DbSet<Domain.Entities.GradeHistory> GradeHistory { get; set; }
        public DbSet<Domain.Entities.Frequency> Frequencies { get; set; }
        public DbSet<Domain.Entities.Curriculum_Subject> Curriculum_Subject { get; set; }
        public DbSet<Domain.Entities.CourseClass_Student> CourseClass_Student { get; set; }
        public DbSet<Domain.Entities.ProfessorSubject> ProfessorSubject { get; set; }
        public DbSet<Domain.Entities.Course_Subject> Course_Subject { get; set; }


        /*  
            //Disabled Entities
            public DbSet<Domain.Entities.Enrollment> Enrollments { get; set; }
            public DbSet<Domain.Entities.ScholarTerm> ScholarTerms { get; set; }
        */
        #endregion

        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ModelSettings.Student().Configure(modelBuilder);
            new ModelSettings.Person().Configure(modelBuilder);
            new ModelSettings.StudentDocument().Configure(modelBuilder);
            new ModelSettings.Address().Configure(modelBuilder);
            new ModelSettings.Email().Configure(modelBuilder);
            new ModelSettings.Phone().Configure(modelBuilder);
            new ModelSettings.Course().Configure(modelBuilder);
            new ModelSettings.CourseConfiguration().Configure(modelBuilder);
            new ModelSettings.Curriculum().Configure(modelBuilder);
            new ModelSettings.CourseDocuments().Configure(modelBuilder);
            new ModelSettings.Subject().Configure(modelBuilder);
            new ModelSettings.Professor().Configure(modelBuilder);
            new ModelSettings.Professor_Subject().Configure(modelBuilder);
            new ModelSettings.CourseClass().Configure(modelBuilder);
            new ModelSettings.CourseClass_Student().Configure(modelBuilder);
            new ModelSettings.Professor_Subject().Configure(modelBuilder);
            new ModelSettings.Curriculum_Subject().Configure(modelBuilder);
            new ModelSettings.Course_Subject().Configure(modelBuilder);
            new ModelSettings.ConfigurationCurriculum().Configure(modelBuilder);
        }

        #endregion
    }


    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            builder.UseSqlServer("Data Source=(local)\\SERVER_XPS;Initial Catalog=DB_SEMINARIO;Integrated Security=True");
            return new RepositoryContext(builder.Options);
        }
    }

  
}