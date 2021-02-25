namespace dapper.Domain.StoreContext.Entities
{
    public class OrderItem
    {
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }

        public OrderItem(
            Product product,
            decimal quantity
        )
        {
            Product = product;
            Quantity = quantity;
            Price = quantity * product.Price;
        }
    }
}