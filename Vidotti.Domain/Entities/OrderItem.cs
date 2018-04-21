using FluentValidator.Validation;
using Vidotti.Shared.Entities;

namespace Vidotti.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Price = product.Price;

            AddNotifications(new ValidationContract()
            .Requires()
            .IsGreaterThan(this.Quantity, 0, nameof(Quantity), "A quantidade deve ser maior que 1")
            .IsGreaterThan(this.Product.QuantityOnHand, Quantity + 1, nameof(Product.QuantityOnHand), $"Não temos tantos {product.Title}(s) em estoque."));

            Product.DecreaseQuantity(quantity);
        }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;
    }
}