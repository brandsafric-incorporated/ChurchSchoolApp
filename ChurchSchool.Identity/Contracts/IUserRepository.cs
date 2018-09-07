
namespace ChurchSchool.Identity.Contracts
{
    public interface IUserRepository
    {
        Model.User GetUserByEmail(string userEmail);
        Model.User GetUserByValidationToken(string validationToken);
        bool Update(Model.User user);
    }
}
