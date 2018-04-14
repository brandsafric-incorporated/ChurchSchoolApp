using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Curriculum : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Curriculum>().HasKey(x => x.Id);
            builder.Entity<Domain.Entities.Curriculum>().Property(x => x.Description).HasColumnType("varchar").HasMaxLength(500).IsRequired();
        }
    }
}
