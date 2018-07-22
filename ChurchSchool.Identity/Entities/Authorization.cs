using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Identity.Contracts;
using ChurchSchool.Identity.Model;
using ChurchSchool.Shared;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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

        public IEnumerable<Claim> GetUserClaims(string userName)
        {
            return _accountRepository.GetUserClaims(userName);
        }

        public string Login(Account accountInfo)
        {
            var foundAccount = ValidateUserCredentials(accountInfo.UserName, accountInfo.Password);

            if (foundAccount == null)
                return string.Empty;

            var userClaims = GetUserClaims(foundAccount.UserName);
            
            var authenticationToken = _jwtFactory.GenerateEncodedToken(accountInfo.UserName, userClaims).Result;

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

        public Domain.Entities.Account ValidateUserCredentials(string userName, string password)
        {
            return _accountRepository.Filter(new Account { UserName = userName })
                                     .FirstOrDefault(x => x.Password == Encrypt.Hash(password))
                                     ?.RemovePasswordData();
        }
    }
}
