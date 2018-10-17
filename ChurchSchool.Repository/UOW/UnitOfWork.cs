using ChurchSchool.Repository.Contracts;
using ChurchSchool.Repository.Repositories;

namespace ChurchSchool.Repository.UOW
{
    public abstract class UnitOfWorkBase
    {
        public abstract void Commit();
    }

    public class UnitOfWork : UnitOfWorkBase,  IUnitOfWork
    {
        private RepositoryContext _context;

        public UnitOfWork(RepositoryContext context)
        {
            _context = context;
        }

        public override void Commit()
        {
            _context.SaveChanges();
        }
    }

    public class UnitOfWorkIdentity : UnitOfWorkBase, IUnitOfWorkIdentity
    {
        private ApplicationDbContext _context;

        public UnitOfWorkIdentity(ApplicationDbContext context)
        {
            _context = context;
        }

        public override void Commit()
        {
            _context.SaveChanges();
        }
    }
}
