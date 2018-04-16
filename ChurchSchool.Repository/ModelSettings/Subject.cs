using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Subject : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Subject>().HasKey(x => x.Id);
            builder.Entity<Domain.Entities.Subject>().Property(x => x.Name).HasColumnType("varchar(200)").IsRequired();
        }

    }
}
