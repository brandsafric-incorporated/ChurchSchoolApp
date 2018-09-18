using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Application.Contracts
{
    public interface IAccount
    {
        Domain.Entities.Identity.Account Create(Domain.Entities.Identity.Account account);
        Domain.Entities.Identity.Account Modify(Domain.Entities.Identity.Account account);
        Domain.Entities.Identity.Account FindbyEmailAccount(string emailAccount);
        Task RecoverPassword(string userEmail);
        bool CheckIfUserExists(string userEmail);
        bool ResetPassword(string token, string password);
        bool ValidateToken(string token);
    }
}
