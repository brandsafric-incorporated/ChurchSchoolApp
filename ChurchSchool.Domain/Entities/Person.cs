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
        public string Name { get; set; }

        public IList<Phone> Phones { get; set; }

        public ESex Sex { get; set; }

        public IList<Address> Addresses { get; set; }

        public DateTime BirthDate { get; set; }

        public Email Email { get; set; }

        public IList<PersonDocument> PersonDocuments { get; set; }

        public Student Student { get; set; }

        public virtual bool IsValid()
        {
            if (string.IsNullOrEmpty(Name))
            {
                AddError("Nome é obrigatório");
            }

            foreach (var phone in Phones)
            {
                if (!phone.ValidateBrazilianNumber())
                    AddError($"Número {phone.ToString()} com formato inválido.");
            }

            foreach (var address in Addresses)
            {
                if (address.IsValid())
                    AddError(address.Errors.ToArray());
            }

            if (!PersonDocuments.Any(x => x.DocumentTypeId == EDocumentType.CPF))
                AddError($"CPF é Obrigatório");

            if (BirthDate == default(DateTime))
                AddError($"Data de Nascimento inválida. Data Informada:{BirthDate.ToShortDateString()}");

            return !Errors.Any();
        }
    }
}
