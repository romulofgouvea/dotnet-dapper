using System;
using dapper.Domain.StoreContext.Enums;
using dapper.Domain.ValueObjects;

namespace dapper.Domain.StoreContext.Entities
{
    public class Address
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public EAddressType TypeAddress { get; private set; }

        public Address(
            string street,
            string number,
            string complement,
            string district,
            string city,
            string state,
            string country,
            string zipCode,
            EAddressType type)
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            TypeAddress = type;
        }

        public override string ToString()
        {
            return $"{Street}, {Number} - {City}/{State}";
        }
    }
}