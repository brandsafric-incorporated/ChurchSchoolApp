using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class CourseClass_Subject : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.CourseClass_Subject>(u =>
            {
                u.HasKey(k => new { k.CourseClassId, k.SubjectId });
                u.Property(x => x.Id).HasDefaultValueSql("NEWID()");
                u.Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
            });

            builder.Entity<Domain.Entities.CourseClass_Subject>().Ignore(q => q.Id);
        }
    }
}
