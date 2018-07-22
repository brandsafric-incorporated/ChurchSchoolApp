using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Shared;
using System;
using System.Linq;

namespace ChurchSchool.Application
{
    public class Account : IAccount
    {
        private readonly IAccountRepository _accountRepository;


        public Account(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Domain.Entities.Account Create(Domain.Entities.Account account)
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

        private void ValidateToCreate(Domain.Entities.Account account)
        {
            account.IsValid();

            var existingAccounts = _accountRepository.Filter(account);

            if (existingAccounts.Any(x => x.UserName == account.UserName))
                account.AddError("Login já cadastrado para outro usuário");

            if (existingAccounts.Any(x => x.PersonId == account.PersonId))
                account.AddError("Este usuário já está cadastrado.");
        }

        private void ValidateToModify(Domain.Entities.Account account)
        {
            account.IsValid();

            if (string.IsNullOrWhiteSpace(account.Id))
                account.AddError("Chave da conta é obrigatória");

            var existingAccounts = _accountRepository.Filter(account);

            if (existingAccounts.Any(x => x.UserName == account.UserName && x.PersonId != account.PersonId))
                account.AddError("Login já cadastrado para outro usuário");
        }

        public Domain.Entities.Account Modify(Domain.Entities.Account account)
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
    }
}
