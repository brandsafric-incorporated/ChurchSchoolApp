using ChurchSchool.Identity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Identity.Contracts
{
    public interface IPasswordRecovery
    {
        bool IsTokenValid(User user);
        string GeneratePasswordRecoveryToken(User user);
        string CreateRecoveryEmail(User user);
    }
}
