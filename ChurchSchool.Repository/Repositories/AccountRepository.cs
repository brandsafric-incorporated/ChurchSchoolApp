using AutoMapper;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Entities.Identity;
using ChurchSchool.Repository.Contracts;
using ChurchSchool.Shared.Validations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ChurchSchool.Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public AccountRepository(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public Account Add(Account model)
        {
            var user = _mapper.Map<Domain.Entities.Identity.User>(model);
            _context.Users.Add(user);
            return model;
        }

        public IEnumerable<Account> Filter(Account model)
        {
            var result = _context.Users.Where(x =>
                                    (!string.IsNullOrEmpty(x.UserName) && x.UserName.Contains(model.UserName)) ||
                                        (x.PersonId != default(long) && x.PersonId == model.PersonId)
                                     ).Select(x => new Account
                                     {
                                         Errors = new List<Error>(),
                                         Id = x.Id,
                                         Password = x.PasswordHash,
                                         PersonId = x.PersonId,
                                         UserName = x.UserName
                                     });
            return result;
        }

        public Account GetAccountByUserEmail(string userEmail)
        {
            var dbResult = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            var result = _mapper.Map<Domain.Entities.Identity.Account>(dbResult);
            return result;
        }

        public Domain.Entities.Identity.User GetUserByUserEmail(string userEmail)
        {
            var result = _context.Users.FirstOrDefault(u => u.Email == userEmail);
            return result;
        }


        public Account GetAccountByUserName(string userName)
        {
            var result = _mapper.Map<Domain.Entities.Identity.Account>(_context.Users.FirstOrDefault(u => u.UserName == userName));
            return result;
        }

        public IEnumerable<Account> GetAll() => throw new NotImplementedException();

        public IEnumerable<UserClaim> GetUserClaims(string userEmail)
        {
            var result = (from claim in _context.UserClaims
                    join user in _context.Users on claim.UserId equals user.Id
                    where user.Email == userEmail
                    select claim) as IEnumerable<UserClaim>;


            return result;
        }

        public bool Remove(long key)
        {
            var user = _mapper.Map<Domain.Entities.Identity.User>(Filter(new Account { PersonId = key }).FirstOrDefault());

            if (user == null)
                return false;

            user.IsDisabled = true;

            _context.Users.Update(user);

            return true;
        }

        public bool Update(Account model)
        {
            var parsedAccount = _mapper.Map<Domain.Entities.Identity.User>(model);

            var currentUser = _mapper.Map<Domain.Entities.Identity.User>(Filter(model).FirstOrDefault());

            if (currentUser == null)
                return false;

            currentUser = parsedAccount;

            _context.Users.Update(currentUser);

            return true;
        }

        public IEnumerable<UserClaim> GetUserClaimsByClaimCode(params string[] claimCodes)
        {
            var result = from claim in _context.UserClaims
                         join claimCode in claimCodes on claim.ClaimValue equals claimCode
                         select claim;

            return result;
        }
    }
}
