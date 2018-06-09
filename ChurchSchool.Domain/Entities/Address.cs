using ChurchSchool.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Neighborhood { get; set; }
        public int CityId { get; set; }
        public string State { get; set; }
        public string Details { get; set; }
        public string PostalCode { get; set; }

        public int AddressTypeId { get; set; }

        public Guid PersonId { get; set; }

        [NotMapped]
        public EAddressType Type => (EAddressType)AddressTypeId;

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(StreetName))
                AddError("Nome da Rua não informado.");

            if (string.IsNullOrEmpty(Neighborhood))
                AddError("Bairro não informado.");

            if (string.IsNullOrEmpty(State))
                AddError("Estado não informado");

            if (Type == EAddressType.UNDEFINED)
                AddError("Tipo de residência não informado.");

            return !Errors.Any();
        }
    }
}