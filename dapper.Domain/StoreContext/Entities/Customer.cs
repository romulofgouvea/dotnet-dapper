using System.Collections.Generic;
using System;
using dapper.Domain.ValueObjects;
using System.Linq;

namespace dapper.Domain.StoreContext.Entities
{
    public class Customer
    {
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        private readonly IList<Address> _addresses;

        public Customer(
            Name name,
            string email,
            Document document,
            string phone)
        {
            Name = name;
            Email = email;
            Document = document;
            Phone = phone;

            _addresses = new List<Address>();
        }

        public void AddAddress(Address address)
        {
            //validar e adicionar o endereço
            _addresses.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}