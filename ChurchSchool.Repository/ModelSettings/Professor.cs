using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Professor : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Professor>(k =>
            {
                k.Property(x => x.Id).UseSqlServerIdentityColumn();
                k.Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
                k.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                k.Property(x => x.UpdatedDate).HasColumnType("datetime").IsRequired(required: false);
                k.Property(x => x.RemovedDate).HasColumnType("datetime").IsRequired(required: false);
            });

        }
    }
}
