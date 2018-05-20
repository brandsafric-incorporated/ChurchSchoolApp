using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Curriculum_Subject : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Curriculum_Subject>(y =>
            {
                y.HasKey(k => new { k.CurriculumId, k.SubjectId });
                y.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                y.Property(x => x.UpdatedDate).HasColumnType("datetime");
                y.Property(x => x.RemovedDate).HasColumnType("datetime");
            });

            builder.Entity<Domain.Entities.Curriculum_Subject>().Ignore(y => y.Id);
        }
    }
}
