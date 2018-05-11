using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Curriculum : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Curriculum>().HasKey(x => x.Id);
            builder.Entity<Domain.Entities.Curriculum>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Domain.Entities.Curriculum>().Property(x => x.Description).HasColumnType("varchar(500)").IsRequired();
            builder.Entity<Domain.Entities.Curriculum>().Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
