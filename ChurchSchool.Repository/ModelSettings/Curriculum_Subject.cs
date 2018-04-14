using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Curriculum_Subject : IModelConfiguration
    {
        public void Configure(ModelBuilder builder) => builder.Entity<Domain.Entities.Curriculum_Subject>().HasKey(k => new { k.CurriculumId, k.SubjectId });
    }
}
