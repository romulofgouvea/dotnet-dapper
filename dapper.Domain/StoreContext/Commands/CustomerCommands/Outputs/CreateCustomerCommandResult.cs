using dapper.Shared.Commands;
using System;

namespace dapper.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult() { }

        public CreateCustomerCommandResult(Guid customerId, string name, string email)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
        }

        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
