using dapper.Domain.StoreContext.Enums;
using dapper.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dapper.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
            {
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} em estoque.");
            }

            _items.Add(new OrderItem(product, quantity));
        }

        public void AddDelivery(Delivery delivery)
        {
            _deliveries.Add(delivery);
        }

        // To Place An Order
        public void PlaceAnOrder()
        {
            //Gerar numero do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

            if (_items.Count == 0)
            {
                AddNotification("Order", "Este pedido não possui itens");
            }
        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        public void Ship()
        {
            // A cada 5 produtos é uma entrega
            var deliveries = new List<Delivery>();
            var count = 1;

            // Quebra as entregas
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            // Envia todos as entregas
            deliveries.ForEach(x => x.Ship());

            // Adiciona as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;

            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}