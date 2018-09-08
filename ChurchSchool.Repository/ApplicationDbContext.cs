using ChurchSchool.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ChurchSchool.Repository
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public DbSet<Domain.Entities.Identity.User> Users { get; set; }
        //public DbSet<Microsoft.AspNetCore.Identity.IdentityUserClaim<int>> UserClaims { get; set; }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer("Data Source=(local)\\SERVER_XPS;Initial Catalog=DB_SEMINARIO;Integrated Security=True");
            return new ApplicationDbContext(builder.Options);
        }
    }
}
