using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Subject : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Subject>(y =>
            {
                y.HasKey(x => x.Id);
                y.Property(x => x.Id).UseSqlServerIdentityColumn();
                y.Property(x => x.Name).HasColumnType("varchar(200)").IsRequired();
                y.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                y.Property(x => x.UpdatedDate).HasColumnType("datetime");
                y.Property(x => x.RemovedDate).HasColumnType("datetime");
            });
        }
    }
}
