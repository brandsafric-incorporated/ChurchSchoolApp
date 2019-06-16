using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class CourseClass : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.CourseClass>(h =>
            {
                h.HasKey(x => x.Id);
                h.Property(x => x.Id).UseSqlServerIdentityColumn();
                h.Property(x => x.Description).HasColumnType("varchar(500)").IsRequired();
                h.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                h.Property(x => x.UpdatedDate).HasColumnType("datetime");
                h.Property(x => x.RemovedDate).HasColumnType("datetime");
            });
        }
    }
}
