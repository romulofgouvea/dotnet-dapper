using FluentValidator;
using FluentValidator.Validation;

namespace dapper.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address;

            var validation = new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email","O E-mail é inválido.");

            AddNotifications(validation);
        }

        public override string ToString()
        {
            return Address;
        }
    }
}