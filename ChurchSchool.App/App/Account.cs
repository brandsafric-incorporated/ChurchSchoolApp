using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities.Identity;
using ChurchSchool.Identity.Contracts;
using ChurchSchool.Repository.Contracts;
using ChurchSchool.Service.Contracts;
using ChurchSchool.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchSchool.Application
{
    public class Account : IAccount
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordRecovery _passwordRecovery;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorkIdentity _unitOfWorkIdentity;

        public Account(IAccountRepository accountRepository,
                       IUserRepository userRepository,
                       IPasswordRecovery passwordRecovery,
                       IEmailService emailService,
                       IUnitOfWorkIdentity unitOfWorkIdentity)
        {
            _accountRepository = accountRepository;
            _passwordRecovery = passwordRecovery;
            _emailService = emailService;
            _userRepository = userRepository;
            _unitOfWorkIdentity = unitOfWorkIdentity;
        }

        public Domain.Entities.Identity.Account Create(Domain.Entities.Identity.Account account)
        {
            ValidateToCreate(account);

            if (!account.Errors.Any())
            {
                account.Password = Encrypt.Hash(account.Password);

                var result = _accountRepository.Add(account);

                return result;
            }

            return account;
        }

        private void ValidateToCreate(Domain.Entities.Identity.Account account)
        {
            account.IsValid();

            var existingAccounts = _accountRepository.Filter(account);

            if (existingAccounts.Any(x => x.UserName == account.UserName))
                account.AddError("Login já cadastrado para outro usuário");

            if (existingAccounts.Any(x => x.PersonId == account.PersonId))
                account.AddError("Este usuário já está cadastrado.");
        }

        private void ValidateToModify(Domain.Entities.Identity.Account account)
        {
            account.IsValid();

            if (string.IsNullOrWhiteSpace(account.Id))
                account.AddError("Chave da conta é obrigatória");

            var existingAccounts = _accountRepository.Filter(account);

            if (existingAccounts.Any(x => x.UserName == account.UserName && x.PersonId != account.PersonId))
                account.AddError("Login já cadastrado para outro usuário");
        }

        public Domain.Entities.Identity.Account Modify(Domain.Entities.Identity.Account account)
        {
            ValidateToModify(account);

            if (!account.Errors.Any())
            {
                var result = _accountRepository.Update(account);

                if (!result)
                    account.AddError("Houve um erro ao atualizar suas informações de conta, tente novamente mais tarde.");
            }

            return account;
        }

        public async Task RecoverPassword(string userEmail)
        {
            var userData = _userRepository.GetUserByEmail(userEmail);

            userData.PasswordRecoveryToken = _passwordRecovery.GeneratePasswordRecoveryToken(userData);

            userData.PasswordRecoveryRequestedDate = DateTime.Now;

            try
            {
                _userRepository.Update(userData);
                _unitOfWorkIdentity.Commit();
            }
            catch (Exception)
            {
                throw new Exception("Houve um erro ao tentar atualizar as informações de conta.");
            }

            var messageBody = _passwordRecovery.CreateRecoveryEmail(userData);

            await _emailService.SendEmail(userEmail, "Recuperação de Senha", messageBody, true);

            return;

        }

        public bool CheckIfUserExists(string userEmail)
        {
            return _accountRepository.GetAccountByUserEmail(userEmail) != null;
        }

        public bool ValidateToken(string token)
        {
            var userData = _userRepository.GetUserByValidationToken(token);
            return _passwordRecovery.IsTokenValid(userData);
        }

        public bool ResetPassword(string token, string password)
        {
            if (ValidateToken(token))
            {
                var userData = _userRepository.GetUserByValidationToken(token);
                userData.PasswordHash = Encrypt.Hash(password);
                userData.PasswordRecoveryRequestedDate = null;
                userData.PasswordRecoveryToken = null;
                _userRepository.Update(userData);
                return true;
            }

            return false;
        }

        public Domain.Entities.Identity.Account FindbyEmailAccount(string emailAccount)
        {
            return _accountRepository.GetAccountByUserEmail(emailAccount);
        }
    }
}
