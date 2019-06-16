using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.ModelSettings
{
    public class ScholarTerm : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.ScholarTerm>(y=> {
                y.HasKey(x => x.Id);
                y.Property(x => x.Id).UseSqlServerIdentityColumn();
                y.Property(x => x.Description).HasColumnType("varchar(500)").IsRequired();
                y.Property(x => x.StartDate).IsRequired();
                y.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                y.Property(x => x.UpdatedDate).HasColumnType("datetime").IsRequired(required: false);
                y.Property(x => x.RemovedDate).HasColumnType("datetime").IsRequired(required: false);
            });

        }

    }
}
