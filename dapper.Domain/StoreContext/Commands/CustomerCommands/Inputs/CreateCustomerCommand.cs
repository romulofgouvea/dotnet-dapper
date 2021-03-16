using dapper.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace dapper.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public new bool Valid()
        {
            var validation = new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O primeiro nome deve conter no minimo 3 caracteres.")
                .HasMaxLen(FirstName, 30, "FirstName", "O primeiro nome deve conter no máximo 30 caracteres.")
                .HasMinLen(LastName, 3, "LastName", "O último nome deve conter no minimo 3 caracteres.")
                .HasMaxLen(LastName, 30, "LastName", "O último nome deve conter no máximo 30 caracteres.")
                .IsEmail(Email, "Email", "O E-mail é inválido.")
                .HasLen(Document, 11, "Document", "O CPF é inválido!");


            AddNotifications(validation);

            return base.Valid;
        }

        public void CreateCustomer()
        {
            //Verificar se cpf ja existe
            //Verificar se email ja existe

            //Cria os VOs
            //Criar entidade

            //Validar as entidadese VO
            //Inserir o cliente no banco

            //Envia email boas vindas
        }
    }
}
