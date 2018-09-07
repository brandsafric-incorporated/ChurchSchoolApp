using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Identity.Contracts;
using ChurchSchool.Identity.Model;
using ChurchSchool.Shared;

namespace ChurchSchool.Identity
{
    public class Authorization : IAuthorization
    {
        private IAccountRepository _accountRepository;
        private IJwtFactory _jwtFactory;
        private IConfigurationSection _jwtIssuerOptions;

        public Authorization(IAccountRepository accountRepository,
                             IJwtFactory jwtFactory,
                             IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _jwtFactory = jwtFactory;
            _jwtIssuerOptions = configuration.GetSection(nameof(JwtIssuerOptions));
        }

        public IEnumerable<Claim> GetUserClaims(string userEmail)
        {
            return _accountRepository.GetUserClaims(userEmail);
        }

        public string Login(Account accountInfo)
        {
            var foundAccount = ValidateUserCredentials(accountInfo.Email, accountInfo.Password);

            if (foundAccount == null)
                return string.Empty;

            var userClaims = GetUserClaims(foundAccount.Email);
            
            var authenticationToken = _jwtFactory.GenerateEncodedToken(accountInfo.Email, userClaims).Result;

            var jwtObject = GenerateJwt(foundAccount.Id, authenticationToken);

            return jwtObject;
        }

        private string GenerateJwt(string id, string authenticationToken)
        {
            var jwt = new
            {
                id,
                auth_token = authenticationToken,
                expires_in = JwtIssuerOptions.jwtIssuerOptions.Expiration
            };

            return JsonConvert.SerializeObject(jwt);
        }

        public Domain.Entities.Account ValidateUserCredentials(string userEmail, string password)
        {
            var account = _accountRepository.GetAccountByUserEmail(userEmail);

            if(account != null && account.Password == Encrypt.Hash(password))
            {
                return account.RemovePasswordData();
            }
            else
            {
                return null;
            }
        }
    }
}
