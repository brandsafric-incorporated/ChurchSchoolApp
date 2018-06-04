using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class StudentDocument : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.StudentDocument>(y =>
            {
                y.HasKey(t => t.Id);
                y.Property(t => t.DocumentNumber).HasColumnType("varchar(30)").IsRequired();
                y.Property(t => t.DocumentTypeId).HasColumnType("int").IsRequired();
                y.Property(t => t.IssuingDate).HasColumnType("datetime").IsRequired();
                y.Property(t => t.IssuingEntity).HasColumnType("varchar(30)").IsRequired();
                y.Property(t => t.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                y.Property(t => t.UpdatedDate).HasColumnType("datetime");
                y.Property(t => t.RemovedDate).HasColumnType("datetime");
            });

            builder.Entity<Domain.Entities.PersonDocument>(y =>
            {
                y.HasKey(t => t.Id);
                y.Property(t => t.DocumentNumber).HasColumnType("varchar(30)").IsRequired();
                y.Property(t => t.DocumentTypeId).HasColumnType("int").IsRequired();
                y.Property(t => t.IssuingDate).HasColumnType("datetime").IsRequired();
                y.Property(t => t.IssuingEntity).HasColumnType("varchar(30)").IsRequired();
                y.Property(t => t.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                y.Property(t => t.UpdatedDate).HasColumnType("datetime");
                y.Property(t => t.RemovedDate).HasColumnType("datetime");
            });
        }
    }
}
