using ChurchSchool.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Test
{
    public class InMemoryDbHelper
    {
        public static DbContextOptions<RepositoryContext> GenerateFakeOptionsObject()
        {
            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            builder.UseInMemoryDatabase("DB_SEMINARIO");
            return builder.Options;
        }
    }
}
