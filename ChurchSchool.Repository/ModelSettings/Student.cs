using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Student : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Student>().HasKey(x => x.Id);
            builder.Entity<Domain.Entities.Student>().Property(x => x.Name).HasColumnType("varchar(200)").IsRequired();
        }

    }
}
