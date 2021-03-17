using dapper.Domain.StoreContext.Commands.AddressCommands.Inputs;
using dapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using dapper.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using dapper.Domain.StoreContext.Entities;
using dapper.Domain.StoreContext.Repositories;
using dapper.Domain.StoreContext.Services;
using dapper.Domain.ValueObjects;
using dapper.Shared.Commands;
using FluentValidator;

namespace dapper.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressComand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se cpf ja existe no bd
            if (_customerRepository.CheckExistsDocument(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso");
                return null;
            }

            //Verificar se email ja existe no bd
            if (_customerRepository.CheckExistsEmail(command.Email))
            {
                AddNotification("Email", "Este E-mail já está em uso");
                return null;
            }

            //Cria os VOs
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.Document);

            //Criar entidade
            var customer = new Customer(name, email, document, command.Phone);

            //Validar as entidadese VO
            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
            {
                return null;
            }

            //Inserir o cliente no banco
            _customerRepository.Save(customer);

            //Envia email boas vindas
            _emailService.send(email.Address, "hello@dapper.project.com", "Welcome Customer", "Thank you, new Customer!");

            //Retornar o resultado
            return new CreateCustomerCommandResult(
                customer.Id,
                name.ToString(),
                email.Address
            );
        }

        public ICommandResult Handle(AddAddressComand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
