using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.ModelSettings
{
    public class CourseClass : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.CourseClass>().HasKey(x => new { x.ScholarTermId, x.CurriculumId });
            builder.Entity<Domain.Entities.CourseClass>().Property(x => x.Description).HasColumnType("varchar(500)").IsRequired();
        }
    }
}
