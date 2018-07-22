using ChurchSchool.Repository.Contracts;
using ChurchSchool.Repository.Repositories;

namespace ChurchSchool.Repository.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private RepositoryContext _context;

        public UnitOfWork(RepositoryContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }

    public class UnitOfWorkIdentity : IUnitOfWorkIdentity
    {
        private ApplicationDbContext _context;

        public UnitOfWorkIdentity(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
