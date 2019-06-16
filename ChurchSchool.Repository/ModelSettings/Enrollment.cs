using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Enrollment : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Enrollment>(x =>
            {
                x.HasKey(q => q.Id);
                x.Property(q => q.Id).UseSqlServerIdentityColumn();
                x.Property(q => q.Status).HasColumnType("int").IsRequired();
                x.Property(q => q.EnrollmentDate).HasColumnType("datetime").IsRequired();
                x.Property(q => q.InsertedDate).HasColumnType("datetime").IsRequired().HasDefaultValueSql("GETDATE()");
                x.Property(q => q.UpdatedDate).HasColumnType("datetime");
                x.Property(q => q.RemovedDate).HasColumnType("datetime");
            });
        }
    }
}
