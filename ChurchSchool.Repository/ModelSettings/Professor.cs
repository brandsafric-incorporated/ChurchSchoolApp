using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Professor : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {   
            builder.Entity<Domain.Entities.Professor>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Domain.Entities.Professor>().Property(x => x.Name).HasColumnType("varchar(200)").IsRequired();
            builder.Entity<Domain.Entities.Professor>().Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
