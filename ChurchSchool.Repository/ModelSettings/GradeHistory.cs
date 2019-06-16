using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.ModelSettings
{
    public class GradeHistory : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.GradeHistory>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Id).UseSqlServerIdentityColumn();
                x.Property(y => y.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                x.Property(y => y.UpdatedDate).HasColumnType("datetime");
                x.Property(y => y.RemovedDate).HasColumnType("datetime");
            });
        }
    }
}
