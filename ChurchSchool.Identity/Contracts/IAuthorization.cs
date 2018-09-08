using ChurchSchool.Domain.Entities.Identity;
using ChurchSchool.Identity.Model;
using System.Collections.Generic;
using System.Security.Claims;

namespace ChurchSchool.Identity.Contracts
{
    public interface IAuthorization
    {
        IEnumerable<Claim> GetUserClaims(string userEmail);

        Account ValidateUserCredentials(string userName, string password);

        string Login(Account accountInfo);
    }
}