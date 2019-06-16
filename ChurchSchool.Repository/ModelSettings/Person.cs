using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Person : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {   
            builder.Entity<Domain.Entities.Person>(p =>
            {
                p.HasKey(x => x.Id);
                p.Property(x => x.Id).UseSqlServerIdentityColumn();
                p.Property(x => x.FirstName).HasColumnType("varchar(50)").IsRequired();
                p.Property(x => x.MiddleName).HasColumnType("varchar(50)");
                p.Property(x => x.LastName).HasColumnType("varchar(50)").IsRequired();
                p.Property(x => x.BirthDate).HasColumnType("datetime").IsRequired(required: true);
                p.Property(x => x.InsertedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                p.Property(x => x.UpdatedDate).HasColumnType("datetime").IsRequired(required: false);
                p.Property(x => x.RemovedDate).HasColumnType("datetime").IsRequired(required: false);
                p.Property(x => x.ProfileImage).HasColumnType("VARCHAR(5000)");
            });
        }        
    }
}
