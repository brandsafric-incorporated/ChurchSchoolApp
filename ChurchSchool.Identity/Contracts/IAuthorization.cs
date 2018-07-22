using ChurchSchool.Identity.Model;
using System.Collections.Generic;
using System.Security.Claims;

namespace ChurchSchool.Identity.Contracts
{
    public interface IAuthorization
    {
        IEnumerable<Claim> GetUserClaims(string userName);

        Domain.Entities.Account ValidateUserCredentials(string userName, string password);

        string Login(Domain.Entities.Account accountInfo);
    }
}