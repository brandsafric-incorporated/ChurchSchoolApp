using ChurchSchool.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Test
{
    [TestClass]
    public class CourseConfigurationTest
    {
        private DbContextOptions<InMemoryDbContext> _databaseContextOptions;

        [TestInitialize]
        public void Initialize()
        {
            _databaseContextOptions = InMemoryDbHelper.BuildContextOptions();
        }
    }
}
