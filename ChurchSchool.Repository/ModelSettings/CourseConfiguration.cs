using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class CourseConfiguration : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.CourseConfiguration>().HasKey(x => x.Id);
            builder.Entity<Domain.Entities.CourseConfiguration>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Domain.Entities.CourseConfiguration>().Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
        }

    }
}
