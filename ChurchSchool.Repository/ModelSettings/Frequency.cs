using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Frequency : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Frequency>().HasKey(x => new { x.ScholarTermId, x.SubjectId, x.EnrollmentId });
            builder.Entity<Domain.Entities.Frequency>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Domain.Entities.Frequency>().Property(x => x.Date).HasColumnType("datetime").IsRequired();
            builder.Entity<Domain.Entities.Frequency>().Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
