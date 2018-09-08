
using ChurchSchool.Domain.Entities.Identity;

namespace ChurchSchool.Repository.Contracts
{
    public interface IUserRepository
    {
        User GetUserByEmail(string userEmail);
        User GetUserByValidationToken(string validationToken);
        bool Update(User user);
    }
}
