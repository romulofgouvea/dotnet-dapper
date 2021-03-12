using FluentValidator;
using FluentValidator.Validation;

namespace dapper.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            var validation = new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O primeiro nome deve conter no minimo 3 caracteres.")
                .HasMaxLen(FirstName, 30, "FirstName", "O primeiro nome deve conter no máximo 30 caracteres.")
                .HasMinLen(LastName, 3, "LastName", "O último nome deve conter no minimo 3 caracteres.")
                .HasMaxLen(LastName, 30, "LastName", "O último nome deve conter no máximo 30 caracteres.");

            AddNotifications(validation);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}