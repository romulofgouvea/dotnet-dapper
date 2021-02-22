using System;

namespace dapper.Domain.StoreContext.Entities
{
    public class Customer
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }

        public Customer(
            string firstName,
            string lastName,
            string email,
            string document,
            string phone,
            string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Document = document;
            Phone = phone;
            Address = address;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}