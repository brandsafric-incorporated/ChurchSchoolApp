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
                k.Property(x => x.Id).HasDefaultValueSql("NEWID()");
                k.Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
            });

        }
    }
}
