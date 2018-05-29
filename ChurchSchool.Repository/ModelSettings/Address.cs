using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Address : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Address>(o =>
            {
                o.HasKey(x => x.Id);
                o.Property(x => x.Id).HasDefaultValueSql("NEWID()");
                o.Property(x => x.CityId).IsRequired();
                o.Property(x => x.State).HasColumnType("varchar(2)").IsRequired();
                o.Property(x => x.StreetName).HasColumnType("varchar(500)").IsRequired();
                o.Property(x => x.StreetNumber).HasColumnType("varchar(10)").IsRequired();
                o.Property(x => x.Neighborhood).HasColumnType("varchar(500)").IsRequired();
                o.Property(x => x.PostalCode).HasColumnType("varchar(8)").IsRequired();
                o.Property(x => x.Details).HasColumnType("varchar(max)").IsRequired(required: false);
                o.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                o.Property(x => x.UpdatedDate).HasColumnType("datetime");
                o.Property(x => x.RemovedDate).HasColumnType("datetime");
            });
        }
    }
}
