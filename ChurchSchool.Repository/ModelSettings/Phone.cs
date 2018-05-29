using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Phone : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Structs.Phone>(o =>
            {
                o.HasKey(x => x.Id);
                o.Property(x => x.AreaCode).HasColumnType("varchar(4)").IsRequired();
                o.Property(x => x.Number).HasColumnType("varchar(10)").IsRequired();
                o.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                o.Property(x => x.UpdatedDate).HasColumnType("datetime");
                o.Property(x => x.RemovedDate).HasColumnType("datetime");
            });
        }
    }
}
