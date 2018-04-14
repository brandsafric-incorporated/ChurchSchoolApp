using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Frequency : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Frequency>().HasKey(x => new { x.ScholarTermId, x.SubjectId, x.EnrollmentId });
            builder.Entity<Domain.Entities.Frequency>().Property(x => x.Date).HasColumnType("datetime").IsRequired();
        }
    }
}
