using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ChurchSchool.Repository.Contracts
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetAccountByUserName(string userName);

        Account GetAccountByUserEmail(string userEmail);

        IEnumerable<UserClaim> GetUserClaims(string userName);

        IEnumerable<UserClaim> GetUserClaimsByClaimCode(params string[] claimCodes);
    }
}
