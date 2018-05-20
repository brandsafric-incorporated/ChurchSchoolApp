using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Curriculum : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Curriculum>(k =>
            {
                k.HasKey(x => x.Id);
                k.Property(x => x.Id).HasDefaultValueSql("NEWID()");
                k.Property(x => x.Description).HasColumnType("varchar(500)").IsRequired();
                k.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                k.Property(x => x.UpdatedDate).HasColumnType("datetime");
                k.Property(x => x.RemovedDate).HasColumnType("datetime");
            });
        }
    }
}
