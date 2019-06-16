using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Enum;
using ChurchSchool.Domain.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class Person : BaseEntity, IValidateObject
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public string ProfileImage { get; set; }

        public ESex Sex { get; set; }
        public Email Email { get; set; }
        public IList<Phone> Phones { get; set; }
        public IList<Address> Addresses { get; set; }
        public IList<PersonDocument> Documents { get; set; }

        public virtual bool IsValid()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                AddError("Nome é obrigatório");
            }

            if (!Documents.Any(x => x.DocumentType == EDocumentType.CPF))
                AddError($"CPF é Obrigatório");

            foreach (var phone in Phones)
            {
                if (!phone.ValidateBrazilianNumber())
                    AddError($"Número {phone.ToString()} com formato inválido.");
            }

            foreach (var address in Addresses)
            {
                if (!address.IsValid())
                    AddError(address.Errors.ToArray());
            }

            if (BirthDate == default(DateTime))
                AddError($"Data de Nascimento inválida. Data Informada:{BirthDate.ToShortDateString()}");

            return !Errors.Any();
        }
    }
}
