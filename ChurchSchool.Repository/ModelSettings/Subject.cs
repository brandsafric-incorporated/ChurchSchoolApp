﻿using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Subject : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Subject>().HasKey(x => x.Id);
            builder.Entity<Domain.Entities.Subject>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Domain.Entities.Subject>().Property(x => x.Name).HasColumnType("varchar(200)").IsRequired();
            builder.Entity<Domain.Entities.Subject>().Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
        }

    }
}
