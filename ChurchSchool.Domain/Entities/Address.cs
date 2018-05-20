using ChurchSchool.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchSchool.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string Neighborhood { get; set; }
        public int CityId { get; set; }
        public string State { get; set; }
        public string Details { get; set; }
        public string PostalCode { get; set; }

        public int AddressTypeId { get; set; }

        [NotMapped]
        public EAddressType Type { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(StreetName) &&
                   StreetNumber > 0 &&
                   !string.IsNullOrEmpty(Neighborhood) &&
                   !string.IsNullOrEmpty(State) &&
                   Type != EAddressType.UNDEFINED;
        }
    }
}