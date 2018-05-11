using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Curriculum_Subject : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Curriculum_Subject>().HasKey(k => new { k.CurriculumId, k.SubjectId });
            builder.Entity<Domain.Entities.Curriculum_Subject>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Domain.Entities.Curriculum_Subject>().Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
