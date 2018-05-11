using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Student : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Student>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Domain.Entities.Student>().Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
            builder.Entity<Domain.Entities.Student>().Property(x => x.Name).HasColumnType("varchar(200)").IsRequired();
        }

    }
}
