using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Course : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Course>().HasKey(x => x.Id);
            builder.Entity<Domain.Entities.Course>().Property(x => x.Name).HasColumnType("varchar(200)").IsRequired();
            builder.Entity<Domain.Entities.Course>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Domain.Entities.Course>().Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
