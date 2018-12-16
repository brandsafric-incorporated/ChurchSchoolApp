using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class SubjectClassStudent : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.SubjectClassStudent>(y =>
            {
                y.Property(x => x.Id).UseSqlServerIdentityColumn();
                y.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                y.Property(x => x.UpdatedDate).HasColumnType("datetime").IsRequired(required: false);
                y.Property(x => x.RemovedDate).HasColumnType("datetime").IsRequired(required: false);
            });
        }
    }
}
