using ChurchSchool.Domain.Contracts;
using ChurchSchool.Shared.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ChurchSchool.Domain.Entities
{
    public class Account : ValidationResult, IValidateObject
    {
        public string Id { get; set; }
        public Guid? PersonId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsValid()
        {
            if (PersonId == default(Guid))
                AddError("Código de usuário é obrigatório");

            if (string.IsNullOrEmpty(UserName))
                AddError("Login é obrigatório");

            if (!ValidatorHelper.ValidatePassword(Password))
                AddError("Senha é obrigatório, a senha deve possuir ao menos 8 caracteres");

            return !Errors.Any();
        }
        
        public Account RemovePasswordData()
        {
            this.Password = string.Empty;
            return this;
        }
    }
}

