using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Course : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Course>(o =>
            {
                o.HasKey(x => x.Id);
                o.Property(x => x.Id).HasDefaultValueSql("NEWID()");
                o.Property(x => x.Name).HasColumnType("varchar(200)").IsRequired();
                o.Property(x => x.Description).IsRequired(false).HasColumnType("varchar(max)");                
                o.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                o.Property(x => x.UpdatedDate).HasColumnType("datetime");
                o.Property(x => x.RemovedDate).HasColumnType("datetime");
            });
        }
    }
}
