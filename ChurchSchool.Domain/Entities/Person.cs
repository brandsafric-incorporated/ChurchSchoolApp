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

        public virtual bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) &&
                   !Phones.Any(phone => !phone.ValidateBrazilianNumber()) &&
                   !Addresses.Any(address => !address.IsValid()) &&
                   BirthDate != default(DateTime);
        }
    }
}
