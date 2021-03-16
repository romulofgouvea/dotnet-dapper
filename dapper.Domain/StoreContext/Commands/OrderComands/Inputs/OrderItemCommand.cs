using dapper.Shared.Commands;
using FluentValidator;
using System;

namespace dapper.Domain.StoreContext.Commands.OrderComands.Inputs
{
    public class OrderItemCommand : Notifiable, ICommand
    {
        public Guid ProductId { get; set; }

        public decimal Quantity { get; set; }

        bool ICommand.Valid()
        {
            return true;
        }
    }
}
