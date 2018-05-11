using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.ModelSettings
{
    public class CourseClass_Subject : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.CourseClass_Subject>()
                       .HasKey(k => new { k.CourseClassId, k.SubjectId, k.ProfessorId });

            builder.Entity<Domain.Entities.CourseClass_Subject>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Domain.Entities.CourseClass_Subject>().Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");

        }
    }
}
