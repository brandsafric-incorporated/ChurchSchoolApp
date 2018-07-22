using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ChurchSchool.Domain.Contracts
{
    public interface IAccountRepository : IRepository<Account>
    {
        Domain.Entities.Account GetAccountByUserName(string userName);

        IEnumerable<Claim> GetUserClaims(string userName);
    }
}
