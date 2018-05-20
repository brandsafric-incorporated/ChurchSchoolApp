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
                w.HasKey(k => new { k.CourseClassId, k.EnrolledStudentId });
                w.Property(x => x.Id).HasDefaultValueSql("NEWID()");
                w.Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
            });

            builder.Entity<Domain.Entities.CourseClass_Student>().Ignore(q => q.Id);
        }
    }
}
