using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Application.Contracts
{
    public interface IAccount
    {
        Domain.Entities.Account Create(Domain.Entities.Account account);
        Domain.Entities.Account Modify(Domain.Entities.Account account);
        Task RecoverPassword(string userEmail);
        bool CheckIfUserExists(string userEmail);
        bool ResetPassword(string token, string password);
        bool ValidateToken(string token);
    }
}
