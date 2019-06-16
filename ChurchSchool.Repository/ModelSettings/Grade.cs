using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Grade : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Grade>(q =>
            {
                q.HasKey(x => x.Id);
                q.Property(x => x.Id).UseSqlServerIdentityColumn();
                q.Property(x => x.Date).HasColumnType("datetime").IsRequired();
                q.Property(x => x.Value).IsRequired();
                q.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                q.Property(x => x.UpdatedDate).HasColumnType("datetime");
                q.Property(x => x.RemovedDate).HasColumnType("datetime");
            });
        }
    }
}
