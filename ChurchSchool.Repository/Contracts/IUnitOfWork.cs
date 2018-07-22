using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
    }

    public interface IUnitOfWorkIdentity : IUnitOfWork { }

    public interface IUnitOfWorkDomain : IUnitOfWork { }
}
