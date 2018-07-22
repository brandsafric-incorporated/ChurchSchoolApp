using AutoMapper;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
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
            var user = _mapper.Map<Identity.Model.User>(model);
            _context.Users.Add(user);
            return model;
        }

        public IEnumerable<Account> Filter(Account model)
        {
            var result = _context.Users.Where(x =>
                                    (!string.IsNullOrEmpty(x.UserName) && x.UserName.Contains(model.UserName)) ||
                                        (x.PersonId != default(Guid) && x.PersonId == model.PersonId)
                                     ).Select(x=> new Account {
                                         Errors = new List<Error>(),
                                         Id = x.Id,
                                         Password = x.PasswordHash,
                                         PersonId = x.PersonId, 
                                         UserName = x.UserName
                                     });           
            return result;
        }

        public Account GetAccountByUserName(string userName)
        {
            var result = _mapper.Map<Domain.Entities.Account>(_context.Users.FirstOrDefault(u => u.UserName == userName));
            return result;
        }

        public IEnumerable<Account> GetAll() => throw new NotImplementedException();

        public IEnumerable<Claim> GetUserClaims(string userName)
        {
            return (from claim in _context.UserClaims
                    join user in _context.Users on claim.UserId equals user.Id
                    where user.UserName == userName
                    select claim.ToClaim()) as IEnumerable<Claim>;
        }

        public bool Remove(Guid key)
        {
            var user = _mapper.Map<Identity.Model.User>(Filter(new Account { PersonId = key }).FirstOrDefault());

            if (user == null)
                return false;

            user.IsDisabled = true;

            _context.Users.Update(user);

            return true;
        }

        public bool Update(Account model)
        {
            var parsedAccount = _mapper.Map<Identity.Model.User>(model);

            var currentUser = _mapper.Map<Identity.Model.User>(Filter(model).FirstOrDefault());

            if (currentUser == null)
                return false;

            currentUser = parsedAccount;

            _context.Users.Update(currentUser);

            return true;
        }
    }
}
