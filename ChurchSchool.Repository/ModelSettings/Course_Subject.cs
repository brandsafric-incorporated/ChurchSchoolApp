using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    //public class Course_Subject : IModelConfiguration
    //{
    //    public void Configure(ModelBuilder builder)
    //    {
    //        builder.Entity<Domain.Entities.Course_Subject>(u =>
    //        {
    //            u.HasKey(k => k.Id);
    //            u.Property(x => x.Id).UseSqlServerIdentityColumn();
    //            u.Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
    //        });

    //        //builder.Entity<Domain.Entities.Course_Subject>()
    //        //       .HasOne(c => c.CourseConfiguration)
    //        //       .WithMany(t => t.Subjects)
    //        //       .HasForeignKey(d => d.ConfigurationCourseId);

    //        //builder.Entity<Domain.Entities.Course_Subject>()
    //        //       .HasOne(c => c.Subject)
    //        //       .WithMany(t => t.Configurations)
    //        //       .HasForeignKey(d => d.SubjectId);
    //    }
    //}
}
