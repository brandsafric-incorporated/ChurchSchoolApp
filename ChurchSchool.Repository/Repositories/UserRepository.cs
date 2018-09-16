using ChurchSchool.Domain.Entities.Identity;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchSchool.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) => _context = context;


        public User GetUserByEmail(string userEmail)
        {
            return _context.Users.FirstOrDefault(x => x.Email == userEmail);
        }

        public User GetUserByValidationToken(string validationToken)
        {            
            return _context.Users.FirstOrDefault(x => x.PasswordRecoveryToken == validationToken);
        }

        public bool Update(User user)
        {
            _context.Update(user);
            return true;
        }
    }
}
