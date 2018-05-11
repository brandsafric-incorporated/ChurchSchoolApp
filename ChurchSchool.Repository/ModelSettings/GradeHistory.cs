using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.ModelSettings
{
    public class GradeHistory : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.GradeHistory>().HasKey(x => x.Id);
            builder.Entity<Domain.Entities.GradeHistory>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Domain.Entities.GradeHistory>().Property(x => x.InsertedDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
