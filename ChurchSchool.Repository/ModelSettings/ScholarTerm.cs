﻿using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.ModelSettings
{
    public class ScholarTerm : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.ScholarTerm>().HasKey(x => x.Id);
            builder.Entity<Domain.Entities.ScholarTerm>().Property(x => x.Description).HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Entity<Domain.Entities.ScholarTerm>().Property(x => x.StartDate).IsRequired();
        }

    }
}
