using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Application.Contracts
{
    public interface IAccount
    {
        Domain.Entities.Account Create(Domain.Entities.Account account);
        Domain.Entities.Account Modify(Domain.Entities.Account account);
    }
}
