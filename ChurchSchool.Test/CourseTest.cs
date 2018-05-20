using ChurchSchool.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ChurchSchool.Test
{
    [TestClass]
    public class CourseTest
    {
        private DbContextOptions<RepositoryContext> _optionsRepository => InMemoryDbHelper.GenerateFakeOptionsObject();
        
        [TestMethod]
        public void ShouldCreateAnCourse()
        {
            
        }
    }
}
