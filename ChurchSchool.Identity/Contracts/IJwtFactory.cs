using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Identity.Contracts
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, IEnumerable<Claim> userClaims);        
    }
}
