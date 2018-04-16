using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Professor : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Professor>().HasKey(x => x.Id);
            builder.Entity<Domain.Entities.Professor>().Property(x => x.Name).HasColumnType("varchar(200)").IsRequired();
        }
    }
}
