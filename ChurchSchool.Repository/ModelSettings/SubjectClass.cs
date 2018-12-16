using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.ModelSettings
{
    public class SubjectClass : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.SubjectClass>(y =>
            {
                y.Property(x => x.Id).UseSqlServerIdentityColumn();
                y.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                y.Property(x => x.UpdatedDate).HasColumnType("datetime").IsRequired(required: false);
                y.Property(x => x.RemovedDate).HasColumnType("datetime").IsRequired(required: false);
                y.Property(x => x.StartDate).HasColumnType("datetime").IsRequired(required: true);
                y.Property(x => x.FinishDate).HasColumnType("datetime").IsRequired(required: false);
            });

            builder.Entity<Domain.Entities.SubjectClass>()
                   .HasOne(s => s.Subject)
                   .WithMany(r => r.RelatedClasses)
                   .HasForeignKey(x => x.SubjectId)
                   ;

            builder.Entity<Domain.Entities.SubjectClass>()
                   .HasOne(s => s.Professor)
                   .WithMany(r => r.RelatedSubjects)
                   .HasForeignKey(x => x.ProfessorId)
                   ;
        }
    }
}
