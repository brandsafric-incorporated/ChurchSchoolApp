using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.ModelSettings
{
    public class CourseClass_Student : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.CourseClass_Student>(w =>
            {
                w.HasKey(k => new { k.CourseClassId, k.StudentId });
                w.Property(x => x.Id).UseSqlServerIdentityColumn();                
                w.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                w.Property(x => x.UpdatedDate).HasColumnType("datetime").IsRequired(required: false);
                w.Property(x => x.RemovedDate).HasColumnType("datetime").IsRequired(required: false);
            });

            builder.Entity<Domain.Entities.CourseClass_Student>().Ignore(q => q.Id);
        }
    }
}
