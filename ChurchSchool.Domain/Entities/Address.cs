﻿using ChurchSchool.Domain.Enum;

namespace ChurchSchool.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Details { get; set; }
        public AddressType Type { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(StreetName) &&
                   StreetNumber > 0 &&
                   !string.IsNullOrEmpty(Neighborhood) &&
                   !string.IsNullOrEmpty(City) &&
                   !string.IsNullOrEmpty(State) &&
                   Type != AddressType.UNDEFINED;
        }
    }
}