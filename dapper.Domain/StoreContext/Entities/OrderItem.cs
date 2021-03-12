using dapper.Shared.Entities;

namespace dapper.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }

        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = quantity * product.Price;

            if (product.QuantityOnHand < quantity)
            {
                AddNotification("Quantity", "Produto fora de estoque");
            }

            product.DecreaseQuantity(quantity);
        }
    }
}