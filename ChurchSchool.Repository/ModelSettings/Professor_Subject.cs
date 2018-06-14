﻿using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Professor_Subject : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.ProfessorSubject>(y =>
            {
                y.HasKey(x => x.Id);
                y.Property(x => x.Id).HasDefaultValueSql("NEWID()");
                y.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                y.Property(x => x.UpdatedDate).HasColumnType("datetime");
                y.Property(x => x.RemovedDate).HasColumnType("datetime");
            });
        }
    }
}
