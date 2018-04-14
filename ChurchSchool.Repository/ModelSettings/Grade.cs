﻿using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.ModelSettings
{
    public class Grade : IModelConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Domain.Entities.Grade>().HasKey(x => x.Id);
            builder.Entity<Domain.Entities.Grade>().Property(x => x.Date).HasColumnType("datetime").IsRequired();
            builder.Entity<Domain.Entities.Grade>().Property(x => x.Value).IsRequired();
        }
    }
}
