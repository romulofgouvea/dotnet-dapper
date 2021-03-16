using dapper.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;

namespace dapper.Domain.StoreContext.Commands.OrderComands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItens = new List<OrderItemCommand>();
        }

        public Guid CustomerId { get; set; }
        public IList<OrderItemCommand> OrderItens { get; set; }

        bool ICommand.Valid()
        {
            AddNotifications(new ValidationContract()
                .HasLen(CustomerId.ToString(), 36, "CustomerId", "Identificador do Cliente inválido")
                .IsGreaterThan(OrderItens.Count, 0, "OrderItens", "Nenhum item do pedido foi encontrado")
            );

            return base.Valid;
        }
    }
}
