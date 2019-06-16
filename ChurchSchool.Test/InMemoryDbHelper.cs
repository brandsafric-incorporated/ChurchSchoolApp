using ChurchSchool.Repository;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Test
{
    public class InMemoryDbHelper
    {
        public static DbContextOptions<InMemoryDbContext> BuildContextOptions()
        {
            return new DbContextOptionsBuilder<InMemoryDbContext>()
                                                    .UseInMemoryDatabase(databaseName: "ChurchSchoolAppDb")
                                                    .Options;
        }
    }
}
