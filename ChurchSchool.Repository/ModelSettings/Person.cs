using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Person : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Person>(p =>
            {
                p.HasKey(x => x.Id);
                p.Property(x => x.Id).HasDefaultValueSql("NEWID()");
                p.Property(x => x.Name).HasColumnType("varchar(200)").IsRequired();                
                p.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                p.Property(x => x.UpdatedDate).HasColumnType("datetime").IsRequired(required: false);
                p.Property(x => x.RemovedDate).HasColumnType("datetime").IsRequired(required: false);
            });
        }
    }
}
