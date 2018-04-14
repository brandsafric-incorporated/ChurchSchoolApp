using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Enrollment : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Enrollment>().HasKey(x => x.Id);
            builder.Entity<Domain.Entities.Enrollment>().Property(x => x.Status).HasColumnType("int").IsRequired();
            builder.Entity<Domain.Entities.Enrollment>().Property(x => x.EnrollmentDate).HasColumnType("datetime").IsRequired();
        }
    }
}
