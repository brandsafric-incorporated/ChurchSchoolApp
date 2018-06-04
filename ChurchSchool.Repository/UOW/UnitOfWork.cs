using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

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
}
