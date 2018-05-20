using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class CourseConfiguration : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.CourseConfiguration>(u =>
            {
                u.HasKey(x => x.Id);
                u.Property(x => x.Id).HasDefaultValueSql("NEWID()");
                u.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                u.Property(x => x.UpdatedDate).HasColumnType("datetime");
                u.Property(x => x.RemovedDate).HasColumnType("datetime");
            });
        }
    }
}
